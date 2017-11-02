using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCostumeDataSet
{
    class Costume
    {
        public int Purchases { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Scary { get; set; }

        public int TotalSales { get; }

        public Costume(int purchases, string name, int cost, string scary)
        {
            Purchases = purchases;
            Name = name;
            Cost = cost;
            Scary = scary;
            TotalSales = Purchases * Cost;
        }

        public int GetSalesTotal()
        {
            return Purchases * Cost;
        }
    }
}
