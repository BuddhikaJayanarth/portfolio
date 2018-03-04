using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace megacoolnew
{
    class Validation
    {

        public bool IsValidEmail(string email)
        {
            string Email = email; 
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(Email, pattern))
            {
                //MessageBox.Show("Valid Email address ");
                return true;
            }
            else
            {
                // MessageBox.Show("Not a valid Email address ");
                return false;
            }
        }

        public bool checkAge(DateTime dob)
        {
            DateTime cyear = DateTime.Now;
            int age = cyear.Year - dob.Year;
            if (age > 17 && age < 55)
                return true;
            else
            {
                MessageBox.Show("Your age is " + age + "\nEmployess should be between age 18 and 55 to be recuited");
                return false;
            }
        }

        
        
    }
}
