using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Parameters_Ref
    {
        public static void SwapValues(ref string value1, ref string value2)
        {
            string tempRef = value1;
            value1 = value2;
            value2 = tempRef;

            //Ref parameters allow method to change value because the parameter is a pointer
            //to the original parameter that is passed in
            //and thats why calling code must initilize it before passing the value in

            //Note the behaviour of this key type changes depending on the value type (value type or reference type)
        }
    }
}
