
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
public class InvokedMethods {
    int methodref;
    int classref;
    int natref;
    int name;
    int type;
    String methodreflookup;
    String classname;
    String classnamelookup;
    String nameandtypelookup;
    String namelookup;
    String typelookup;
    String[] Methodref;
    
    public InvokedMethods(DataInputStream dis, ConstantPool constantPool, int mref) throws IOException, InvalidConstantPoolIndex{
        
        methodref = mref;
        CPEntry CPlookup = constantPool.getEntry(methodref);
        methodreflookup = CPlookup.getValues();
        
        Methodref = methodreflookup.split(",");
        
        classref = Integer.parseInt(Methodref[0],16);
        
        CPlookup = constantPool.getEntry(classref);
        classname = CPlookup.getValues();
        
        classref = Integer.parseInt(classname,16);
        
        CPlookup = constantPool.getEntry(classref);
        classnamelookup = CPlookup.getValues();
        
        natref = Integer.parseInt(Methodref[1],16);
        
        CPlookup = constantPool.getEntry(natref);
        nameandtypelookup = CPlookup.getValues();
        
        String[] Nameandtype = nameandtypelookup.split(",");
        
        name = Integer.parseInt(Nameandtype[0],16);
        type = Integer.parseInt(Nameandtype[1],16);
        
        CPlookup = constantPool.getEntry(name);
        namelookup = CPlookup.getValues();
        
        CPlookup = constantPool.getEntry(type);
        typelookup = CPlookup.getValues();

        
    //    System.out.println("      Invokes: "+typelookup+" "+namelookup);
    }
    
    public void PrintI(ArrayList<Method> ALMethods){
    boolean isAbstract = false;
    int MSize = ALMethods.size();
    Method M;

    for(int m=0; m<MSize; m++){
        M = ALMethods.get(m);
        if(namelookup.equals(M.thisfieldfirstout)){
            if(M.accessflag2.contains("ACC_ABSTRACT")){
                isAbstract =true;
            }
        }
    }
    if(isAbstract == false){    
        System.out.println("Invokes: "+classnamelookup+" "+typelookup+" "+namelookup);
    }
    else if(isAbstract ==true){
        System.out.println("Invokes: "+classnamelookup+" "+typelookup+" "+namelookup+" [ABSTRACT]");
    }
    }
    
    
}
