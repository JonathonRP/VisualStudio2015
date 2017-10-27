using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE3
{
    class Part
    {
        //private double costPerPart;
        //private int quantity;
        //private string name;

        //public double CostPerPart
        //{
        //    get
        //    {
        //        return costPerPart;
        //    }

        //    set
        //    {
        //        costPerPart = value;
        //    }
        //}
        //public int Quality
        //{
        //    get
        //    {
        //        return quantity;
        //    }

        //    set
        //    {
        //        quantity = value;
        //    }
        //}
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }

        //    set
        //    {
        //        name = value;
        //    }
        //}

        //public Part ()
        //{
        //    name = "unknown";
        //}

        public double CostPerPart { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; } = "unkown";

        public Part()
        {

        }

        public Part( string newName, double newCostPerPart, int newQuantity )
        {
            CostPerPart = newCostPerPart;
            Quantity = newQuantity;
            Name = newName;
        }

        public double Cost() => CostPerPart * Quantity;

        //public double Cost ()
        //{
        //    return CostPerPart * Quantity;
        //}

        public override string ToString()
        {
            string DataMembers = $"Name: {Name} \nPerPart Cost: {CostPerPart:C} \nDesired Quanity: {Quantity} \nTotal Cost: {Cost():C} \n";
            return DataMembers;
        }
    }
}
