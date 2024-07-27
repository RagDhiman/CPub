using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Parameters_Default
    {
        public static void Example(string myParameter)
        {
            string text = "By default parameters are passed in as a value";

            //i.e. a copy of the variable is created for the method
            //Exactly what is copied will depend on the type of parameter (value type or Ref type)
            //On value types a copy of the variable is created and any changes you make within method the called will NOT see
            //

            Console.WriteLine(text); 
            Console.ReadLine();

        }
    }
}
