using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class SupplierObject
    {
        private String SupplierID;
        private String Name;
        private String ContactNo;
        private String Address;
        private String email;
        private DateTime PaidDate;
        private double PaidAmount;


        public String supplierID {
            get { return SupplierID;}
            set { SupplierID = value;} 
        }

        public String name
        {
            get { return Name; }
            set { Name = value; }
        }

        public String contactNo
        {
            get { return ContactNo; }
            set { ContactNo = value; }
        }

        public String address
        {
            get { return Address; }
            set { Address = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime paidDate
        {
            get { return PaidDate; }
            set { PaidDate = value; }
        }

        public double paidAmt
        {
            get { return PaidAmount; }
            set { PaidAmount = value; }
        }


    }
}
