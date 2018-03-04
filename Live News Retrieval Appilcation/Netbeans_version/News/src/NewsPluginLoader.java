/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */

//referenced from lab worksheet 4
import java.io.IOException;
import java.nio.file.*;

public class NewsPluginLoader extends ClassLoader
{
	public NewsPlugin loadPlugin(String pluginname) throws ClassNotFoundException
	{
		try
		{
			byte[] classData = Files.readAllBytes(Paths.get(pluginname));
			Class<?> cls = defineClass(null, classData, 0, classData.length);
			return (NewsPlugin)cls.newInstance();
		}
		catch(IOException | InstantiationException | IllegalAccessException e)
		{
			throw new ClassNotFoundException(String.format("Could not load '%s': %s", pluginname, e.getMessage()),e);
		}
	}

}
