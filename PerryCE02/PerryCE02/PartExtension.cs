using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE02
{
    static class PartExtension
    {
        public static double CostOfInventory(this Part part)
        {
            return part.Quantity * part.GetCostPerPart();
        }
    }
}
