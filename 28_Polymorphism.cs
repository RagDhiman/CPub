using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46
{
    /*
            Polymorhism
            ==============
            Treat related objects in a similar manner
            Subclasses override methods inherited from parents with their own implementation
            Client classes still treat all classes the same i.e. call the method thats overrident
            Triangle, Square and Circle all inherit from Shape: Client code could treat all three as Shape
            Client code could call .Draw on all and each will have its own way of drawing
            Array of type shape: each element could be concrete of traingle, circle or square

            Polymorhism provides a mechanism to override an inherited method
            Using the virtual word you can state a method maybe overriden: Does not have to but can

            Virtual and Overriden keywords

            IDE Shortcut: Type override and then space to see a list of overridable methods

            Note: You can stop further children down the hierarchy from overriding a method by using sealed keyword see below

            Abstract classes
            ================
            Sometimes you have base classes that by them selves do not require instantiation 
            These are base classes which are just there to reuse members and code that are common between related classes
            To prevent people from creating instances of these classes: Make them ABSTRACT
            Example below you wouldnt ahve a shape in the code you would have a specific type of shape and therefore shape is 
            really an abstract class

            Abstract methods
            ================
            Defined in the base class: to force derived classes to implement the logic

            polymorphic interface
            =====================
            All objects with a base of shape can be handled as a shape
            For example we can have an array of type shape where each object is actually a subtype (triangle, square and circle etc)
            Remember we cant have shape instances because its abstract
            We can then call draw on all the objects in the shape type array because they all have the same polymorphic interface

            Member shadowing
            ================
            What if you cant change the base class (third party dll etc)
            and you need to override a method but cant make it virtual at base level
            This is where you shadow the member using the NEW keyword
            See below NonVirtualMember... a method from base thats not virtual
            Using NEW we can override it in the child class

            You can apply new TO FIELDS, Constants, statics, properties and methods

            WARNING: Explicit cast to parent can still excute parent implementations
    */

    abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public void NonVirtualMethod()
        {
        }

        //Overridable method
        public virtual void Describe()
        {
            Console.WriteLine("This is a shape that has X and Y coordinates as well as width and height!");        
        }

        public abstract void Draw();    //Derived\Child class must provide implementation for this
    }

    class Triangle: Shape
    {
        public new int X { get; set; } //Using new we can override parent property without making parent property virtual (useful for when we cant change BASE!)


        public override sealed void Describe()      //We override parent method and seal it so Triangles children cant override it!
        {
            base.Describe();
            Console.WriteLine("Specifically this is a shape with three sides known as a triangle");
        }

        public override void Draw()
        {
            //Logic to draw a triangle
        }

        public new void NonVirtualMethod()
        {
        }
    }
}
