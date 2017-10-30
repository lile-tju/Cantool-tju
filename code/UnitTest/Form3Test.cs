using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unitTest
{
    public partial class Form3 : Form
    {
        private Form1.SetVisiableHandler m_setVisible;
        RealChart f4 = new RealChart();
        public Form3(Form1.SetVisiableHandler setvisible)
        {
            InitializeComponent();
            this.arcScaleComponent1.Value = 30F;
            this.digitalGauge1.Text = "00,000";
            this.arcScaleComponent1.MinValue = 0F;
            this.arcScaleComponent1.MaxValue = 100F;
            this.m_setVisible = setvisible;
            
        }
        public string Sn;

        

        public List<string> retCanIDandlocal = new List<string>();

        public void changeLED(string  ledvalue)
        {
            this.digitalGauge1.Text = ledvalue;
            
        }

        public void changearcScale(float min,float Max,float Value)
        {
            this.arcScaleComponent1.Value = Value;
            this.arcScaleComponent1.MinValue = min;
            this.arcScaleComponent1.MaxValue = Max;
            f4.changCharMinAndMax(min, Max, Value);
        }

        /*private string[] Sns = { "S0", "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", };

        private void setSncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Sns.Length; i++)
            {
                setSncomboBox.Items.Add(Convert.ToString(Sns[i]));
            }
        }*/

        private void setOKbutton_Click(object sender, EventArgs e)
        {
            //Sn=setSncomboBox.Text;
            //打开监听功能
            if (this.m_setVisible != null)
            {
                this.m_setVisible();
            }
            // changeLED("10,000");
            List<string> selectedID = new List<string>();

            //只需要加入ID和序号
            String ss = "";
            int count = this.treeList1.Nodes.Count;
            bool added = false;
            for (int i = 0; i < count; i++)
            {
                ss = "";
                added = false;
                for (int j = 0; j < this.treeList1.Nodes[i].Nodes.Count; j++)
                {
                    string CanIDinfo = Convert.ToString(this.treeList1.Nodes[i].GetValue(0));
                    string[] CanIDblock = CanIDinfo.Split(':');
                    if (this.treeList1.Nodes[i].Nodes[j].Checked)
                    {
                        if(!added)
                        {
                            ss += CanIDblock[1];
                            added = true;
                        }
                        ss += (' ' + j.ToString());
                        //ss = Convert.ToString(this.treeList1.Nodes[i].Nodes[j].GetValue(0));
                        //Console.WriteLine(ss);
                        
                    }
                }
                selectedID.Add(ss);
            }

            retCanIDandlocal = selectedID;


            //选中需要显示的数据，获取ID以及排列序号，打包放入结构体
            //用委托进行获取
            //字符串传入控件，进行显示



        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void showCanInfobutton_Click(object sender, EventArgs e)
        {
            int i = 0, t = 0;
            ArrayList pList = new ArrayList();
            Analysis ay = new Analysis();
            List<string> CanAllInfos = ay.getCanAllInfoFromDatabase();
            foreach (string CanAllInfo in CanAllInfos)
            {
                string[] canblock = CanAllInfo.Split(' ');
                ListTree1 p = new ListTree1();
                p.ID = i;
                t = i;
                i++;
                p.IDName = canblock[0] + canblock[1];
                pList.Add(p);
                for (int j = 2; j < canblock.Length; j++)
                {
                    ListTree1 q = new ListTree1();
                    q.ParentID = t;
                    q.ID = i;
                    i++;
                    q.IDName = canblock[j];
                    pList.Add(q);
                }
            }
            this.treeList1.DataSource = pList;
            this.treeList1.RefreshDataSource();
        }

        private void showwavebutton_Click(object sender, EventArgs e)
        {
            f4.Show();
            
        }
    }

    public class ListTree1
    {
        private string m_IDName = string.Empty;
        //private string m_Signal = string.Empty;
        private int m_iID = -1;
        //父Node节点ID变量
        private int m_iParentID = -1;

        public int ID
        {
            get
            {
                return m_iID;
            }
            set
            {
                m_iID = value;
            }
        }

        public int ParentID
        {
            get
            {
                return m_iParentID;
            }
            set
            {
                m_iParentID = value;
            }
        }

        public string IDName
        {
            get
            {
                return m_IDName;
            }
            set
            {
                m_IDName = value;
            }
        }

        /*public string Signal
        {
            get
            {
                return m_Signal;
            }
            set
            {
                m_Signal = value;
            }
        }*/



    }
}

