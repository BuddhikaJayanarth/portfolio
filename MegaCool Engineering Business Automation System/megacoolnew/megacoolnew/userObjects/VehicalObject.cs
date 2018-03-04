using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
   public class VehicalObject
    {
        private string vehicalNo;
        private string make;
        private string Type;
        private string model;
        private string status;
        private string capacity;
        private string description;
        private DateTime last_ser_date;
        private DateTime Next_ser_date;
        private float last_ser_milage;
        private float next_ser_milage;
        private string ser_description;

        public string Ser_description
        {
            get { return ser_description; }
            set { ser_description = value; }
        }


        public float Next_ser_milage
        {
            get { return next_ser_milage; }
            set { next_ser_milage = value; }
        }

        public float Last_ser_milage
        {
            get { return last_ser_milage; }
            set { last_ser_milage = value; }
        }

        public DateTime Next_ser_date1
        {
            get { return Next_ser_date; }
            set { Next_ser_date = value; }
        }

        public DateTime Last_ser_date
        {
            get { return last_ser_date; }
            set { last_ser_date = value; }
        }

        public string Type1
        {
            get { return Type; }
            set { Type = value; }
        }
        
        


        public string Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        


        public string VehicalNo
        {
            get { return vehicalNo; }
            set { vehicalNo = value; }
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
        

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
    }
}
