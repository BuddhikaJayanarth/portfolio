using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{ 
  public  class CustomerObject
    {

        private string nic;
        private string customrName;
        private string email;
        private string address;
        private string phone;
        private string customerType;
        private int rate;
        private string cardType;
        private int cardPoints;
        private string cardNo;

       
        public string Nic
        {
            get { return nic; }
            set { nic = value; }
        }


        public string CustomrName
        {
            get { return customrName; }
            set { customrName = value; }
        }


        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }


        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public int CardPoints
        {
            get { return cardPoints; }
            set { cardPoints = value; }
        }

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
        
    }
}
