using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class SalesObject
    {
        private int invoiceNo;
        private string customerName;
        private string location;
        private DateTime date;
        private string phone;
        private string type;
        private double charge;
        private string make;
        private string model;
        private string skey;
        private string inventoryID;
        private string nic;
        private string cardType;
        //new--------
        private string cardPoints;
        //-----------
        private double purchaseGrand;
        //new--------
        private double serviceGrand;
        //-----------
        private double discount;
        private string jobID;



        //new---------
        public double ServiceGrand
        {
            get { return serviceGrand; }
            set { serviceGrand = value; }
        }
        public String CardPoints
        {
            get { return cardPoints; }
            set { cardPoints = value; }
        }
        //------------


        public string JobID 
        {
            get { return jobID; }
            set { jobID = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }


        public double PurchaseGrand
        {
            get { return purchaseGrand; }
            set { purchaseGrand = value; }
        }

        public int InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        public string NIC
        {
            get { return nic; }
            set { nic = value; }
        }

        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public string InventoryID
        {
            get { return inventoryID; }
            set { inventoryID = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Charge    
        {
            get { return charge; }
            set { charge = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string sKey
        {
            get {return skey; }
            set{ skey = value; }
        }



    }
}
