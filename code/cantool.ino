#include<MsTimer2.h>
//CAN-TOOL
//从arduino发送到上位机
char datas[] = "t31D80100000000000000t320880478C2F05A1D29At360800402418E4000000t39380000381403000000t03D80D00000000000000t42B84215640000000001t3208094697860945675Dt320838D1DB1304806D85t31880300000000000000t34580000000006CA0000t31D80200000000000000t31880100000000000000t03D83000000000000000t32180F23042701722000t36489476B18400000000t39380000070701000000t36380C51C0521B0090D9t03D80200000000000000t42080332510000000000t345800000000075F0000";
//从上位机发送到arduino
char buffer[25];
int numdata=0;
char flag;
int j=0;

void setup(){
  Serial.begin(9600);
  while(Serial.read() >= 0){}
}
void send(){
 // Serial.println(datas[j]datas[j+1]datas[j+2]datas[j+3]datas[j+4]datas[j+5]datas[j+6]datas[j+7]datas[j+8]datas[j+9]datas[j+10]datas[j+11]datas[j+12]datas[j+13]datas[j+14]datas[j+15]datas[j+16]datas[j+17]datas[j+18]datas[j+19]datas[j+20]);
   for(int k=0;k<21;k++){
    if(k!=20){
    Serial.print(datas[21*j+k]);
    }
    else{
    Serial.println(datas[21*j+k]);  
    }
  }
  j++;
  if(j == 19){
    j=0;
  }
}
void receive(){
  if(Serial.available()>0){
    delay(100);
    numdata = Serial.readBytes(buffer,21);
    if(buffer[0]== 'V'){
    Serial.print("SV2.5-HV2.0");
    }
    else if(buffer[0]=='O' && buffer[1]=='1'  ){
      Serial.print("/r");
      MsTimer2::set(1000,send);
      MsTimer2::start();
    }
    else if(buffer[0]=='S'){
      Serial.print("\r");
    }
    else if(buffer[0]=='C'){
      Serial.print("\r");
      MsTimer2::stop();
    }
    else if(buffer[0]=='t'){
      Serial.println(buffer);
    }
    else if(buffer[0]=='T'){
      Serial.println(buffer);
    }
    else{
      Serial.println("\\BEL");
    }
  }
  while(Serial.read() >= 0){}
  for(int i=0;i<25;i++){
    buffer[i]='\0';
  }
}
void loop(){
  receive();
}
/*********************************************************************************************************

  END FILE

*********************************************************************************************************/
