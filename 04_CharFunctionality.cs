using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class CharFunctionality
    {
        public static void Example()
        {
            Console.WriteLine("Char is digit {0}", char.IsDigit('c'));
            Console.WriteLine("Char is punctuation {0}", char.IsPunctuation('c'));

            Console.ReadLine();
        }
    }
}
