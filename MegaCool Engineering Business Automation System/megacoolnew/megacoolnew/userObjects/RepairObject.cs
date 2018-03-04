using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class RepairObject
    {
        private int _JobID;

        private string _rType;

        private DateTime _JobStartDate;

        private DateTime _JobEndDate;

        private string _Details;

        private string _ItemNo;

        public int JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        public string rType
        {
            get { return _rType; }
            set { _rType = value; }
        }

        public DateTime JobStartDate
        {
            get { return _JobStartDate; }
            set { _JobStartDate = value; }
        }

        public DateTime JobEndDate
        {
            get { return _JobEndDate; }
            set { _JobEndDate = value; }
        }

        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }

        public string ItemNo
        {
            get { return _ItemNo; }
            set { _ItemNo = value; }
        }
    }
}
