
import java.io.DataInputStream;
import java.io.IOException;
import java.util.ArrayList;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class Field {
    
    String accessflag2;
    int name_index;
    String thisfieldfirstout;
    int descriptor_index;
    String thisfielddescout;
    int attributes_count;
    ArrayList<Attribute> ALAttributes = new ArrayList();
    
        public Field(DataInputStream dis, ConstantPool constantPool) throws IOException, InvalidConstantPoolIndex{
        
        accessflag2 = Integer.toHexString(dis.readUnsignedShort());

        
                switch(accessflag2)
        {
            case  "1": accessflag2 = "ACC_PUBLIC";               break;
            case  "10": accessflag2 = "ACC_FINAL";               break;
            case  "11": accessflag2 = "ACC_FINAL ACC_PUBLIC";               break;
            case  "20": accessflag2 = "ACC_SUPER";               break;
            case  "21": accessflag2 = "ACC_SUPER ACC_PUBLIC";               break;
            case  "200": accessflag2 = "ACC_INTERFACE";               break;
            case  "201": accessflag2 = "ACC_INTERFACE ACC_PUBLIC";               break;
            case  "400": accessflag2 = "ACC_ABSTRACT";               break;
            case  "401": accessflag2 = "ACC_SUPER ACC_PUBLIC";               break;
            case  "1000": accessflag2 = "ACC_SYNTHETIC";               break;
            case  "1001": accessflag2 = "ACC_SYNTHETIC ACC_PUBLIC";               break;
            case  "2000": accessflag2 = "ACC_ANNOTATION";               break;
            case  "2001": accessflag2 = "ACC_ANNOTATION ACC_PUBLIC";               break;
            case  "4000": accessflag2 = "ACC_ENUM";               break;
            case  "4001": accessflag2 = "ACC_ENUM ACC_PUBLIC";               break;
       
            default:
        }
        
        name_index = dis.readUnsignedShort();
        CPEntry CPlookup = constantPool.getEntry(name_index);
        thisfieldfirstout = CPlookup.getValues();
//        System.out.print("Field: "+thisfieldfirstout);
        
        descriptor_index = dis.readUnsignedShort();
        CPlookup = constantPool.getEntry(descriptor_index);
        thisfielddescout = CPlookup.getValues();
//        System.out.println(" "+thisfielddescout);
        
        attributes_count = dis.readUnsignedShort();
        
        for (int intfa=0; intfa<attributes_count; intfa++){
        ALAttributes.add(new Attribute(dis, constantPool));
        }
        
        }
        
    
}
