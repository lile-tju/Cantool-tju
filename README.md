# Cantool-tju
现代软件工程第13组，成员有4人，包括组长ll，组员wbp，hh，fyj。  
**任务**：完成cantool测试和APP测试。  
**进度安排**：

            10.10-10.15完成Arduino开发并完成相应的测试。
            10.15-10.18号完成蓝牙的串口通信。
            10.10-10.20基本确立测试接口与方法。
            10.25-11.01完成结课资料准备，
            fyj：需求文档，系统配置和安装，github截图
            l l：设计说明-cantool，ppt-cantool
            wbp：设计说明-测试部分，ppt-测试部分
            h h：会议记录，测试文档，源代码
            P S:个人体会与经验教训每人都要准备一点，由fyj整合;测试部分hh和wbp可商量自行调整任务分配（辛苦了，有点重）;ppt部分我觉得fyj和hh也要准备点自己想讲的一些东西，这是一个必要的过程。
            
#### 接下来主要任务<br>
1.成功将cantool装置与APP进行交互信息，完善接收处理字符串以及测试接口的设计细节————反复阅读“problem statement”<br>
2.文档的整理以上交或展示之用。<br>
3.与APP组确立一些相互的细节（知道APP组能做些什么，同时也让APP组知道我们能做些什么）<br>
4.测试windows开发小组的代码<br>

**小组分工**     
  		  
  ll：主要负责cantool装置代码的编写(串口以及蓝牙)，小组的任务监督与分配，进度把握		
 
  fyj：主要负责cantool装置代码的编写（串口以及蓝牙），UML图的绘制，日常会议记录

  wbp：主要负责测试部分的设计（单元测试），小组整体软件的把握，与ll结对进行连接APP和CANtool的开发。		  

  hh：主要负责测试部分的设计（单元测试），博客的维护，与合作组的联系	
##### PS:与合作组的细节确立需要大家不断地了解明确后细谈	 

#### 文档解释
  test：测试数据——>test1-4  由cantool装置发送到上位机
  cantool.ino是利用串口通信和windows进行通信
  cantool2.0.ino是利用蓝牙串口通信和Android进行通信

#### 进度  
完成了Arduino开发，能够实现发送、接收功能。还可以改进的地方：对于错误信息的输入加以限制。  
Arduino的代码使用Google的googletest进行测试。  
我们的代码已经提交给windows开发小组，也获得windows小组的部分代码准备测试。
&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<font color=#FF00FF>Group Discussion&Cooperation</font>
<div style="float:left;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/7f93a44accacd76357315a1074ba3531/xmlnote/D05F6A3ECBAB4B20B240547194789A75/613" ></div><div style="float:right;border:solid 1px 000;margin:10px;"><img src="http://note.youdao.com/yws/public/resource/7f93a44accacd76357315a1074ba3531/xmlnote/0082CBB7AD7E43CA8FE64CD787BF190C/621" ></div>
