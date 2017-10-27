using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPrompts;


namespace PerryPA3
{
    class Package
    {

        private dynamic height, length, width, weight;
            
        public Package()
        {          
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            
            ConsolePrompt<int> CustomerPackageInfo = new ConsolePrompt<int>( errorColor: ConsoleColor.DarkRed );

            CustomerPackageInfo.errorMessage = CustomerPackageInfo.errorMessage.Replace( "Invalid", "Error! not a(n)" );

            ConsolePrompt<double>.ErrorColor = ConsoleColor.DarkRed;
            ConsolePrompt<double>.ErrorMessage = ConsolePrompt<double>.ErrorMessage.Replace( "Invalid", "Error! not a(n)" );

            //Prompts<int> package = new Prompts<int>( errorColor: ConsoleColor.DarkRed );

            //package.errorMessage = package.errorMessage.Replace( "Invalid", "Error!" );

            //length = package.Prompt( "Enter Length (in inches): " );
            //width = package.Prompt( "Enter Width (in inches): " );
            //height = package.Prompt( "Enter Height (in inches): " );
            //weight = package.Prompt<double>( "Enter Weight (in lb): " );

            //ConsolePrompt<int>.Prompt<double>( "Enter Height : ", out height, "Enter Length : ", out length, "Enter Width : ", 
            //out width, "Enter Weight : ", out weight );

            length = ConsolePrompt<int>.Prompt( "Enter Length in inches: " );
            width = ConsolePrompt<int>.Prompt( "Enter width in inches: " );
            height = ConsolePrompt<int>.Prompt( "Enter Height in inches: " );

            weight = ConsolePrompt<double>.Prompt( "Enter Weight in inches: " );
        }

        public Package( int newHeight, int newLength, int newWidth, double newWeight )
        {
            height = newHeight;
            length = newLength;
            width = newWidth;
            weight = newWeight;
        }

        public double ShippingCost()
        {
            double cubicInches = length * width * height;
            double cost = ( 5 * weight ) + ( .01 * cubicInches );

            return cost;
        }

        public void PrintShipping()
        {

            Console.WriteLine( $"\nThe {length}x{width}x{height} inch package at {weight} lb(s) will cost {ShippingCost():C} to ship" );

        }

    }
}
