using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
   public  class ProfitObject
    {   
        //NetProfit
            private int yearNet;
            private string month;
            private DateTime dateN;
            private double payroll;
            private double marketing;
            private double insurance;
            private double travel;
            private double miselenius;
            private double bill;
            private double tax;
            private double other;
            private double net_Profit;
            private double tot_Ex;

        //Grossprofit
            private int yearGross;
            private string monthGross;
            private DateTime dateG;
            private double productSales;
            private double orderCost;
            private double repairServices;
            private double offsiteServices;
            private double deliveryServices;
            private double totalIncome;
            private double grossProfit;

        //Annualprofit

            private int year;
            private double totalProduct;
            private double totalService;
            private double totalIncome1;
            private double totalExpences;
            private double annualGrossProfit;
            private double annualNetProfit;
  
        
        public int YearNet
        {
            get { return yearNet; }
            set { yearNet = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public DateTime DateN
        {
            get { return dateN; }
            set { dateN= value; }
        }


        public double Payroll
        {
            get { return grossProfit; }
            set { grossProfit = value; }
        }
        
        public double Marketing
        {
            get { return marketing; }
            set { marketing = value; }
        }
        
        public double Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }
        
        public double Travel
        {
            get { return travel; }
            set { travel = value; }
        }
        
        public double Miselenius
        {
            get { return miselenius; }
            set { miselenius = value; }
        }
        
        public double Bill
        {
            get { return bill; }
            set { bill = value; }
        }
        
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public double Other
        {
            get { return other; }
            set { other = value; }
        }
        
        public double Net_Profit
        {
            get { return net_Profit; }
            set { net_Profit = value; }
        }

        public double Tot_Ex
        {
            get { return tot_Ex; }
            set { tot_Ex = value; }
        }


    //--------------------------------------------------------

        public int YearGross
        {
            get { return yearGross; }
            set { yearGross = value; }
        }
        
        public string MonthGross
        {
            get { return monthGross; }
            set { monthGross = value; }
        }

        public DateTime DateG
        {
            get { return dateG; }
            set { dateG = value; }
        }

        public double ProductSales
        {
            get { return productSales; }
            set { productSales = value; }
        }


        public double OrderCost
        {
            get { return orderCost; }
            set { orderCost = value; }
        }

        public double RepairServices
        {
            get { return repairServices; }
            set { repairServices = value; }
        }

        public double OffsiteServices
        {
            get { return offsiteServices; }
            set { offsiteServices = value; }
        }

        public double DeliveryServices
        {
            get { return deliveryServices; }
            set { deliveryServices = value; }
        }        

        public double TotalIncome
        {
            get { return totalIncome; }
            set { totalIncome = value; }
        }

        public double GrossProfit
        {
            get { return grossProfit; }
            set { grossProfit = value; }
        }

//----------------------------------------------

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double TotalProduct
        {
            get { return totalProduct; }
            set { totalProduct = value; }
        }
        public double TotalService
        {
            get { return totalService; }
            set { totalService = value; }
        }
        public double TotalIncome1
        {
            get { return totalIncome1; }
            set { totalIncome1 = value; }
        }
        public double TotalExpences
        {
            get { return totalExpences; }
            set { totalExpences = value; }
        }
        public double AnnualGrossProfit
        {
            get { return annualGrossProfit; }
            set { annualGrossProfit = value; }
        }

        public double AnnualNetProfit
        {
            get { return annualNetProfit; }
            set { annualNetProfit = value; }
        }
        
        
    }
}
