using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unitTest
{
    public partial class Form2 : Form
    {

        private Form1.SetVisiableHandler m_setVisible;

        public Form2(Form1.SetVisiableHandler setvisible)
        {
            InitializeComponent();
            this.m_setVisible = setvisible;
        }

        private void ShowMessbutton_Click(object sender, EventArgs e)
        {
            #region
            /*for (int i = 0; i < 10; i++)   //添加10行数据
            {
                ListViewItem lvi = new ListViewItem();

                //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

                lvi.Text = "subitem" + i; //第一列

                lvi.SubItems.Add("第2列,第" + i + "行");

                lvi.SubItems.Add("第3列,第" + i + "行");

                CanMesslistView.Items.Add(lvi);
            }*/
            #endregion

            Analysis ay = new Analysis();
            List<string> Cangets = new List<string>();
            Cangets.Add("t8561122334455667788");

            flushMesslist(Cangets,0);
            textBox1.Text = "tttttttt";
        }

        public void flushMesslist(List<string> Cangets,int flushtype)
        {
            #region
            //CanMesslistView.Clear();
            //CanMesslistView.Items.Clear();

            //string Canget = "t8561122334455667788\r";


            /*foreach (string Canget in Cangets) //此处疑似有重复
            {
                ListViewItem listv = new ListViewItem();
                listv.Text = Canget;
                CanMesslistView.Items.Add(listv);
            }*/
            #endregion
                Analysis ay = new Analysis();
                foreach (string Canget in Cangets)
                {
                    if (string.Equals("t", Canget.Substring(0, 1)) || string.Equals("T", Canget.Substring(0, 1)))
                    {
                        foreach (string CanData in ay.canReceiptAnalysis(Canget))
                        {
                            string[] Data = CanData.Split(',');
                            //Console.WriteLine(Data[0] + "----------" + Data[1]);
                            ListViewItem listv = new ListViewItem();
                            listv.Text = Data[0]; //第一列
                            listv.SubItems.Add(Data[1]); //没有报错提示
                            CanMesslistView.Items.Add(listv);
                        }
                    }
                    else
                    {
                        ListViewItem listv = new ListViewItem();
                        listv.Text = Canget;
                        CanMesslistView.Items.Add(listv);
                    }

                }

                textBox1.Text = "***************";
            
           
        }

        public void flushf3test(List<string> Cangets, int flushtype,Form3 f3) //flushtype无效
        {
            Analysis ay = new Analysis();
            List<string> AnalysisOK ;
            foreach (string Canget in Cangets)
            {
                if (string.Equals("t", Canget.Substring(0, 1)) || string.Equals("T", Canget.Substring(0, 1)))
                {
                    AnalysisOK = ay.canReceiptAnalysis(Canget);
                    foreach (string CanData in AnalysisOK)
                    {
                        string[] Data = CanData.Split(',');
                        //Console.WriteLine(Data[0] + "----------" + Data[1]);
                        ListViewItem listv = new ListViewItem();
                        listv.Text = Data[0]; //第一列
                        listv.SubItems.Add(Data[1]); //没有报错提示

                        //Data[1]是数值
                        CanMesslistView.Items.Add(listv);
                        

                        //给出选择的器件序号
                        
                        
                        //找出器件的值


                        //刷新LED


                        //ay.getCanAllInfoFromDatabase();
                        //f3.changeLED("10,000");
                    }
                    List<string> retCanIDandlocal = f3.retCanIDandlocal;

                    string anaresultID = Canget;

                    int IDlen = 3;
                    if (string.Equals(anaresultID.Substring(0, 1), "t")) //标准帧
                    {
                        IDlen = 3;
                    }
                    else if (string.Equals(anaresultID.Substring(0, 1), "T")) //扩展帧
                    {
                        IDlen = 8;
                    }
                    anaresultID = Canget.Substring(1, IDlen);
                    anaresultID = (Int32.Parse(anaresultID, System.Globalization.NumberStyles.HexNumber)).ToString(); //16转10进制
                                                                                                                      //判断是否在选中的ID中
                    foreach (string Canselected in retCanIDandlocal)
                    {
                        string[] Canblock = Canselected.Split(' ');
                        if (string.Equals(Canblock[0], anaresultID.ToString()))
                        {
                            //Data[1];
                            string[] select=Canselected.Split(' ');
                            int num=Convert.ToInt32(select[1]);
                            string[] LED = AnalysisOK[num].Split(',');
                            string Canvalue = string.Format("{0:00.000}", Convert.ToDouble(LED[1]));
                            f3.changearcScale(Convert.ToSingle(LED[2]), Convert.ToSingle(LED[3]), Convert.ToSingle(LED[1])); 
                            //f3.changearcScale(0F,100F,50F);
                            f3.changeLED(Canvalue);
                        }

                    }
                }
                else
                {
                    ListViewItem listv = new ListViewItem();
                    listv.Text = Canget;
                    CanMesslistView.Items.Add(listv);
                }

            }

            //f3.changeLED("10,000");
        }


        private void seletCanIDbutton_Click(object sender, EventArgs e)
        {
            CanIDcheckedListBox1.Items.Clear();
            Analysis ayselect = new Analysis();
            foreach (string CanID in ayselect.getCanIDFromDatabase())
            {
                CanIDcheckedListBox1.Items.Add(CanID);
            }
        }

        private void CanIDcheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectbuttonshow_Click(object sender, EventArgs e)
        {
            List<string> CanIDselected = new List<string>();
            for (int i = 0; i < CanIDcheckedListBox1.Items.Count; i++)
            {
                if (CanIDcheckedListBox1.GetItemChecked(i))
                {
                    CanIDselected.Add(CanIDcheckedListBox1.Items[i].ToString());
                }
            }
            flushMesslist(CanIDselected,0);
        }

        public List<string> CanIDselected()
        {
            List<string> CanIDselected = new List<string>();
            string str = "";
            for (int i = 0; i < CanIDcheckedListBox1.Items.Count; i++)
            {
                if (CanIDcheckedListBox1.GetItemChecked(i))
                {
                    str = CanIDcheckedListBox1.Items[i].ToString();
                    string[] strID = str.Split(':');
                    CanIDselected.Add(strID[1]);
                }
            }
            return CanIDselected;
        }

        public List<string> filterCanID(List<string> CanMesses, int len)
        {
            //如果包含该信息，不予显示
            List<string> CanIDsl = CanIDselected();
            List<string> getMess = new List<string>();
            string t = "";
            foreach (string canmess in CanMesses)
            {
                string str = canmess.Substring(1, len);
                //textBox1.Text = "123";
                string anaresult = (Int32.Parse(str, System.Globalization.NumberStyles.HexNumber)).ToString();
                if (CanIDsl.Contains(anaresult))
                {
                    getMess.Add(canmess);
                    t += canmess;
                }
            }
            textBox1.Text = t;
            return getMess;
        }

        private void selectbuttoninput_Click(object sender, EventArgs e)
        {
            //点击按钮，调出控件
            //读取数据库，用户输入相关值
            //打包解析为can信号
            //发送给comport，结束。该部分放入发送区
            if (this.m_setVisible != null)
            {
                this.m_setVisible();
            }
            //CanMessageReceiveTextBox = "**********";

            //获取用户选择的ID号
            Analysis ay = new Analysis();
            List<string> CanIDselect = new List<string>();
            ArrayList pList = new ArrayList();
            CanIDselect = CanIDselected();
            foreach (string CanID in CanIDselect)
            {
                List<string> CanInfos= ay.getCaninfoFromDatabase(CanID);

                foreach(string Caninfo in CanInfos)
                {
                    string[] canblock = Caninfo.Split(' ');
                    ListTree p = new ListTree();
                    /*p.ID = Caninfo;
                    p.Data = "0";
                    p.Range ="0";*/
                    p.ID = canblock[0];
                    p.Data = "0";
                    p.Range = canblock[1]+"~"+canblock[2];
                    pList.Add(p);
                }
            }

             //通过ID获取元件

            treeList1.DataSource = pList;
            treeList1.RefreshDataSource();
        }

        public string test()
        {
            return textBox1.Text;
        }

        private void CanMessInputbutton_Click(object sender, EventArgs e)
        {
            int i,lennode=0;
            int count = this.treeList1.Nodes.Count;
            String ss = "";
            Analysis ay = new Analysis();

            for (i = 0; i < count; i++)
            {
                ss += treeList1.Nodes[i].GetValue(1)+ " ";
                textBox1.Text = ss;
            }

            List<string> CanIDselect = new List<string>();
            List<string> CanSignals =new List<string>();
            CanIDselect = CanIDselected();
            string all = "";
            foreach (string CanID in CanIDselect)
            {
                ss = CanID;
                for(i=0;i<Convert.ToInt32(ay.getLongFromDatabase(CanID));i++)
                {
                    ss+=" "+treeList1.Nodes[i+lennode].GetValue(1);
                }
                lennode += i;
                //ss += " ";
                CanSignals.Add(ss);
                all += ss;
            }
            //返回CanSignals;
            textBox1.Text=ay.canSend(CanSignals); //放入发送信息
            //textBox1.Text=all;

            if (this.m_setVisible != null)
            {
                this.m_setVisible();
            }
        }

        private void getDatabasebutton_Click(object sender, EventArgs e)
        {
            /*FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DirectoryInfo theFolder = new DirectoryInfo(foldPath);
                FileInfo[] dirInfo = theFolder.GetFiles();
                //遍历文件夹  
                foreach (FileInfo file in dirInfo)
                {
                    MessageBox.Show(file.ToString());
                }
            }*/


            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileStream fsSource = new FileStream(file, FileMode.Open);
                    FileStream fsTarget = new FileStream("2.txt", FileMode.OpenOrCreate);
                    byte[] sourceArr = new byte[fsSource.Length];
                    fsSource.Read(sourceArr, 0, sourceArr.Length);
                    fsTarget.Position = fsTarget.Length;
                    byte[] full = System.Text.Encoding.Default.GetBytes("\r");
                    fsTarget.Write(full, 0, full.Length);
                    fsTarget.Position = fsTarget.Length;
                    fsTarget.Write(sourceArr, 0, sourceArr.Length);
                    fsSource.Close();
                    fsTarget.Close();
                }

            }
            textBox1.Text= System.IO.Path.GetDirectoryName(fileDialog.FileName);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void treeshow_Click(object sender, EventArgs e)
        {
            //点击按钮，调出控件
            //读取数据库，用户输入相关值
            //打包解析为can信号
            //发送给comport，结束。该部分放入发送区
            if (this.m_setVisible != null)
            {
                this.m_setVisible();
            }
            //CanMessageReceiveTextBox = "**********";

            //获取用户选择的ID号
            Analysis ay = new Analysis();
            List<string> CanIDselect = new List<string>();
            ArrayList pList = new ArrayList();
            /*CanIDselect = CanIDselected();
            foreach (string CanID in CanIDselect)
            {
                List<string> CanInfos = ay.getCaninfoFromDatabase(CanID);

                foreach (string Caninfo in CanInfos)
                {
                    string[] canblock = Caninfo.Split(' ');
                    ListTree2 p = new ListTree2();
                    p.ID ="1";
                    p.Name = "1";
                    p.DLC = "1";
                    p.Data = "1";
                    pList.Add(p);
                }
            }*/
            ListTree2 p = new ListTree2();
            p.GetID = "1";
            p.GetName = "1";
            p.DLC = "1";
            p.GetData = "1";
            pList.Add(p);

            //通过ID获取元件

            treeList2.DataSource = pList;
            treeList2.RefreshDataSource();
        }
    }

    public class ListTree
    {
        private string m_ID= string.Empty;
        private string m_Data = string.Empty;
        private string m_Range= string.Empty;

        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        public string Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }
        public string Range
        {
            get
            {
                return m_Range;
            }
            set
            {
                m_Range = value;
            }
        }


    }

    public class ListTree2
    {
        private string m_ID = string.Empty;
        private string m_Name = string.Empty;
        private string m_DLC = string.Empty;
        private string m_Data= string.Empty;

        public string GetID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        public string GetName
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public string DLC
        {
            get
            {
                return m_DLC;
            }
            set
            {
                m_DLC = value;
            }
        }
        public string GetData
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }


    }
}
