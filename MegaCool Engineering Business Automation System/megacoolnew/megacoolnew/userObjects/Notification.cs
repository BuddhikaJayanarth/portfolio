using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class Notification
    {
        private int ID;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }
        private String Description;

        public String Description1
        {
            get { return Description; }
            set { Description = value; }
        }
        private String Category;

        public String Category1
        {
            get { return Category; }
            set { Category = value; }
        }
        private int ClearanceLevel;

        public int ClearanceLevel1
        {
            get { return ClearanceLevel; }
            set { ClearanceLevel = value; }
        }


    }
}
