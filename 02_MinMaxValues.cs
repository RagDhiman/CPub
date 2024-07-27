using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class MinMaxValues
    {
        public static void Example()
        {
            Console.WriteLine("int min value {0}", int.MinValue);
            Console.WriteLine("int max value {0}", int.MaxValue);
            Console.WriteLine("int min value {0}", System.Int32.MinValue);  //same as int
            Console.WriteLine("int max value {0}", System.Int32.MinValue);  // int is shorthand for this
            Console.WriteLine("DateTime min value {0}", DateTime.MinValue);
            Console.WriteLine("DateTime max value {0}", DateTime.MaxValue);
            Console.ReadLine();

        }
    }
}
