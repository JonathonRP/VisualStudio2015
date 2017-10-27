using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerryHMK2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrettyConsole();
            ConsoleColor reset = Console.ForegroundColor;

            var data = Input("Enter a string of comma separated values \n >> ", ConsoleColor.Red);

            var nums = data.Split(',').GetNumericValues(new double());
            
            Console.ForegroundColor = reset;

            Print($"I counted {nums.Count()} numbers, with an Average of {nums.Average():F2}", newline: true);
            Print($"The minimum value over 100 is {nums.Where(x => x > 100).Min()}\n", newline: true);
            Print("Press any key to exit");
            Console.ReadKey();
        }
        static void PrettyConsole()
        {
            ConsoleColor defualt = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = defualt;
            Console.Clear();
        }
        public static void Print(string prompt, ConsoleColor color = ConsoleColor.Black, bool newline = false)
        {
            Console.ForegroundColor = color;

            if (newline == true)
                Console.WriteLine(prompt);
            else
                Console.Write(prompt);
        }
        public static string Input(string prompt, ConsoleColor color = ConsoleColor.Black)
        {
            Print(prompt);
            Console.ForegroundColor = color;
            var responce = Console.ReadLine();

            if (responce == "")
            {
                MessageBox.Show("Please enter a value", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PrettyConsole();
                responce = Input("Enter a string of comma separated values \n >> ", ConsoleColor.Red);
            }
            return responce;
        }
    }

    public static class Object : System.Object
    {
        public static IEnumerable<TResult> GetNumericValues<TSource, TResult>(this IEnumerable<TSource> input, TResult value = default(TResult) )
        {
            return input.SelectMany(s => TryParse<TResult>(s, out value) ? new TResult[] { value } : new TResult[0]);
        }
        public static R Parse<R>(object input)
        {
            return (R)Convert.ChangeType(input, typeof(R));
        }
        public static Boolean TryParse<S>(object input, out S value)
        {
            try
            {
                value = Object.Parse<S>(input);
                return true;
            }
            catch
            {
                value = default(S);
                return false;
            }
        }
    }
}
