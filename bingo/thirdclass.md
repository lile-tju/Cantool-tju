  &emsp;&emsp;本周我们小组开始了Cantool装置设计和CanToolApp项目的进一步开展。
  今天我们讨论了我们从10月10号到10月17号的目标，即：完成Arduino开发并完成相应的测试。
  用户的需求是将Arduino采集的CAN信息发送到上位机（移动终端Android、iOS、Windows PC），并由运行在上位机中的CanToolApp软件接收这些信息，
  显示在用户图形界面上。
  同时在CanToolApp的界面上还可以设定CAN信息，通过GUI按钮将信息发送给CanTool装置，Cantool总线、CanTool装置及ECU电子控制装置这些硬件封装成一个模块，
  Arduino直接调用从ECU采集到的数据。
  我们的CanTool装置与上位机通过USB串口实现UART串口通信。
 &emsp;&emsp; 我们当前阶段需要完成的测试有两部分，
  一是Arduino是否能顺利传送CAN信号到上位机并由CanToolApp软件接收，显示在用户图形界面上；
  二是用户能否在anToolApp的界面上设置CAN信息，将信息通过GUI按钮发送，CanTool装置能否接收并返回成功或失败信息。
  &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<font color=#8B0000>Group Discussion&Cooperation</font>

<div style="float:left;border:solid 1px 000;margin:40px;"><img src="http://images.cnblogs.com/cnblogs_com/lile-tju/1095316/t_webwxgetmsgimg%20(4).jpg" width="150" height="180" ></div>
<div style="float:left;border:solid 1px 000;margin:40px;"><img src="http://images.cnblogs.com/cnblogs_com/lile-tju/1095316/t_webwxgetmsgimg%20(2).jpg"  width="150" height="180" ></div>
<div style="float:left;border:solid 1px 000;margin:40px;"><img src="http://images.cnblogs.com/cnblogs_com/lile-tju/1095316/t_webwxgetmsgimg%20(1).jpg" width="150" height="180" ></div>
<div style="clear:both;"></div>
