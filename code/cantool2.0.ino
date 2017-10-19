/*  蓝牙串口通信  */
char datas[] = "t36080000000025001100t03D80000000000000001t36480000000003005B24t31880000000000000000t34580000000000000000t36080000000000002800t3608000000B500001A01t36080000000000140004t36080000000047130502t32180000000000009B00t3218002000000403768Et36386700004F0080791Et42B800000000009B0675t420800000000000000AFt03D8000000000000000Ct31D80000000000000004t3938000000003C000000t31880000000000000003t42B80100000000FA0395t3638C010002F00000000";
//从上位机发送到arduino
char buffer[25];
int numdata=0;
char flag = 1;

void setup() {
  Serial.begin(9600);
}

void send(){
   for(int j=0;j<20;j++){
 // Serial.println(datas[j]datas[j+1]datas[j+2]datas[j+3]datas[j+4]datas[j+5]datas[j+6]datas[j+7]datas[j+8]datas[j+9]datas[j+10]datas[j+11]datas[j+12]datas[j+13]datas[j+14]datas[j+15]datas[j+16]datas[j+17]datas[j+18]datas[j+19]datas[j+20]);
   for(int k=0;k<21;k++){
    if(k!=20){
    Serial.print(datas[21*j+k]);
    }
    else{
    Serial.println(datas[21*j+k]);  
    }
  }
  }
}
void receive(){
  if(Serial.available()>0){
    delay(100);
    numdata = Serial.readBytes(buffer,21);
    Serial.println(buffer);
    
  }
  while(Serial.read() >= 0){}
  for(int i=0;i<25;i++){
    buffer[i]='\0';
  }
}
void loop(){
    send();
    receive();
}
