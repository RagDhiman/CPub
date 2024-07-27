using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class FormatNumericalData
    {
       public static void Example()
        {
            Console.WriteLine("{0:d} this is formatted",999999);
            Console.WriteLine("{0:e} this is formatted", 999999);
            Console.WriteLine("{0:f} this is formatted", 999999);
            Console.WriteLine("{0:g} this is formatted", 999999);
            Console.WriteLine("{0:n} this is formatted", 999999);
            Console.WriteLine("{0:x} this is formatted", 999999);

            Console.WriteLine("This is the first no: {0} and 2nd: {1} and 3rd: {2}",101,102,103);
            Console.WriteLine("And formatting, this is the first no: {0:d} and 2nd: {1:d} and 3rd: {2:d}", 101, 102, 103);

            Console.WriteLine($"This is {101:e}");

            Console.ReadLine();

        }
    }
}
