/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class TestUnique {
    public TestUnique() {}
  
    public static void method() {
        method1(1,2);
        method1(1);
        method1();
        method1(4);
    }
    
    public static void method1(int i, int j) { 
        method1(1,2);
        method1(1,3);
        method1(1,8);
    }
  
    public static void method1(int i) {
        method1();
        method1();
    }
  
    public static void method1() {
        method1(1,3);
        method1(1,8);
    }
}
