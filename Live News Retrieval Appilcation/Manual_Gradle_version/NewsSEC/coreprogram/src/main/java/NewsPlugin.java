
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.List;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public interface NewsPlugin {
   public String GetName();
   public long GetDelay();
   public List<String[]> GetHeadlines() throws MalformedURLException, IOException;
   public List<String[]> parsehtml()throws IOException;
   public List<String[]> call() throws Exception;        
}
