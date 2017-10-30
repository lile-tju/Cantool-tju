&emsp;&emsp;今天是我们Cantool装置测试小组和WindowsApp开发小组第一次正式会晤。<br>
&emsp;&emsp;首先，我们相互汇报了项目进度。<br>
WindowsApp小组的工作正接近尾声，已实现了基本的功能：<br>
1.能够搜索到本机所有可使用的COM口，并在弹出式ComboBox中以列表方式让用户选择CanTool装置在上位机中映射的COM口，并且保存设定内容。<br>
2.能够实现CANtool装置的CAN速率设置、进入CAN工作状态、进入CAN初始化状态，并保存设定内容。<br>
3.能够对接收到的多个CAN信息，通过CAN信息及CAN信号数据库进行解析，将CAN信息原始数据进行显示。并能对CAN信息中的CAN信号的物理值实时数据进行显示。<br>
4.显示时可以让用户选择仪表盘方式显示接收到CAN信号物理值，显示方式保存到设定文件供下次使用。<br>
5.可以让用户选择某些接收到的CAN信号，显示其变化的实时物理值曲线。<br>
6.App可将用户设定的物理值转换为CAN信号值，将CAN信息中包含的所有CAN信号合成完整的CAN信息后，发送给CanTool装置，发送到CAN总线上。<br>
7.可以加载用户提供的CAN信息和信号数据库，完成CAN信号数据的解析以及CAN发送信息的组装。可以显示CAN信号在CAN信息的布局。加载的数据库文件相
关信息，可保存到CanToolApp设定文件中，供下次使用。<br>
我们Cantool测试小组也完成了近期的目标：<br>
1.Aruino开发完成并实现相应测试，能够实现发送、接收功能。<br>
2.完成蓝牙的串口通信。<br>
3.Arduino的代码使用Google的googletest测试框架进行测试。<br>
3.我们的代码已提交给WindowsApp开发小组，也获得WindowsApp小组部分代码，基本确立WindowsApp测试接口和方法。<br>
4.整理软件工程课程需求文档、会议记录文档、测试文档。<br>
&emsp;&emsp;接下来，两个小组深入讨论了接口交互过程的一些细节问题：<br>
1.Cantool装置调整初始波特率为9600，与上位机保持一致性。<br>
2.数据方面，澄清了两个小组在收发数据格式上理解的偏差。<br>
3.确立了下次结对编程的时间周五下午1:30-4:00，调配Cantool装置与WindowsApp的正常数据通讯。<br>
4.在本周五之前WindowsApp小组将整合好的项目交给我们完成单元测试和功能测试。<br>
&emsp;&emsp;最后，祝两个小组合作愉快，圆满结课！<br>

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<font color=#FF00FF>小组讨论</font>
<div style="float:left;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/fab582e792117b023b71034778db3b47/xmlnote/C82F7010E1CF455DACF136FFAD59DDA9/691" ></div><div  style="float:left;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/fab582e792117b023b71034778db3b47/xmlnote/7FAB7719C3574A4992A62FE13BFF5A56/688" ></div><div  style="float:left;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/fab582e792117b023b71034778db3b47/xmlnote/68577ECB4D4449CAA4E70C47F4E4DCF6/689" ></div><div  style="float:left;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/fab582e792117b023b71034778db3b47/xmlnote/3B75A1C088164FC497B0B991374D3D2A/694" ></div>
