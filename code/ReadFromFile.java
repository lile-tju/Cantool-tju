import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
 
 
public class ReadFromFile {
      public static void main(String[] args) {
            try {
            // read file content from file
            StringBuffer sb= new StringBuffer("");
           
            FileReader reader = new FileReader("f://test.txt");
            BufferedReader br = new BufferedReader(reader);
           
            String str = null;
           
            while((str = br.readLine()) != null) {
                  sb.append(str+"/n");
                 
                  System.out.println(str);
            }
           
            br.close();
            reader.close();
           
            // write string to file
            FileWriter writer = new FileWriter("f://test2.txt");
            BufferedWriter bw = new BufferedWriter(writer);
            bw.write(sb.toString());
           
            bw.close();
            writer.close();
      }
      catch(FileNotFoundException e) {
                  e.printStackTrace();
            }
            catch(IOException e) {
                  e.printStackTrace();
            }
      }
 
}
