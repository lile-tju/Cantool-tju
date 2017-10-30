using unitTest;
using IniOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace unitTest
{
    public class Form1TestCases
    {
        [Fact]
        //
        public void openButton_ClickTest()
        {
            var fm = new Form1();
            fm.openButton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void openButton_ClickTest_1()
        {
            var fm = new Form1();
            fm.openButton_Click().ShouldBe(2);
        }

        [Fact]
        //
        public void closeButton_ClickTest()
        {
            var fm = new Form1();
            fm.closeButton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void closeButton_ClickTest_1()
        {
            var fm = new Form1();
            fm.closeButton_Click().ShouldBe(2);
        }

        [Fact]
        //
        public void Form1_FormClosed1Test()
        {
            var fm = new Form1();
            fm.Form1_FormClosed1().ShouldBe(1);
        }

        [Fact]
        //
        public void Form1_FormClosed1Test_1()
        {
            var fm = new Form1();
            fm.Form1_FormClosed1().ShouldBe(0);
        }


        [Fact]
        //
        public void SendButton_ClickTest()
        {
            var fm = new Form1();
            fm.SendButton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void SendButton_ClickTest_1()
        {
            var fm = new Form1();
            fm.SendButton_Click().ShouldBe(2);
        }


        [Fact]
        //
        public void SetVisiable1Test()
        {
            var fm = new Form1();
            fm.SetVisiable1(1).ShouldBe(1);
        }

        [Fact]
        //
        public void SetVisiable1Test_1()
        {
            var fm = new Form1();
            fm.SetVisiable1(0).ShouldBe(0);
        }

        [Fact]
        //
        public void getversionbutton_ClickTest()
        {
            var fm = new Form1();
            fm.getversionbutton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void getversionbutton_ClickTest_1()
        {
            var fm = new Form1();
            fm.getversionbutton_Click().ShouldBe(2);
		}

        [Fact]
        //
        public void openCanToolbutton_ClickTest()
        {
            var fm = new Form1();
            fm.openCanToolbutton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void openCanToolbutton_ClickTest_1()
        {
            var fm = new Form1();
            fm.openCanToolbutton_Click().ShouldBe(2);
        }

        [Fact]
        //
        public void setSnbutton_ClickTest()
        {
            var fm = new Form1();
            fm.setSnbutton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void setSnbutton_ClickTest_1()
        {
            var fm = new Form1();
            fm.setSnbutton_Click().ShouldBe(2);
        }

        [Fact]
        //
        public void closeCanToolbutton_ClickTest()
        {
            var fm = new Form1();
            fm.closeCanToolbutton_Click().ShouldBe(1);
        }

        [Fact]
        //
        public void closeCanToolbutton_ClickTest_1()
        {
            var fm = new Form1();
            fm.closeCanToolbutton_Click().ShouldBe(2);
        }
    }
}