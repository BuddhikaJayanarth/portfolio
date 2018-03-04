/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ADMIN
 */
public class TestRecursive {
  
    public TestRecursive() {}
  
    public static void method1(int i, int j) { 
        int x = 1;
        method1(5,8); 
    }
  
    public static void method2(int i) {
        method3();
    }
  
    public static void method3() {
        method2(5); 
    }
}
