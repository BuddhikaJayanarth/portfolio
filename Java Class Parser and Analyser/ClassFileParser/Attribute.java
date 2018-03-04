
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
public class Attribute {
    
    int name_index;
    String thisfieldfirstout;
    int att_len;
    int att_len1;
    int att_len2;
    String thisfielddescout;
    int x;
    int max_stack;
    int max_locals;
    int code_len;
    int code_len1;
    int code_len2;

    boolean exists =false;
    int methodref;
    ArrayList<InvokedMethods> ALInvokedMethods = new ArrayList<InvokedMethods>();
    int exception_table_length;
    int line_number_table_length;
    int attributes_count;
    ArrayList<Attribute> ALAttributes = new ArrayList();
    int count=0;
    ArrayList<String> ReadIMbytes = new ArrayList<String>();

    
    public Attribute(DataInputStream dis, ConstantPool constantPool) throws IOException, InvalidConstantPoolIndex{
        
        name_index = dis.readUnsignedShort();
        CPEntry CPlookup = constantPool.getEntry(name_index);
        thisfieldfirstout = CPlookup.getValues();

        att_len1 = dis.readUnsignedShort();
        att_len2 = dis.readUnsignedShort();
        att_len = att_len1 + att_len2;

        if (att_len>0 && thisfieldfirstout.equals("Code")){
    
            max_stack = dis.readUnsignedShort(); 
            max_locals = dis.readUnsignedShort();

            code_len1 = dis.readUnsignedShort();
            code_len2 = dis.readUnsignedShort();
            code_len = code_len1 + code_len2;

        //finding opcodes indicating another method is invokes        
            for(int at = 0; at<code_len; at++){
                int IMbytecount = ReadIMbytes.size();

                x= Byte.toUnsignedInt(dis.readByte());
                
                if(x==182 ||x==183 ||x==184 ||x==185){
                    methodref = dis.readUnsignedShort();
                    if(count==0){
                        ALInvokedMethods.add(new InvokedMethods(dis, constantPool, methodref));
                        ReadIMbytes.add(Integer.toHexString(methodref));
                    }
                    else{
                        for(int b=0 ; b<IMbytecount;b++){

                            if(Integer.toHexString(methodref).equals(ReadIMbytes.get(b))){
                                exists = true;
                            }
                        }
                        if(exists==false){
                            ALInvokedMethods.add(new InvokedMethods(dis, constantPool, methodref));
                            ReadIMbytes.add(Integer.toHexString(methodref));
                        }
                        exists = false;
                    }

                    


                    count++;
                    at = at +2;
                }
            }
//                        int IMbytecount = ReadIMbytes.size();
//                        for(int b=0 ; b<IMbytecount;b++){
//
//                                System.out.println(ReadIMbytes.get(b));
//
//                        }
//                        System.out.println("");
            exception_table_length = dis.readUnsignedShort();

            for (int exc=0; exc<exception_table_length; exc++){
                x = dis.readUnsignedShort();
                x = dis.readUnsignedShort();
                x = dis.readUnsignedShort();
                x = dis.readUnsignedShort();
            }

            attributes_count = dis.readUnsignedShort();

            for (int intfa=0; intfa<attributes_count; intfa++){

                ALAttributes.add(new Attribute(dis, constantPool));
            }
        }
        
        else if (att_len>0 && thisfieldfirstout.equals("LineNumberTable")){

            line_number_table_length = dis.readUnsignedShort();

            for (int exc=0; exc<line_number_table_length; exc++){
                x = dis.readUnsignedShort();
                x = dis.readUnsignedShort();
            }
            
        }
        
        else{
            
            for(int y=0; y<att_len; y++){
                x = Byte.toUnsignedInt(dis.readByte());
            }
            
        }
    }
    
}
