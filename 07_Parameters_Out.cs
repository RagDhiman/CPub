using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Parameters_Out
    {
        public static void Example(out string myParameter)
        {
            myParameter = "if we didnt assign a value code wouldnt compile";

            //Out parameters require the method to assign a value to the parameter
            //and if you dont it will error
            //calling code will also see the value
            //main advantage you can have MULTIPLE return values
            //And calling method does not need to init them

            Console.WriteLine(myParameter);
            Console.ReadLine();

        }
    }
}
