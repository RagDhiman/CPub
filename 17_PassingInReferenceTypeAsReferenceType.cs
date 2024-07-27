using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class PassingInReferenceTypeAsReferenceType
    {
            public static void ReferenceTypeAsRefType(ref Person p)
            {
                //Reference type passed in as Ref Type

                //Calling Code will see this change
                p.personName = "Rag";
                p.personAge = 35;

                //If a reference type is passed in as a ref type
                //we can change values within that object
                //and we can also change what object the calling code is pointing at
                //for example we can create a new object and assign that reference
                //and the calling code reference will also change to this new object!
                p = new Person("Schumacher", 26);
                Console.ReadLine();
            }
    }
}
