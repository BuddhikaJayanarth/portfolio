
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.concurrent.Callable;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
//referencing https://stackoverflow.com/questions/3141158/how-can-a-thread-return-a-value-after-finishing-its-job
public class arstechnicaPlugin implements NewsPlugin, Callable<List<String[]>>{

    @Override
    public String GetName() {
        String y ="arstechnica";
        return y;
    }

    @Override
    public long GetDelay() {
        long milliseconds = 60000;
        return milliseconds;
    }

    @Override
    public List<String[]> GetHeadlines() throws MalformedURLException, IOException {

        //referenced from assignment specs    
        URL url = new URL("https://arstechnica.com/");        
        try(ReadableByteChannel chan = Channels.newChannel(url.openStream())){
            
            File deletefile = new File("arstechnica.html");
            if(deletefile.delete()){
                System.out.println("****************************************************************old arstechnica.html deleted");
            }
        
            File file = new File("arstechnica.html");
            
            //referenced from https://stackoverflow.com/questions/14911127/java-doesnt-download-full-file
            long channel = new FileOutputStream(file, false).getChannel().transferFrom(chan, 0, Long.MAX_VALUE);

        }
        
        return parsehtml();


    }

    //parses the downloaded html and returns arraylist containing the headlines
    @Override
    public List<String[]> parsehtml() throws IOException {
        
        File downloadedhtml = new File("arstechnica.html");
        Document parseddoc = Jsoup.parse(downloadedhtml, null);
        Elements headingelements = parseddoc.select("h1.heading");
        List<String[]> HeadingsList = new ArrayList<String[]>();
        for (Element heading : headingelements) {
            String theheading = heading.text();
            
            String fullheading [] = new String [7];
            fullheading[0] = "www.";
            fullheading[1] = "arstechnica";
            fullheading[2] = ".com: ";
            fullheading[3] = theheading;
            fullheading[4] = " (";
            SimpleDateFormat df = new SimpleDateFormat("dd/MM/yy HH:mm a");
            fullheading[5] = df.format(new Date());
            fullheading[6] = ")";
            //System.out.println("(n) "+theheading);
            HeadingsList.add(fullheading);
        }

        //for (String headingoutput : HeadingsList) {
        //    return("(n) "+headingoutput);
        //}
        
        return HeadingsList;
        
    }

    @Override
    public List<String[]> call() throws Exception {
        return GetHeadlines();
    }
    
}