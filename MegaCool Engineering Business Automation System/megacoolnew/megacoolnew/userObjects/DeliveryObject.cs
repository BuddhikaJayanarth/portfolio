using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
   public class DeliveryObject
    {
        private string DeliveryNo;
        private string Status;
        private string Description;
        private double Cost;
        private string From;
        private string To;
        private double Distance;
        private double Rate;
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string DeliveryNo1
        {
            get { return DeliveryNo; }
            set { DeliveryNo = value; }
        }



        public string Status1
        {
            get { return Status; }
            set { Status = value; }
        }


        public string Description1
        {
            get { return Description; }
            set { Description = value; }
        }



        public double Cost1
        {
            get { return Cost; }
            set { Cost = value; }
        }



        public string From1
        {
            get { return From; }
            set { From = value; }
        }



        public string To1
        {
            get { return To; }
            set { To = value; }
        }



        public double Distance1
        {
            get { return Distance; }
            set { Distance = value; }
        }



        public double Rate1
        {
            get { return Rate; }
            set { Rate = value; }
        }



    }
}
