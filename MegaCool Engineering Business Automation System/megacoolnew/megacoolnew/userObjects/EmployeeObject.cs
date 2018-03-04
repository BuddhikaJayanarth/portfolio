using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class EmployeeObject
    {
        private String Name;
        private String Mobile;
        private String Home;
        private Char Sex;
        private Char Status;
        private String EPFNo;
        private int Position;
        private double BasicSalary;
        private String PastExperience;
        private DateTime JoineDate;
        private String Address;
        private String Email;
        private DateTime DOB;
        private String NIC;
        private int EmpID;
        private String Qualification;

        public String name
        {
            set { Name = value; }
            get { return Name; }
        }

        public String mobile
        {
            set { Mobile = value; }
            get { return Mobile; }
        }

        public String home
        {
            set { Home = value; }
            get { return Home; }
        }

        public Char sex
        {
            set { Sex = value; }
            get { return Sex; }
        }

        public Char status
        {
            set { Status = value; }
            get { return Status; }
        }

        public String epfno
        {
            set { EPFNo = value; }
            get { return EPFNo; }
        }

        public int position
        {
            set { Position = value; }
            get { return Position; }
        }

        public Double basicsal
        {
            set { BasicSalary = value; }
            get { return BasicSalary; }
        }

        public String pastexp
        {
            set { PastExperience = value; }
            get { return PastExperience; }
        }

        public DateTime joindate
        {
            set { JoineDate = value; }
            get { return JoineDate; }
        }

        public String address
        {
            set { Address = value; }
            get { return Address; }
        }

        public String email
        {
            set { Email = value; }
            get { return Email; }
        }

        public DateTime dob
        {
            set { DOB = value; }
            get { return DOB; }
        }

        public String nic
        {
            set { NIC = value; }
            get { return NIC; }
        }

        public int empid
        {
            set { EmpID = value; }
            get { return EmpID; }
        }
        public string qualification
        {
            set { Qualification = value; }
            get { return Qualification; }
        }
    }
        
    public class Positions
    {
        private int ID;
        private String Position;
        private double Salary;
        private double OTRate;
        private String[] PosNames;
 
        public int id
        {
            set { ID = value; }
            get { return ID; }
        }
        public String posName
        {
            set { Position = value; }
            get { return Position; }
        }
        public String[] posNames
        {
            set { PosNames = value; }
            get { return PosNames; }
        }
        public double bsal
        {
            set { Salary = value; }
            get { return Salary; }
        }
        public double otrate
        {
            set { OTRate = value; }
            get { return OTRate; }
        }
    }

    public class Leave
    {
        private int EmpID;
        private string Reason;
        private DateTime Start;
        private DateTime End;
        private Double Duration;
        private bool Status;
        private String Session;
        private String Type;

        private const int AnnualLeaves = 14;
        private const int CasualLeaves = 7;
        private const int MedicalLeaves = 7;
        private const int HalfDayLeaves = 2;

        public int empid
        {
            set { EmpID = value; }
            get { return EmpID; }
        }
        public String type
        {
            set { Type = value; }
            get { return Type; }
        }
        public String reason
        {
            set { Reason = value; }
            get { return Reason; }
        }
        public DateTime start
        {
            set { Start = value; }
            get { return Start; }
        }
        public DateTime end
        {
            set { End = value; }
            get { return End; }
        }
        public Double duration
        {
            set { Duration = value; }
            get { return Duration; }
        }
        public bool status
        {
            set { Status = value; }
            get { return Status; }
        }
        public int annualleaves
        {
            get { return AnnualLeaves; }
        }
        public int casualleaves
        {
            get { return CasualLeaves; }
        }
        public int medicalleaves
        {
            get { return MedicalLeaves; }
        }
        public int halfdayleaves
        {
            get { return HalfDayLeaves; }
        }
        public String session
        {
            set { Session = value; }
            get { return Session; }
        }

        public int CalculateWorkingDays(DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;
            int duration = ts.Days;
            int workingDays = 0;

            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday ||
                end.DayOfWeek == DayOfWeek.Saturday || end.DayOfWeek == DayOfWeek.Sunday)
            {
                return 0;
            }
            if (DateTime.Compare(start, end) == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i <= duration; i++)
                {
                    if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    {
                        workingDays++;
                        start = start.AddDays(1);
                    }
                    else
                    {
                        start = start.AddDays(1);
                    }
                }
                return workingDays;
            }
        }
    }

    public class Attendance
    {
        private int EmpID;
        private DateTime Date;
        private TimeSpan TimeIn;
        private TimeSpan TimeOut;
        private TimeSpan Late;
        private String Status;

        public int empid
        {
            set { EmpID = value; }
            get { return EmpID; }
        }
        public DateTime date
        {
            set { Date = value; }
            get { return Date; }
        }
        public TimeSpan timein
        {
            set { TimeIn = value; }
            get { return TimeIn; }
        }
        public TimeSpan timeout
        {
            set { TimeOut = value; }
            get { return TimeOut; }
        }
        public TimeSpan late
        {
            set { Late = value; }
            get { return Late; }
        }
        public String status
        {
            set { Status = value; }
            get { return Status; }
        }
    }
