using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSandBox2600
{
    class Circle
    {
        //data members
        private double radius = 42;
        private string color;

        // constructor(s)

        // porerties
        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if ( value < 0 )
                {
                    Console.WriteLine( " Thou Shall Not Pass! " );
                }
                else
                {
                    radius = value;
                }
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        // methods
        public void PrintMe()
        {
            Console.WriteLine( ">> my Circle radius {0} and color {1}", radius, color );
        }
    }
}
