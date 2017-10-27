using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSandBox2600
{
    class Program
    {
        static void Main( string [] args )
        {

            Circle c1 = new Circle();
            Circle c2 = new Circle();

            c1.Radius = 10;
            c2.Radius = -10;

            c1.Color = "Red";
            c2.Color = "Blue";

            c1.PrintMe();
            c2.PrintMe();

            Console.ReadKey();
        }
    }
}
