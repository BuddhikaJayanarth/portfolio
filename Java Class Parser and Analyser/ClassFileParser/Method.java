
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
public class Method {
    
    String accessflag1;
    String accessflag2;
    int name_index;
    String thisfieldfirstout;
    int descriptor_index;
    String thisfielddescout;
    int attributes_count;
    ArrayList<Attribute> ALAttributes = new ArrayList();
    
        public Method(DataInputStream dis, ConstantPool constantPool) throws IOException, InvalidConstantPoolIndex{
   
            
        accessflag2 = Integer.toHexString(dis.readUnsignedShort());
        accessflag1 = accessflag2;
        
                switch(accessflag2)
        {
            case  "1": accessflag2 = "ACC_PUBLIC";               break;
            case  "2": accessflag2 = "ACC_PRIVATE";               break;
            case  "4": accessflag2 = "ACC_PROTECTED";               break;
            case  "5": accessflag2 = "ACC_PUBLIC ACC_PROTECTED";               break;
            case  "6": accessflag2 = "ACC_PRIVATE ACC_PROTECTED";               break;
            case  "7": accessflag2 = "ACC_PUBLIC ACC_PRIVATE ACC_PROTECTED";               break;
            case  "8": accessflag2 = "ACC_STATIC";               break;
            case  "9": accessflag2 = "ACC_PUBLIC ACC_STATIC";               break;
            case  "10": accessflag2 = "ACC_FINAL";               break;
            case  "11": accessflag2 = "ACC_FINAL ACC_PUBLIC";               break;
            case  "12": accessflag2 = "ACC_FINAL ACC_PRIVATE";               break;
            case  "0c": accessflag2 = "ACC_PUBLIC ACC_STATIC";               break;
            case  "18": accessflag2 = "ACC_FINAL ACC_STATIC";               break;
            case  "20": accessflag2 = "ACC_SYNCHRONIZED";               break;
            case  "2f": accessflag2 = "ACC_SYNCHRONIZED";               break;
            case  "21": accessflag2 = "ACC_SYNCHRONIZED ACC_PUBLIC";               break;
            case  "22": accessflag2 = "ACC_SYNCHRONIZED ACC_PRIVATE";               break;
            case  "40": accessflag2 = "ACC_BRIDGE";               break;
            case  "80": accessflag2 = "ACC_VARARGS";               break;
            case  "100": accessflag2 = "ACC_FINAL";               break;
            case  "201": accessflag2 = "ACC_INTERFACE ACC_PUBLIC";               break;
            case  "400": accessflag2 = "ACC_ABSTRACT";               break;
            case  "401": accessflag2 = "ACC_PUBLIC ACC_ABSTRACT";               break;
            case  "800": accessflag2 = "ACC_FINAL";               break;
            case  "1000": accessflag2 = "ACC_SYNTHETIC";               break;
            case  "1001": accessflag2 = "ACC_SYNTHETIC ACC_PUBLIC";               break;
            case  "2000": accessflag2 = "ACC_ANNOTATION";               break;
            case  "2001": accessflag2 = "ACC_ANNOTATION ACC_PUBLIC";               break;
            case  "4000": accessflag2 = "ACC_ENUM";               break;
            case  "4001": accessflag2 = "ACC_ENUM ACC_PUBLIC";               break;
       
            default:
        }
        
//        System.out.print("Method: "+accessflag2);
                
        name_index = dis.readUnsignedShort();
        CPEntry CPlookup = constantPool.getEntry(name_index);
        thisfieldfirstout = CPlookup.getValues();
//        System.out.print(" "+thisfieldfirstout);
        
        descriptor_index = dis.readUnsignedShort();
        CPlookup = constantPool.getEntry(descriptor_index);
        thisfielddescout = CPlookup.getValues();
        
//        System.out.println(thisfieldfirstout);
        
        attributes_count = dis.readUnsignedShort();

        
        for (int intfa=0; intfa<attributes_count; intfa++){
        ALAttributes.add(new Attribute(dis, constantPool));
        }
        
//        System.out.println(" ");
}
        
        public void PrintM(){
            System.out.print("Method: "+accessflag2);
            System.out.print(" "+thisfielddescout);
            System.out.println(" "+thisfieldfirstout);
            
        }
        
        
}