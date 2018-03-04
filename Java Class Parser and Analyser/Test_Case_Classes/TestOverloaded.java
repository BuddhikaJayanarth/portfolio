/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class TestOverloaded {
    public TestOverloaded() {}
  
    public static void method() {
        method1(1,2);
        method1(1);
        method1();
    }
    
    public static void method1(int i, int j) { 

    }
  
    public static void method1(int i) {

    }
  
    public static void method1() {

    }
}
