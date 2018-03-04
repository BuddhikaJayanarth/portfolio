
import java.util.Timer;
import java.util.TimerTask;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class pluginscheduler {
    
    Timer timer;
    
    public Timer schedule(NewsPlugin n, TimerTask plugintimertask, long delay){
    
        long updatedelay = n.GetDelay();
        timer = new Timer();

        timer.scheduleAtFixedRate(plugintimertask, delay, updatedelay);
        return timer;
    }
    
    
}
