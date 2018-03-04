using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class TaxObject
    {
        private int taxFileNo;
        private DateTime date;
        private string description;
        private double amount;
        
        public int TaxFileNo
        {
            get { return taxFileNo; }
            set { taxFileNo = value; }
        }
            
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


         public double Amount
        {
           get { return amount; }
           set { amount = value; }
        }

       
        }


    }

