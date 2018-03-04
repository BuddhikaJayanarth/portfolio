/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public abstract class TestAbstract {
    
   public abstract int AbstractMethod1(int n1, int n2);
   public abstract int AbstractMethod2(int n1, int n2, int n3);
 
   public void Method3(){
      System.out.println("");
      AbstractMethod1(1,2);
   }
   
   public void Method4(){
       
   }
}
