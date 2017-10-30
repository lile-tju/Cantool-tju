using IniOperate;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace CanTool
{
    public class Form1TestCases
    {
        //静态方法测试
        //[Fact]
        //测试写INI文件
        //public void ReadIniDataTest()
        //{
        //    var oif = new OperateIniFile();
        //    Assert.NotNull(oif.ReadIniData("0000", "0000", "0000", "data.txt"));
        //}

        //[Fact]
        //测试读INI文件
        //public void WriteIniDataTest()
        //{
        //    var oif = new OperateIniFile();
        //    oif.WriteIniData("0000", "0000", "0000", "data.txt").ShouldBe(false);
        //}


        //点击事件测试
        //

        [Fact]
        //测试打开按钮点击事件
        public void openButton_ClickTest()
        {
            var fm = new Form1();
            fm.openButton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试关闭按钮点击事件
        public void closeButton_ClickTest()
        {
            var fm = new Form1();
            fm.closeButton_Click(new object(), new EventArgs());
        }


        [Fact]
        //测试发送按钮点击事件
        public void SendButton_ClickTest()
        {
            var fm = new Form1();
            fm.SendButton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试Canfrom点击事件
        public void Canform_ClickTest()
        {
            var fm = new Form1();
            fm.Canform_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试接受版本信息点击事件
        public void getversionbutton_ClickTest()
        {
            var fm = new Form1();
            fm.getversionbutton_Click(new object(), new EventArgs());
        }


        [Fact]
        //测试打开CanTool按钮点击事件
        public void openCanToolbutton_ClickTest()
        {
            var fm = new Form1();
            fm.openCanToolbutton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试设置速率按钮点击事件
        public void setSnbutton_ClickTest()
        {
            var fm = new Form1();
            fm.setSnbutton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试关闭CanTool按钮点击事件
        public void closeCanToolbutton_ClickTest()
        {
            var fm = new Form1();
            fm.closeCanToolbutton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试展示窗口按钮点击事件
        public void showconwindbutton_ClickTest()
        {
            var fm = new Form1();
            fm.showconwindbutton_Click(new object(), new EventArgs());
        }

        [Fact]
        //测试加载按钮点击事件
        public void Form1_LoadTest()
        {
            var fm = new Form1();
            fm.Form1_Load(new object(), new EventArgs());
        }
    }
}
