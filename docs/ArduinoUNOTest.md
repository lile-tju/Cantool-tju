Arduino UNO测试  
UNO测试流程  
焊接完USB接口部分电路  
1.插上USB接口，在设备管理器的其他设备里找到“Arduino Uno”，右键点击更新驱动，然后手工更新到Arduino IDE的drivers文件夹下。设备管理器就会更新：端口 Arduino Uno（COM4）.  
2.下载跑马灯程序，如正常运行则没问题了。  
UNO引脚测试  
328p芯片：  
1.328P芯片通过2、3引脚连接到16u2的8、9引脚，正常电压为5V左右。  
2.怀疑晶振有问题，可以用烧录软件读取熔丝位，可以读取证明没问题。也可以换个上传了跑马灯程序的芯片来测试，如跑马灯正常发光，则证明晶振没问题。 如以上两点和VCC/GND电压没问题，基本可以确定328p芯片没问题了。  
16u2芯片各引脚测试：  
Pin1，pin2 断路（拆掉晶振）：插上USB口，电脑端口没反应。烧录软件不能读熔丝位，提示连线错误  
Pin3_GND断路：因为这根线的焊接部分比较长，一般不会断路。  
Pin4_VCC断路：没测。  
Pin8_TXD，pin9_RXD断路（拆掉RN3排阻）：对应的RN4A和RN4B电阻的电压为1.4V左右。正常为5V左右。RXLED灯每隔10秒亮一下。IDE上传显示错误（上传时间停留比较长） avrdude: stk500_recv(): programmer is not responding avrdude: stk500_getsync() attempt 1 of 10: not in sync: resp=0xeb resp随机变化，如0xf9、0x2a等  
Pin10_RXLED，pin11_TXLED断路：RX和TX灯不亮。电脑上传程序到单片机时这两个灯都会亮几下。  
Pin13_GND断路（拆掉RN2排阻和C5电容）：上传程序时显示错误（上传界面停留比较长） avrdude: stk500_recv(): programmer is not responding avrdude: stk500_getsync() attempt 1 of 10: not in sync: resp=0xe0 resp随机变化，如0x4c、0x77等 焊回RN2排阻（C5电容保持拆掉状态），上传程序显示错误（同上），上传状态时，RXLED灯每隔10秒亮一下。  
Pin15_SCK,pin16_MOSI,pin17_MISO，pin24_RESET断路：没测。应该是烧录软件不能读熔丝位或者写入，提示连线错误  
Pin27_UCAP断路（拆掉C8电容）：插上USB口，电脑端口显示unknown device。烧录软件可正常读取熔丝位 Pin28_UGND断路：没测。  
Pin29_D-断路（断开D-线）：插上USB口，电脑端口显示unknown device。未烧录引导程序时在设备管理器的其他里显示16u2，烧录后则在设备管理器的端口里显示Arduino Uno (COM4) (这个的4可以是其他数字，如果没安装驱动，则在其他里显示) Pin30_D+断路（断开D+线）：插上USB口，电脑端口没反应。 Pin31_AVCC断路（断开AVCC线）：插上USB口，电脑端口没反应。