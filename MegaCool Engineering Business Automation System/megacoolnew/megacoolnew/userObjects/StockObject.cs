using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    public class StockObject
    {
        private String InventoryID;
        private String ProductType;
        private String Model;
        private String Make;
        private int ReorderLevel;
        private double BuyingPrice;
        private double SellingPrice;
        private int Quantity;

        public String inventoryID
        {
            get { return InventoryID; }
            set { InventoryID = value; }
        }

        public String productType
        {

            get { return ProductType; }
            set { ProductType = value; }
        }

        public String model
        {

            get { return Model; }
            set { Model = value; }
        }

        public String make
        {
            get { return Make; }
            set { Make = value; }
        }

        public int reorderLevel
        {
            get { return ReorderLevel; }
            set { ReorderLevel = value; }
        }

        public double buyingPrice
        {
            get { return BuyingPrice; }
            set { BuyingPrice = value; }
        }

        public double sellingPrice
        {
            get { return SellingPrice; }
            set { SellingPrice = value; }
        }

        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

    }
}
