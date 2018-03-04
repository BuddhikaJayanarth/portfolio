import java.io.*;
import java.lang.reflect.*;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * Parses and stores a Java .class file. Parsing is currently incomplete.
 *
 * @author David Cooper
 */
public class ClassFile
{
    private String filename;
    private long magic;
    private int minorVersion;
    private int majorVersion;
    private ConstantPool constantPool;
    private Method[] methods;
    private int accessflag;
    private String accessflag2;
    private int thisclass;
    private String thisclassfirstout;
    private int superclass;
    private String superclassfirstout;
    private int interface_count;
    private ArrayList<Interface> ALInterfaces = new ArrayList();
    private int field_count;
    private ArrayList<Field> ALFields = new ArrayList();
    private int methods_count;
    private ArrayList<Method> ALMethods = new ArrayList();
    private int unique=0;
    private int recursivelevel =6;

    // ...

    /**
     * Parses a class file an constructs a ClassFile object. At present, this
     * only parses the header and constant pool.
     */
    public ClassFile(String filename) throws ClassFileParserException,
                                             IOException
    {
        DataInputStream dis =
            new DataInputStream(new FileInputStream(filename));

        this.filename = filename;
        magic = (long)dis.readUnsignedShort() << 16 | dis.readUnsignedShort();
        minorVersion = dis.readUnsignedShort();
        majorVersion = dis.readUnsignedShort();
        constantPool = new ConstantPool(dis);
        
        //parsing access_flags
        accessflag = dis.readUnsignedShort();
        accessflag2 = Integer.toHexString(accessflag);

        
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
        
                //parsing this_class
        thisclass = dis.readUnsignedShort();
        CPEntry CPlookup = constantPool.getEntry(thisclass);
        thisclassfirstout = CPlookup.getValues();
        
        CPlookup = constantPool.getEntry(Integer.parseInt(thisclassfirstout, 16));
        thisclassfirstout = CPlookup.getValues();
        
        //parsing super_class
        
        superclass = dis.readUnsignedShort();
        CPlookup = constantPool.getEntry(superclass);
        superclassfirstout = CPlookup.getValues();
        
        CPlookup = constantPool.getEntry(Integer.parseInt(superclassfirstout, 16));
        superclassfirstout = CPlookup.getValues();
        
        //parsing interfaces
        interface_count = dis.readUnsignedShort();
        
        for (int intfa=0; intfa<interface_count; intfa++){
            ALInterfaces.add(new Interface(dis));
        }
        
        //parsing fields

        field_count = dis.readUnsignedShort();
        
        for (int fiel=0; fiel<field_count; fiel++){
            ALFields.add(new Field(dis, constantPool));
        }
        
        //parsing methods
        System.out.println("Methods in this class: "); 
        System.out.println(" ");
        methods_count = dis.readUnsignedShort();
        for (int meth=0; meth<methods_count; meth++){
            ALMethods.add(new Method(dis, constantPool));
        }

        //displaying method options to user
        Method M;
        int MSize = ALMethods.size();
        String[][] display = new String[MSize][2];
        for(int m=0; m<MSize; m++){
            M = ALMethods.get(m);
            display[m][0]=M.thisfieldfirstout;
            display[m][1]=M.thisfielddescout;
        }
        
        for(int m=0; m<MSize; m++){
            System.out.println(m+") "+display[m][0]+"  parameters:"+display[m][1]);
        }        
        System.out.println(" ");
        
        //Prompt for input
        Scanner sc = new Scanner(System.in);
        boolean inputvalid=false;
        System.out.println("Enter number corresponding to a method above to view a recursive tree for it\n"
                + "(Or type 9999 to see the full non-recursive class tree)  :");
        int input = sc.nextInt();
        if(input>=0 && input<= (MSize-1)){
            inputvalid=true;
        }
        if(input == 9999){
            System.out.println(" ");
            System.out.println("==== Full non-recursive class tree ====");
            System.out.println(" ");
            //Display Full Class Tree
            PrintClasstree();
        }
        else{
                while(inputvalid == false){
                    System.out.println("Enter valid number:");
                    input = sc.nextInt();
                    if((input>=0 && input<= (MSize-1)) || input == 9999){
                        inputvalid=true;
                    }
                }
                
                if(input == 9999){
                    System.out.println(" ");
                    System.out.println("==== Full non-recursive class tree ====");
                    System.out.println(" ");
                    //Display Full Class Tree
                    PrintClasstree();
                }
                else{
                    int input2;
                    System.out.println("Enter how many levels of invocation for recursive methods: ");
                    input2 = sc.nextInt();
                    recursivelevel = input2*2;
                    System.out.println(" ");
                    System.out.println("==== Recursive class tree for "+display[input][0]+" "+display[input][1]+" ====");
                    System.out.println(" ");
                    //Display recursive tree for User Specified Method
                    PrintSpecificMethod(display[input][0],display[input][1],1);
                    System.out.println("** Number of Unique Methods and Constructors invoked by method: "+unique+" **");
                }
        }
    }

