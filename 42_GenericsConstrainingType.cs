using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{

    /*
        For generics you can constraint the type using a where clause:
        
        where T: struct             i.e. T must be a value type like a structure
        where T: class              i.e. T must be a reference type like a class
        where T: new()              i.e. T must have a default constructor i.e. parameterless. This constraint must be listed last
                                            - Default constructor might be a requirement for the code to create an instance
                                            - Remember if you specify your own parameter based constructor DEFAULT constructor i.e. without parameters is removed
        where T: NameOfABaseClass   i.e. T must be a derived class of specified base class
        where T: NameoFAnInterface  i.e. T must implement specified interface
    */

    class Reformat<T> where T: class, new()
    {

    }

    //Two generic types
    class GenericClass<T, K> where T : class, new() where K: struct
    {

    }

    //where constraint on Generic Methods
    class myTest
    {
        public void Swap<T>(ref T valueA, ref T valueB) where T : class
        {

        }
    }
}
