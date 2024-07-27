using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    /*
        Interfaces
        ==========
        Define behaviour\role for a class: Like abstact classes but no implementations
        Class can have multiple behaviours\roles

        For e.g. ADO.Net you have SQLConnection and ODBCConnection and implement IDBConnection
        You can have thirdy-party dlls that provide connection objects that connect to other DB's (SQL Lite etc)
        These connection objects are in different projects\assemblies but they work with ADO.net because they follow IDBConnection

        Convention to prefix your interfaces with "I"

        Following .Net interfaces you can create classes that integrate with the framework

        Structures can also have interfaces

        Interfaces vs Abstract classes
        ==============================
        - Abstract classes can define constructors and implementations for methods: As well as providing a ploymorphic interface
        - Interfaces only provide member definitions: Classes can also have multiple interfaces but only one abstract class inheritance
                - Interfaces can also be defined in seperate assemblies and namespaces to their actual implementaitons
                - Making them highly polymorphic

        For example a number of different .net types implement IClonable which requires each to implement .Clone() all can be treated as 
        IClonable and clonned using .Clone. Making them highly polymorphic

        If you have a need to implement a specific method for an implementation, 
        placing it within the abstract class will force all derived classes to implment the method when its specific to some classes
        This is where its best to place the method with an interface and have the specific classes that implment that logic follow that interface

        Creating Customer Interfaces
        ============================
        By default you dont specify access modifier on interface memebers. All are public be default (wouldnt make sense if they werent)
        Interfaces cant have base classes but they can have a base interface
        Interfaces dont have data members
        Interfaces dont have constructors
        Interfaces dont have implementation
        Interfaces can contain events and or indexers
        Must alway provide impementation for all members of an interface

        Implementing Interraces
        =======================
        After class name: Base classes first and then any interfaces seperated by comma
        Must alway provide impementation for all members of an interface

        Checking for interface support
        ==============================
        Expilict cast to interface: If not supported it would throw an exception. Could handle using try\catch... but not ideal way!

            AS
            ==
            Returns refernce to object if class supports interface. Wont throw exception if it doesnt support it

            IS
            ==
            Returns true if class support specified interface

           
        Explicit Interface Implementionation
        ====================================
        Class implements two interfaces that have overlapping members(properties or methods)
        1. Prefix the method or property with the interface name 
            - For example " void IPoint.GetNumberOfPoints()" in the class
            - You cant specify access modifier because these members become PRIVATE by default
            - Object instance cant access them: You can only access them when you cast the class to the interface
            - ((IPointy)myShape).GetNumberOfPoints()  -- Now it knows what interface implementaiotn you want
            - Can also be used as a way just to hind members at object instance level.. to access you have to cast to interface

            - Instead of creating an explicit member for each implementation: You could always have one method or property which covers all overlapping interfaces
        
        Interface Heirarchies
        =====================
        - Interface inherits from another interface
        - All this does is extend the interface to have additional abstract members from the interface they are inheriting form
        - See example below. The class that implments the derived interface also has to implement the parent interface
        
        Interfaces are useful when
            In a hierarchy only a subset of the derived classes support a common behaviour
            You need to model a common behaviour across multiple heirarchies that dont share a common parent

    */
    class InterfacesExample
    {
        public void Example()
        {
            var myRectangle = new Rectangle();

            //AS
            IPointy myPointy = myRectangle as IPointy;
            if (myPointy != null)
            {
                Console.WriteLine("myRectangle does not support IPoints");
            } else
            {
                Console.WriteLine("myRectangle does support IPoints");
            }

            //IS
            if (myRectangle is IPointy)
            {
                Console.WriteLine("myRectangle does support IPoints");
            }
            else
            {
                Console.WriteLine("myRectangle does not support IPoints");
            }
        }

        public IPointy ReturnShapeAsIpointy(Shape myShape)
        {
            if(myShape is IPointy)
            {
                return myShape as IPointy;
            }
            return null;
        }

    }

    class Rectangle : Shape, IPointy
    {
        public byte points
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public byte GetNumberOfPoints()
        {
            throw new NotImplementedException();
        }
    }

    public interface IPointy: ICloneable
    {
        byte points { get;} //Read-only propert

        byte GetNumberOfPoints();
    }


}
