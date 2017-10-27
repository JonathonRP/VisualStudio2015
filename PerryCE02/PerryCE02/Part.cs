using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE02
{
    class Part : Thing, IInventory
    {
        private double costPerPart;

        public Part(string _name, int _quantity, double _costPerPart) : base(_name,_quantity)
        {
            costPerPart = _costPerPart;
        }
        public override void AddQuantity(int _quantity)
        {
            Quantity = _quantity;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public double GetCostPerPart()
        {
            return costPerPart;
        }
        public bool OutOfStock()
        {
            if (Quantity <= 0)
                return true;
            else
                return false;
        }
    }
}
