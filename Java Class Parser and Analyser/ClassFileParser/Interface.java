
import java.io.DataInputStream;
import java.io.IOException;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class Interface {
    int tag;
    int name_index;
    
    public Interface(DataInputStream dis) throws IOException{
        
        tag = Byte.toUnsignedInt(dis.readByte());
        name_index = dis.readUnsignedShort();
        
    }
    
}
