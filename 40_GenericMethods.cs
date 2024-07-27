using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class GenericMethods
    {
        /*

        Overloading is good but you can end up with too many methods with different signature
            Use objects instead of strongly typing causes type issues
        Sometimes generic methods can satisfy the need
            Rember you can also infer type T from paramenters
                Its still better to explicity state T and some generic methods might not even have parameters
        */

           public void Example()
        {
            int testa = 1, testb = 2;

            Swap<int>(ref testa,ref testb);

            Swap(ref testa, ref testb); //Still generic method called but by omitting <T> the T is infered form the parameters
                                            

        }

        //Overloading Solution
        public void Swap(ref float a, ref float b)
        {
            float temp;
            temp = a;
            a = b;
            b = temp;
        }

        public void Swap(ref Car a, ref Car b)
        {
            Car temp;
            temp = a;
            a = b;
            b = temp;
        }

        //Generic Method
        public void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