    /** Returns the contents of the class file as a formatted String. */
    public String toString()
    {
        return String.format("");
    }
    
    //Display recursive tree for User Specified Method
    public void PrintSpecificMethod(String methodname, String para, int depthin){
                                
        Method PrintM;
        Attribute PrintA;
        InvokedMethods PrintIM;
        int MSize = ALMethods.size();
        int ASize;
        int ISize;
        String mname;
        String mtype;
        String mname2 = methodname;
        int depth = depthin;
        int index=1;
        int printpermit=1;
        int missing= 0;
        
        for(int m=0; m<MSize; m++){
            if(depth<recursivelevel){
                    PrintM = ALMethods.get(m);
                    if(methodname.equals(PrintM.thisfieldfirstout) && (para.equals(PrintM.thisfielddescout))){
                    missing++;
                    depth--;
                    for(int d=0; d<depth; d++){
                        System.out.print("     ");
                    }
                    if(printpermit==1){
                        PrintM.PrintM();
                        printpermit--;
                    }    
                    ASize = PrintM.ALAttributes.size();
                    depth++;
                    for(int a=0; a<ASize; a++){
                        index=1;
                        PrintA = PrintM.ALAttributes.get(a);

                        ISize = PrintA.ALInvokedMethods.size();
                        for(int im=0; im<ISize;im++){
                            for(int d=0; d<depth; d++){
                                System.out.print("     ");
                            }
                            PrintIM = PrintA.ALInvokedMethods.get(im);
                            PrintIM.PrintI(ALMethods);
                            if(depth == (recursivelevel-1)){
                                index--;
                                depth++;
                                if(index==0){
                                    for(int d=0; d<depth; d++){
                                        System.out.print("     ");
                                    }
                                    System.out.println("["+methodname+" Recurring]");
                                }
                                depth--;
                            }
                            mname = PrintIM.namelookup;
                            mtype = PrintIM.typelookup;
                            depth++;
                            depth++;
                            printpermit++;
                            PrintSpecificMethod(mname,mtype,depth);
                            depth--;
                            depth--;
                            unique=PrintA.ReadIMbytes.size();
                        }

                    }

                }

                    else{    
                        if(missing == 0 && m == (MSize -1)){
                            System.out.println("** Method not found (not in this class): "+para+" "+methodname);
                        }
                    }
            }
            printpermit=1;
        }

    }
    
    //Display Full Class Tree
    public void PrintClasstree(){

        Method PrintM;
        Attribute PrintA;
        InvokedMethods PrintIM;
        int MSize = ALMethods.size();
        int ASize;
        int ISize;
        int depth = 1;
        int index=1;
        int unique1=0;

        for(int m=0; m<MSize; m++){

                    PrintM = ALMethods.get(m);
                    
                    depth--;
                    for(int d=0; d<depth; d++){
                        System.out.print("     ");
                    }

                    PrintM.PrintM();

                    ASize = PrintM.ALAttributes.size();
                    depth++;
                    for(int a=0; a<ASize; a++){
                        index=1;
                        PrintA = PrintM.ALAttributes.get(a);
                        
                        ISize = PrintA.ALInvokedMethods.size();
                        for(int im=0; im<ISize;im++){
                            depth++;
                            for(int d=0; d<depth; d++){
                                System.out.print("     ");
                            }
                            PrintIM = PrintA.ALInvokedMethods.get(im);
                            PrintIM.PrintI(ALMethods);
                                                   
                            depth--;
                            unique1=PrintA.ReadIMbytes.size();
                        }
                    }
            System.out.println("** Number of Unique Methods and Constructors invoked by method: "+unique1+" **");
            unique1=0;
            System.out.println(" ");    
            System.out.println(" ");
        }        
    }
    
}

