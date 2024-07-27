using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Anonymous Types
        ===============

        Sometimes you need a type that you need to hold data so that you can pass it to a few methods
        A permanent class might be OT for the data class. It'll be another class to maintain thats actually only used few times

        Lets youw whip up a data type quickly with bare bones encapsulation

        Anon Types also implement GetHashCode() which is a unique value generated from number of properties and their values
        HashCode is used for comparison: So if you have to anon types with same values nad properies they would compare the same
        - Howvever .Equals() will return true if properties and values are the same
        - == will not return true even if props and values are same as it compares memory references
        - .TypeName would be the same for two types with same props and values

        Therefore if you create multiple anon types using same props and values in the background compiler only actually generates one class

        You can also have anon types within anon types

        Should ONLY really use anon types when using LINQ:
            - You cant name anon types
            - They extend System.object
            - All properties are readonly
            - Dont support methods, operators or overrides
            - always use default constructor
            - always sealed

        This is where Anonymous types come in :-)
    */

    class AnonymousTypes
    {
        public void Example()
        {
            //Creating an Anon type
            var car = new { Make="Ferrari", NumberOfWeeks=200, DateCreated=System.DateTime.Now};

            //Using property data on anon type
            Console.WriteLine("{0} created on {1}",car.Make, car.DateCreated.ToString());

            //Even tostring works because anon type inherits from System.Object
            Console.WriteLine(car.ToString());
        }
    }
}
