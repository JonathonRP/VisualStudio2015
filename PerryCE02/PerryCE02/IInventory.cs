using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE02
{
    interface IInventory
    {
        int GetQuantity();
        double GetCostPerPart();
        bool OutOfStock();
    }
}
