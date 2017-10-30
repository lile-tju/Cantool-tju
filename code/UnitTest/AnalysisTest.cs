using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest
{
    public class Analysis
    {
        List<string> CanIDselect = new List<string>();
        public int m_version = 0;
        public int m_open = 0;
        public int m_Sn = 0;
        public int m_Close = 1;

        public string canReceipt(string CantoolMessage, int version, int open, int Sn, int Close) //接收CanTool装置的信息
        {
            m_version = version;
            m_open = open;
            m_Sn = Sn;
            m_Close = Close;
            string s = CantoolMessage;
            string canReceiptinfo = null;
            byte[] bsTest = new byte[1];
            bsTest[0] = 0x07;
            string wrong = "wrong";

            if (version == 2)
            {
                //返回信息 不影响其它状态
                canReceiptinfo = CantoolMessage;
                m_version = 0;

            }
            if (open == 2)
            {
                //返回打开
                if (string.Equals(s, "\r"))
                {
                    m_open = 1;
                    m_Close = 0;
                    canReceiptinfo = "open ok";
                }
                else if (string.Equals(s, wrong))
                {
                    //返回打开失败
                    m_open = 0;
                    m_Close = 1;
                    canReceiptinfo = "open false";
                }
            }
            if (Sn == 2 && Close == 1)
            {
                //返回速率
                if (string.Equals(s, "\r"))
                {
                    m_Sn = 1;
                    canReceiptinfo = "Sn set ok";
                }
                else if (string.Equals(s, wrong))
                {
                    //返回打开失败
                    m_Sn = 0;
                    canReceiptinfo = "Sn set false";
                }
            }
            if (Close == 2)
            {
                //返回关闭
                if (string.Equals(s, "\r"))
                {
                    m_Close = 1;
                    m_open = 0;
                    canReceiptinfo = "close ok";
                }
                else if (string.Equals(s, wrong))
                {
                    //返回打开失败
                    m_open = 1;
                    m_Close = 0;
                    canReceiptinfo = "close false";
                }
            }
            return canReceiptinfo;
        }



        public List<string> getCanIDFromDatabase()
        {
            List<string> CanIDs = new List<string>();
            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;


            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(' ');
                if (arr.Length == 3)
                {
                    CanIDs.Add(arr[0] + arr[1]);
                }
            }
            return CanIDs;
        }



        public List<string> getCanAllInfoFromDatabase() //获取数据库所有信息，返回List
        {

            List<string> CanAllInfos = new List<string>();
            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;


            while ((s = sr.ReadLine()) != null) //没有跳过，性能损失，考虑hash实现
            {
                int i;
                string[] arr = s.Split(' ');
                if (arr.Length == 3) //查找ID数
                {
                    string CanAllInfo = "";
                    CanAllInfo += (arr[0] + " " + arr[1]);
                    s = sr.ReadLine();
                    Console.WriteLine(s);
                    int Canline = Convert.ToInt32(s); //读入对应ID的Can信息行数
                    s = sr.ReadLine(); //跳过空行

                    for (i = 0; i < Canline; i++)
                    {
                        s = sr.ReadLine(); //跳到有效行
                        string[] arr1 = s.Split(' '); //将每一行每一部分的有效信息放入arr1数组
                                                      //arr1[1] arr[2]分别表示起始编号 长度
                        CanAllInfo += (" " + arr1[0]);
                    }
                    CanAllInfos.Add(CanAllInfo);
                }

            }
            return CanAllInfos;
        }



        public List<string> getCaninfoFromDatabase(string CanID) //通过ID获取具体的信息格式
        {
            int i;
            List<string> CanInfos = new List<string>();
            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(' ');
                if (s.Length > 5 && string.Equals(arr[1], CanID))
                {
                    s = sr.ReadLine();
                    int Canline = Convert.ToInt32(s);
                    s = sr.ReadLine(); //跳过空行
                    for (i = 0; i < Canline; i++)
                    {
                        s = sr.ReadLine(); //跳到有效行
                        string[] arr1 = s.Split(' ');
                        CanInfos.Add(arr1[0] + " " + arr1[6] + " " + arr1[7]);
                    }
                }
            }
            return CanInfos;
        }



        public List<string> canReceiptAnalysis(string CanSignal)//解析接收的Can信号
        {
            int i, j;
            string anaresult = CanSignal;
            anaresult = CanSignal.Substring(0, 1);
            List<string> CanDatas = new List<string>();


            //现在扩展帧，标准帧分别默认为3位和8位十进制数，后期按相应16进制进行解析
            //暂时不写扩展帧的解析
            int IDlen = 3;

            if (string.Equals(anaresult, "t")) //标准帧
            {
                IDlen = 3;
            }
            else if (string.Equals(anaresult, "T")) //扩展帧
            {
                IDlen = 8;
            }

            anaresult = CanSignal.Substring(1, IDlen);
            anaresult = (Int32.Parse(anaresult, System.Globalization.NumberStyles.HexNumber)).ToString(); //16转10进制

            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(' ');
                if (s.Length > 5 && string.Equals(arr[1], anaresult)) //查找ID数
                {
                    Console.WriteLine(arr[1]);
                    anaresult = CanSignal.Substring(2 + IDlen, 16); //默认长度8位，
                    string binarycandata = tobinaryCanData(anaresult); //转化为二进制
                    s = sr.ReadLine();
                    Console.WriteLine(s);
                    int Canline = Convert.ToInt32(s); //读入对应ID的Can信息行数
                    s = sr.ReadLine(); //跳过空行

                    int start, len;

                    for (i = 0; i < Canline; i++)
                    {
                        s = sr.ReadLine(); //跳到有效行
                        string[] arr1 = s.Split(' '); //将每一行每一部分的有效信息放入arr1数组
                                                      //arr1[1] arr[2]分别表示起始编号 长度
                        start = Convert.ToInt32(arr1[1]);
                        len = Convert.ToInt32(arr1[2]);


                        int substart;
                        string caninfo;
                        //加入格式判断
                        if (string.Equals(arr1[3], "0"))
                        {
                            substart = start / 8 * 8 - start % 8 + 7;
                            caninfo = binarycandata.Substring(substart, len);
                        }
                        else
                        {
                            substart = start;
                            string inteltype = "";
                            string intelout = "";
                            for (i = 0; i < 8; i++)
                            {
                                inteltype = binarycandata.Substring(i * 8, 8);
                                char[] strChar = inteltype.ToCharArray();
                                Array.Reverse(strChar);
                                intelout += new string(strChar);
                            }
                            //经过一次reverse

                            caninfo = binarycandata.Substring(substart, len);
                        }



                        /*int substart = start / 8 * 8 - start % 8 + 7;         //解析can信号，start+8-start%8-1 即在二进制字符中的真实起始位置
                                                                               //int subend = substart + len-1;
                                                                               //Console.WriteLine("start:"+substart+"len:"+len); //显示在二进制的起始位和长度
                         //string caninfo = binarycandata.Substring(substart, len); //选取指定位置的can信息
                                                                                  //Console.WriteLine("binarycandata:"+caninfo); //显示二进制can信息*/
                        int x = Convert.ToInt32(caninfo, 2);
                        //Console.WriteLine("x的值"+x); //显示x的数值
                        double Phy = phyCalculate(x, Convert.ToDouble(arr1[4]), Convert.ToDouble(arr1[5])); //计算用户能看懂的物理值
                                                                                                            //Console.WriteLine(arr1[0]+":"+Phy); //顺序显示CanMessage数值！！！
                        CanDatas.Add(arr1[0] + ',' + Phy + ',' + arr1[6] + ',' + arr1[7]);
                    }
                    foreach (string CanData in CanDatas)
                    {
                        string[] Data = CanData.Split(',');
                        //Console.WriteLine(Data[0] + "----------" + Data[1]);
                    }
                    break;
                    //Console.WriteLine(s);
                }
            }

            return CanDatas;
        }

        public double phyCalculate(int x, double A, double B) //计算Phy值
        {
            double Phy;
            Phy = A * x + B;
            return Phy;
        }

        public int xCalculate(double phy, double A, double B) //从x转化为Phy
        {
            int x;
            x = (int)((phy - B) / A);
            return x;
        }

        public string tobinaryCanData(string anaresult)//将CanData转化为二进制数（输入字符串，输出二进制形式字符串）
        {
            int i;
            //把字符串DATA转化为2进制数，以后考虑用函数封装(anaresult->binarycandata)

            byte[] returnBytes = new byte[anaresult.Length / 2];
            for (i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(anaresult.Substring(i * 2, 2), 16);
            string returnStr = "";
            if (returnBytes != null)
            {
                for (i = 0; i < returnBytes.Length; i++)
                {
                    returnStr += returnBytes[i].ToString("X2");
                }
            }


            string t, binarycandata = "";
            for (i = 0; i < returnBytes.Length; i++)
            {
                t = System.Convert.ToString(returnBytes[i], 2);
                t = t.ToString().PadLeft(8, '0');//高位用0补足
                binarycandata += t;
            }

            Console.WriteLine(returnStr);
            Console.WriteLine(binarycandata);
            return binarycandata;
        }

        public string to16CanData(string anaresult) //8个8位二进制数转化为16进制
        {
            string CanData16 = "";
            for (int i = 0; i < 8; i++)
            {
                string subana = anaresult.Substring(i * 8, 8);
                byte Bytes = Convert.ToByte(subana, 2);
                string t = Bytes.ToString("x2");//16进制数
                CanData16 += t;
            }
            return CanData16;
        }

        public string canSendAnalysis(string CanSignal)//把用户输入的内容转化为Can信息 string格式为ID+数据 最后
        {

            string anaresult = null;
            string candata = CanSignal;

            //将用户输入数值按顺序解析，生成CanData
            //查找位置

            int i, j;
            anaresult = candata;
            string[] candatablock = candata.Split(' ');
            //Console.WriteLine("*****************");
            string binaryCanID_Data = "00080000000000000000";//标准帧的CanID和Data
            string extendbinaryCanID_Data = "0000000080000000000000000";//扩展帧的CanID和Data

            //ID放入binaryCanID_Data
            string CanID16 = Convert.ToString(Convert.ToInt32(candatablock[0]), 16);//16进制的CanID
            if (CanID16.Length < 3)
            {
                binaryCanID_Data = binaryCanID_Data.Remove(3 - CanID16.Length, CanID16.Length);
                binaryCanID_Data = binaryCanID_Data.Insert(3 - CanID16.Length, CanID16);
            }
            else
            {
                extendbinaryCanID_Data = extendbinaryCanID_Data.Remove(8 - CanID16.Length, CanID16.Length);
                extendbinaryCanID_Data = extendbinaryCanID_Data.Insert(8 - CanID16.Length, CanID16);
            }
            //Console.WriteLine(binaryCanID_Data);
            //现在扩展帧，标准帧分别默认为3位和8位十进制数，后期按相应16进制进行解析
            //暂时不写扩展帧的解析




            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(' ');
                if (s.Length > 5 && string.Equals(arr[1], candatablock[0])) //查找ID数
                {

                    s = sr.ReadLine();
                    //Console.WriteLine(s);
                    int Canline = Convert.ToInt32(s); //读入对应ID的Can信息行数
                    s = sr.ReadLine(); //跳过空行

                    string binarycandata = tobinaryCanData("0000000000000000"); //转化为二进制
                    int start, len;
                    for (i = 0; i < Canline; i++)
                    {
                        s = sr.ReadLine(); //跳到有效行
                        //Console.WriteLine(s);
                        string[] arr1 = s.Split(' '); //将每一行每一部分的有效信息放入arr1数组
                                                      //arr1[1] arr[2]分别表示起始编号 长度
                        double phy = Convert.ToInt32(candatablock[i + 1]);//根据第i行解析
                        //Console.WriteLine(phy);
                        int x = xCalculate(phy, Convert.ToDouble(arr1[4]), Convert.ToDouble(arr1[5]));//获取一行的x
                        //Console.WriteLine(x);
                        string binaryx_value = System.Convert.ToString(x, 2);

                        start = Convert.ToInt32(arr1[1]);
                        len = Convert.ToInt32(arr1[2]);
                        int substart = start / 8 * 8 - start % 8 + 7;
                        int sublen = len - binaryx_value.Length;

                        binarycandata = binarycandata.Remove(substart + sublen, binaryx_value.Length); //
                        binarycandata = binarycandata.Insert(substart + sublen, binaryx_value);
                    }
                    anaresult = to16CanData(binarycandata);
                    if (CanID16.Length < 3)
                    {
                        binaryCanID_Data = binaryCanID_Data.Remove(4, 16);
                        binaryCanID_Data = binaryCanID_Data.Insert(4, anaresult);
                    }
                    else
                    {
                        extendbinaryCanID_Data = extendbinaryCanID_Data.Remove(9, 16);
                        extendbinaryCanID_Data = extendbinaryCanID_Data.Insert(9, anaresult);
                    }
                }
            }

            //Console.WriteLine(binaryCanID_Data);

            //暂定为标准帧
            if (CanID16.Length < 3)
            {
                binaryCanID_Data = "t" + binaryCanID_Data;
            }
            else
            {
                binaryCanID_Data = "T" + binaryCanID_Data;
            }

            return binaryCanID_Data;
        }

        public string getLongFromDatabase(string CanID)
        {
            string lenth;
            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(' ');
                if (s.Length > 5 && string.Equals(arr[1], CanID))
                {
                    s = sr.ReadLine();
                    break;
                }
            }
            lenth = s;
            return lenth;
        }

        public string canSend(List<string> CanSignals)//向CanTool装置发送信息
        {
            //给出一个can信息格式：candata = "61 2 2 2";
            //解析为Can信息格式发送
            string anaresult = "";

            foreach (string cansignal in CanSignals)
            {
                anaresult += canSendAnalysis(cansignal) + "\r";
            }
            return anaresult;
        }
        public void test()
        {
            Console.WriteLine("*****");
        }
    }
}
