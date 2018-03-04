using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
   public class AccountObject
    {
        private int expenditureID;
        private DateTime date;
        private string expenditure;
        private string description;
        private double amount;

        public int ExpenditureID
        {
            get { return expenditureID; }
            set { expenditureID = value; }
        }

        
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string Expenditure
        {
            get { return expenditure; }
            set { expenditure = value; }
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

