using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class PassingRefTypeAsValueType
    {
        public static void ReferenceTypeAsValueType(Person p)
        {
            //Omission of OUT or REF means its passed in as ValueType
            //Note the it still always reference pointer to same object so call code will see this change:

            p.personName = "Rag";
            p.personAge = 35;

            //If a reference type is passed in as a value type
            //we can change values within that object
            //however we cannot change what object the calling code is pointing at
            //So change p to this will not be seen by calling code:
            p = new Person("Schumacher", 26);
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personAge = age;
            personName = name;
        }
    }
}
