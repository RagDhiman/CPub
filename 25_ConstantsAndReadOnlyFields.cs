using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class ConstantsAndReadOnlyFields
    {
        public const double taxRate = 0.74; //Constants are static by default and you Cant change at runtime
        public readonly double vatRate; //like constants but you can set at runtime: in the constructor: Assigning value outside constructor will error

        public static readonly double someRate;     //Can also have static readonly: You can only set these in a static constructor

        public ConstantsAndReadOnlyFields()
        {
            vatRate = 23;
            //taxRate = 34; Cant set constants at runtime
        }

    }
}
