//demo：CAN-TOOL
//t36080000000025001100
String comdata = "";
void setup()
{
  Serial.begin(115200);
}

void loop()
{
    while(Serial.available() > 0)
    {
      comdata += char(Serial.read());
      delay(2);
    }
    if(comdata.length() > 0)
    {
      Serial.println(comdata);
      comdata = "";
    }
}

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
