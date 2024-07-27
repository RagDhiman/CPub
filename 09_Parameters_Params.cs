using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Parameters_Params
    {
        public static double CalcAverage(params double[] values)
        {
            //Allows you to pass a number of parameters as one value
            //i.e. an array of parameters of the same type or objects that are related by inheritance
            //why not just use the ARRAY type instead of PARAMS
            //when using array type the calling code would have to create an array first and then pass in
            //With params you can pass them in comma seperated and .net will create an array for you in background

            //Note a method can only have one params value
            //and it must be at the end
            //Calling code can:
            //Pass in an array, coma delimited list or nothing

            double sum = 0;
            if (values.Length == 0)
                return sum;

            for(int i =0; i < values.Length; i++)
            {
                sum += values[i];
                return (sum / values.Length);
            }

            return 0;
        }
    }
}
