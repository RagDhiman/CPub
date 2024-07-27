using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    /*

        1. Encapsulation
        =================
            Hiding details within objects
                For e.g. database class that has open and close methods: Objects hides the details of connecting to db i.e. encapsulates
            Protecting state of objects
                Properties which represent the state of a specific object can be queried by and protected from clients

        2. Inheritance
        ==============
            Creating new class definitions based on existing classes
            Child class of parent class
            The "is a" relationship: Triangle class is a Shape (parent class)
            Code Reuse: Inherit properties and methods from parent

        3. Polymorhism
        ==============
            Treat related objects in a similar manner
            Subclasses override methods inherited from parents with their own implementation
            Client classes still treat all classes the same i.e. call the method thats overrident
            Triangle, Square and Circle all inherit from Shape: Client code could treat all three as Shape
            Client code could call .Draw on all and each will have its own way of drawing
            Array of type shape: each element could be concrete of traingle, circle or square

    */

    class OOPrinciples
    {
    }
}
