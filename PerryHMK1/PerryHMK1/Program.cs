using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerryHMK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = input<int>("How many values? ");

            double[] values = new double[n];

            Console.WriteLine();

            for( int i = 0; i < values.Length; i++ )
            {          
                values[i] = input<double>($"Enter value {i + 1}: ");
                Console.WriteLine();
            }

            var maximum = values.Max();
            var maximumCount = values.Where(v => v == maximum).Count();

            Console.WriteLine($"The max value {maximum} was entered {maximumCount} time(s)\n");

            Console.Write("Press any key to leave...");
            Console.ReadKey();
        }
        static T input<T>(string prompt)
        {
            T Response;
            Console.Write(prompt);

            return Response = TryParse<T>(Console.ReadLine(), prompt);
        }
        static S TryParse<S>(object readline, string prompt)
        {
            try
            {
                return (S)Convert.ChangeType(readline, typeof(S));
            }
            catch (Exception jackLame)
            {
                MessageBox.Show($"{jackLame}");
                return input<S>(prompt);
            }
        }
    }
}
