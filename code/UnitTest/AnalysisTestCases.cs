using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace unitTest
{
    public class AnalysisTest
    {
        [Fact]
        //测试返回信息
        public void canReceiptTestOfReturnMessage()
        {
            var canRT = new Analysis();
            canRT.canReceipt("testCantoolMessage", 2, 0, 0, 0).ShouldBe("testCantoolMessage");
        }

        [Fact]
        //测试返回信息_1
        public void canReceiptTestOfReturnMessageNull()
        {
            var canRT = new Analysis();
            canRT.canReceipt("", 2, 0, 0, 0).ShouldBe("");
        }

        [Fact]
        //测试打开成功
        public void canReceiptTestOfOpenOk()
        {
            var canRT = new Analysis();
            canRT.canReceipt("\r", 2, 2, 0, 0).ShouldBe("open ok");
        }

        [Fact]
        //测试打开成功_1
        public void canReceiptTestOfOpenOkAnother()
        {
            var canRT = new Analysis();
            canRT.canReceipt("\r", 2, 2, 0, 1).ShouldBe("open ok");
        }

        [Fact]
        //测试打开失败
        public void canReceiptTestOfOpenFalse()
        {
            var canRT = new Analysis();
            canRT.canReceipt("wrong", 2, 2, 0, 0).ShouldBe("open false");
        }

        [Fact]
        //测试打开失败_1
        public void canReceiptTestOfOpenFalseAnother()
        {
            var canRt = new Analysis();
            canRt.canReceipt("wrong", 2, 2, 0, 1).ShouldBe("open false");
        }

        [Fact]
        //测试速率设置成功
        public void canReceiptTestOfSnSetOk()
        {
            var canRT = new Analysis();
            canRT.canReceipt("\r", 0, 0, 2, 1).ShouldBe("Sn set ok");
        }

        [Fact]
        //测试速率设置成功_1
        public void canReceiptTestOfSnSetOkAnother()
        {
            var canRt = new Analysis();
            canRt.canReceipt("\r", 1, 0, 2, 1).ShouldBe("Sn set ok");
        }

        [Fact]
        //测试速率设置失败
        public void canReceiptTestOfSnSetFalse()
        {
            var canRT = new Analysis();
            canRT.canReceipt("wrong", 0, 0, 2, 1).ShouldBe("Sn set false");
        }

        [Fact]
        //测试速率设置失败_1
        public void canRecaiptTestOfSnSetFalseAnother()
        {
            var canRt = new Analysis();
            canRt.canReceipt("wrong", 1, 0, 2, 1).ShouldBe("Sn set false");
        }

        [Fact]
        //测试关闭成功
        public void canReceiptTestOfCloseOk()
        {
            var canRT = new Analysis();
            canRT.canReceipt("\r", 0, 0, 0, 2).ShouldBe("close ok");
        }

        [Fact]
        //测试关闭成功_1
        public void canReceiptTestOfCloseOkAnother()
        {
            var canRt = new Analysis();
            canRt.canReceipt("\r", 1, 0, 0, 2).ShouldBe("close ok");
        }

        [Fact]
        //测试获取数据库所有信息
        public void getCanAllInfoFromDatabaseTest()
        {
            var gCAIFDT = new Analysis();
            string[] testStr = { "0101" };
            List<string> list = new List<string>(testStr);
            gCAIFDT.getCanAllInfoFromDatabase().ShouldBe(testStr);
        }

        [Fact]
        //测试通过ID获取具体的信息格式
        public void getCanInfoFromDatabaseTest()
        {
            var gCIFDT = new Analysis();
            string[] testStr = { "0101" };
            List<string> list = new List<string>(testStr);
            gCIFDT.getCaninfoFromDatabase("0101").ShouldBe(testStr);
        }

        [Fact]
        //测试解析接受的Can信号
        public void canReceiptAnalysisTest()
        {
            var cRAT = new Analysis();
            string[] testStr = { "0101" };
            List<string> list = new List<string>(testStr);
            cRAT.canReceiptAnalysis("0101").ShouldBe(testStr);
        }

        [Fact]
        //测试物理值计算
        public void phyCalculateTest()
        {
            var pCT = new Analysis();
            pCT.phyCalculate(1, 2.0, 3.0).ShouldBe(5.0);
        }

        [Fact]
        //测试x值计算
        public void xCalculateTest()
        {
            var xCT = new Analysis();
            xCT.xCalculate(3.0, 2.0, 1.0).ShouldBe(1);
        }

        [Fact]
        //测试将CanData转化为二进制数
        public void toBinaryCanDataTest()
        {
            var tBCDT = new Analysis();
            tBCDT.tobinaryCanData("1010").ShouldBe("000000000x01X20x00X2");
        }

        [Fact]
        //测试8个8位二进制数转化为16进制
        public void to16CanDataTest()
        {
            var t16CDT = new Analysis();
            t16CDT.to16CanData("0000000000000001000000100000001100000100000001010000011000000111").ShouldBe("0x000x010x020x030x040x050x060x07");
        }

        [Fact]
        //测试把用户输入的内容转化为Can信息
        public void canSendAnalysisTest()
        {
            var cSAT = new Analysis();
            cSAT.canSendAnalysis("0101").ShouldBe("0101");
        }

        [Fact]
        //测试从数据库获取长度
        public void getLongFromDatabaseTest()
        {
            var gLFD = new Analysis();
            gLFD.getLongFromDatabase("0101").ShouldBe("4");
        }

        [Fact]
        //测试向CanTool装置发送信息
        public void canSendTest()
        {
            var cST = new Analysis();
            string[] testStr = { "0101" };
            List<string> list = new List<string> (testStr);
            cST.canSend(list).ShouldBe("0101\r");
        }
    }
}