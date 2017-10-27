using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE02
{
    abstract class Thing
    {

        private string name;
        private int quantity;

        public Thing(string _name, int _quantity)
        {
            name = _name;
            quantity = _quantity;
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public override string ToString()
        {
            return $"name: {name}, quantity: {quantity}";
        }
        public abstract void AddQuantity(int _quantity);
    }
}
