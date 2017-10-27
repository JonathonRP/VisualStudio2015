using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace MyPrompts
{
    /// <summary>
    /// MyPrompts properties each prompt class inherites these properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    
    public class PromptProperties<T>
    {
        /// <summary>
        /// ErrorColor properties to get and set Error color for prompting to try again on invalid answers
        /// </summary>

        protected static ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;

        /// <summary>
        /// ErrorMessage properties to get and set Error message for prompting to try again on invalid answers
        /// </summary>

        protected static string ErrorMessage { get; set; } = $"Invalid {typeof( T ).Name}, try again: ";

        /// <summary>
        /// ErrorTitle properties to get and set Error title for prompting to try again on invalid answers
        /// </summary>

        protected static string ErrorTitle { get; set; } = $"Error! Not a(n) {typeof( T ).Name}";

        /// <summary>
        /// myErrorMessage properties to get and set static ErrorMessage properties for objects
        /// </summary>

        public string MyErrorMessage
        {
            get
            {
                return ErrorMessage;
            }
            set
            {
                ErrorMessage = value;
            }
        }

        /// <summary>
        /// myErrorTitle properties to get and set static ErrorTitle properties for objects
        /// </summary>

        public string MyErrorTitle
        {
            get
            {
                return ErrorTitle;
            }
            set
            {
                ErrorTitle = value;
            }
        }

        /// <summary>
        /// Generic Type converstion TryParse
        /// </summary>
        /// <typeparam name="Z"></typeparam>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        protected static bool TryParse<Z>( object input, out Z value )
        {
            try
            {
                value = (Z) Convert.ChangeType( input, typeof( Z ) );
                return true;
            }
            catch
            {

                value = default( Z );
                return false;
            }
        }
    }

    /// <summary>
    /// Prompt object for new instances of Prompts
    /// </summary>

    public class Prompts<T> : PromptProperties<T>
    {
        /// <summary>
        /// Constructor for Prompts object with optional errorMessage, errorColor, and errorTitle parameters
        /// </summary>

        public Prompts( string errorMessage = null, ConsoleColor errorColor = ConsoleColor.Red, string errorTitle = null )
        {
            new ConsolePrompts<T>( errorMessage, errorColor );
            new MessagePrompts<T>( errorMessage, errorTitle );
        }

        /// <summary>
        /// ConsolePrompt for new instances
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public T ConsolePrompt( string prompt )
        {
            return (T) MyPrompts.ConsolePrompts<T>.Prompt( prompt );
        }

        /// <summary>
        /// ConsolePrompt for new instances to change generic type
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public S ConsolePrompt<S>( string prompt )
        {
            return (S) ConsolePrompts<T>.Prompt<S>( prompt );
        }

        /// <summary>
        /// MessagePrompt for new instances
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public T MessagePrompt( string prompt )
        {
            return (T) MyPrompts.MessagePrompts<T>.Prompt( prompt );
        }

        /// <summary>
        /// MessagePrompt for new instances to change generic type
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public S MessagePrompt<S>( string prompt )
        {
            return (S) MessagePrompts<T>.Prompt<S>( prompt );
        }
    }

    /// <summary>
    /// ConsolePrompts that on Error display an Error MessageBox
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class MessagePrompts<T> : PromptProperties<T>
    {

        /// <summary>
        /// Constructor for MessagePrompt object with optional errorMessage, and errorTitle parameters
        /// </summary>

        public MessagePrompts( string errorMessage = null, string errorTitle = null )
        {
            new ConsolePrompts<T>( errorMessage );
            ErrorTitle = errorTitle;
            ErrorTitle = ErrorTitle ?? $"Invalid {typeof( T ).Name}, try again: ";
        }

        /// <summary>
        /// Prompts user for input and returns input for storage into variable; error shows as MessageBox
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public static T Prompt( string prompt )
        {
            Console.Write( prompt );
            object response = Console.ReadLine();

            T value;
            bool result = TryParse<T>( response, out value );

            while ( result == false )
            {
                ConsoleColor newDefault;
                newDefault = Console.ForegroundColor;

                Console.Write( prompt );
                MessageBox.Show( ErrorMessage, ErrorTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification );

                Console.ForegroundColor = newDefault;
                response = Console.ReadLine();
                result = TryParse<T>( response, out value );
            }
            return value;
        }

        /// <summary>
        /// Prompts user for input and returns input for storage into variable with a changed type; error shows as MessageBox
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="prompt"></param>
        /// <returns></returns>

        protected internal static S Prompt<S>( string prompt )
        {
            Console.Write( prompt );
            object response = Console.ReadLine();

            S value;
            bool result = TryParse<S>( response, out value );

            while ( result == false )
            {
                ConsoleColor newDefault;
                newDefault = Console.ForegroundColor;

                Console.Write( prompt );
                ErrorMessage = ErrorMessage.Replace( typeof( T ).Name, typeof( S ).Name );
                ErrorTitle = ErrorTitle.Replace( typeof( T ).Name, typeof( S ).Name );
                MessageBox.Show( ErrorMessage, ErrorTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification );
                ErrorMessage = ErrorMessage.Replace( typeof( S ).Name, typeof( T ).Name );
                ErrorTitle = ErrorTitle.Replace( typeof( S ).Name, typeof( T ).Name );

                Console.ForegroundColor = newDefault;
                response = Console.ReadLine();
                result = TryParse<S>( response, out value );
            }
            return value;
        }

        /// <summary>
        /// Prompts user for input and passes input out to a variable; error shows as MessageBox
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>

        private static void PromptTemplate<S>( string prompt, out S value )
        {
            value = Prompt<S>( prompt );
        }

        /// <summary>
        /// Prompts user for two inputs to pass to two variables; error shows as MessageBox
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables; error shows as MessageBox
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables; error shows as MessageBox
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3, string prompt4, out T value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );

            PromptTemplate( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for two inputs to pass to two variables of a different type; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with one of type U; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with two of type U; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with two different types; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with one of type U; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of type U; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with three of type U; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of differnt types: U and V; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of type U and one of type V; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with one of type U and two of type V; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables of different types; error shows as MessageBox
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V, W>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3, string prompt4, out W value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );

            PromptTemplate<W>( prompt4, out value4 );
        }
    }

    /// <summary>
    /// Prompts the user for input
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class ConsolePrompts<T> : PromptProperties<T>
    {
        /// <summary>
        /// Constructor for ConsolePrompt object with optional errorMessage and errorColor parameters
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorColor"></param>

        public ConsolePrompts( string errorMessage = null, ConsoleColor errorColor = ConsoleColor.Red )
        {
            ErrorMessage = errorMessage;
            ErrorMessage = ErrorMessage ?? $"Invalid {typeof( T ).Name}, try again: ";
            ErrorColor = errorColor;
        }

        /// <summary>
        /// Prompts user for input and returns input for storage into variable
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>value to store into variable</returns>

        public static T Prompt( string prompt )
        {
            Console.Write( prompt );
            object response = Console.ReadLine();

            T value;
            bool result = TryParse<T>( response, out value );

            while ( result == false )
            {
                ConsoleColor newDefault;
                newDefault = Console.ForegroundColor;

                Console.ForegroundColor = ErrorColor;

                Console.Write( ErrorMessage );
                Console.ForegroundColor = newDefault;
                response = Console.ReadLine();
                result = TryParse<T>( response, out value );
            }
            return value;
        }

        /// <summary>
        /// Prompts user for input and returns input for storage into variable with a changed type
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="prompt"></param>
        /// <returns>value to store into variable of a differnt type</returns>

        protected internal static S Prompt<S>( string prompt )
        {
            Console.Write( prompt );
            object response = Console.ReadLine();

            S value;
            bool result = TryParse<S>( response, out value );

            while ( result == false )
            {
                ConsoleColor newDefault;
                newDefault = Console.ForegroundColor;

                Console.ForegroundColor = ErrorColor;
                ErrorMessage = ErrorMessage.Replace( typeof( T ).Name, typeof( S ).Name );
                Console.Write( ErrorMessage );
                ErrorMessage = ErrorMessage.Replace( typeof( S ).Name, typeof( T ).Name );
                Console.ForegroundColor = newDefault;
                response = Console.ReadLine();
                result = TryParse<S>( response, out value );
            }
            return value;
        }

        /// <summary>
        /// Prompts user for input and passes input out to a variable.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>

        private static void PromptTemplate<S>( string prompt, out S value )
        {
            value = Prompt<S>( prompt );
        }

        /// <summary>
        /// Prompts user for two inputs to pass to two variables
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3, string prompt4, out T value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );

            PromptTemplate( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for two inputs to pass to two variables of a different type
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with one of type U
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with two of type U
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for three inputs to pass to three variables with two different types
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with one of type U
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out T value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of type U
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with three of type U
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3, string prompt4, out U value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<U>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of differnt types: U and V
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out T value2, string prompt3, out U value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with two of type U and one of type V
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out U value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<U>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables with one of type U and two of type V
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3, string prompt4, out V value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );

            PromptTemplate<V>( prompt4, out value4 );
        }

        /// <summary>
        /// Prompts user for four inputs to pass to four variables of different types
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="prompt"></param>
        /// <param name="value"></param>
        /// <param name="prompt2"></param>
        /// <param name="value2"></param>
        /// <param name="prompt3"></param>
        /// <param name="value3"></param>
        /// <param name="prompt4"></param>
        /// <param name="value4"></param>

        public static void Prompt<U, V, W>( string prompt, out T value, string prompt2, out U value2, string prompt3, out V value3, string prompt4, out W value4 )
        {
            PromptTemplate( prompt, out value );

            PromptTemplate<U>( prompt2, out value2 );

            PromptTemplate<V>( prompt3, out value3 );

            PromptTemplate<W>( prompt4, out value4 );
        }
    }
}