using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class ValueTypeVsReferenceType
    {
        //Stack Vs Garbage collected Heap
        //Value Types go on STACK
            // System.ValueType
            // Short life time: Whilst in scope they are alive else memory is freed
            // Existing structure type variable can be assigned to another variable
            /// Both will be indepently changeble: Because new copy is a new object on stack
        //Reference Types go on HEAP
            // Can hang around even when out of scope: Garbage collection kicks in an clears unreferenced objects
            //if you two reference typed objects like classes
            //and you assign p1 to p2
            //Chaneges to p1 will also affects p2 (changing: properties etc)
        //What if ValueType (Structure) contains a reference type (string or class)
            //If you create a copy of the value type (shallow copy) both objects will point at the same reference type
            //If you deep copy using IClonable: The internal reference type is recreated as a new object in the value type

    }
}