//SALARY

    public class Salary
    {
        private int EmpID;

        public int empid
        {
            get { return EmpID; }
            set { EmpID = value; }
        }
        private String Name;

        public String name
        {
            get { return Name; }
            set { Name = value; }
        }
        private String Position;

        public String position
        {
            get { return Position; }
            set { Position = value; }
        }
        private Double BasicSal;

        public Double basicsal
        {
            get { return BasicSal; }
            set { BasicSal = value; }
        }
        private Double EPF;

        public Double epf
        {
            get { return EPF; }
            set { EPF = value; }
        }
        private Double ETF;

        public Double etf
        {
            get { return ETF; }
            set { ETF = value; }
        }
        private Double NoPay;

        public Double nopay
        {
            get { return NoPay; }
            set { NoPay = value; }
        }
        private Double TotalAllowance;

        public Double totalallowance
        {
            get { return TotalAllowance; }
            set { TotalAllowance = value; }
        }
        private Double TotalAdditionalPayment;

        public Double totaladditionalpayment
        {
            get { return TotalAdditionalPayment; }
            set { TotalAdditionalPayment = value; }
        }
        private Double NetSalary;

        public Double netsalary
        {
            get { return NetSalary; }
            set { NetSalary = value; }
        }
        private Double GrossSalary;

        public Double grosssalary
        {
            get { return GrossSalary; }
            set { GrossSalary = value; }
        }
        private Double EpfEmployeeAmount;

        public Double epfEmployeeAmount
        {
            get { return EpfEmployeeAmount; }
            set { EpfEmployeeAmount = value; }
        }
        private Double EpfEmployeePersentage = 8;

        public Double epfEmployeePersentage
        {
            get { return EpfEmployeePersentage; }
            set { EpfEmployeePersentage = value; }
        }
        private Double EpfEmployerAmount;

        public Double epfEmployerAmount
        {
            get { return EpfEmployerAmount; }
            set { EpfEmployerAmount = value; }
        }
        private Double EpfEmployerPersentage = 12;

        public Double epfEmployerPersentage
        {
            get { return EpfEmployerPersentage; }
            set { EpfEmployerPersentage = value; }
        }
        private Double ETFAmountPersentage = 3;

        public Double etfAmountPersentage
        {
            get { return ETFAmountPersentage; }
            set { ETFAmountPersentage = value; }
        }
        private Double OT;

        public Double ot
        {
            get { return OT; }
            set { OT = value; }
        }


        public Salary CalculateEPF(Salary sal)
        {
            Salary s = new Salary();
            sal.epfEmployeeAmount = (sal.basicsal * s.epfEmployeePersentage) / 100.0;
            sal.epfEmployerAmount = (sal.basicsal * s.epfEmployerPersentage) / 100.0;
            sal.etf = (sal.basicsal * s.etfAmountPersentage) / 100.0;
            sal.epf = sal.epfEmployeeAmount + sal.epfEmployerAmount;
            return sal;
        }
        
    }
}
