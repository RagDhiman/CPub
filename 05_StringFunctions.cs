using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class StringFunctions
    {
        public static void Example()
        {
            //String Interploation
            int age = 35;
            string name = "rag";

            Console.WriteLine($"My name is {name.ToLower()} and my current age is {age}"); //Dont forget $
            Console.ReadLine();

        }
    }
}
