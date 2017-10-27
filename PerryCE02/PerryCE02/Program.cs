using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE02
{
    class Program
    {
        static void Main(string[] args)
        {
            Part p1 = new Part("Widget",0,.75);

            bool restock = p1.OutOfStock();

            if(restock)
            {
                p1.AddQuantity(1300);
            }

            Console.WriteLine(p1.ToString());
            Console.WriteLine($"The Inventory Cost is: {p1.CostOfInventory():C}");
            System.Threading.Thread.Sleep(10000);
        }
    }
}
