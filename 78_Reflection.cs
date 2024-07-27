using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSharp6Net46._2_CSharpAdvanced
{
/*
    Reflection
    ----------
    - Tools like ildasm.exe allow you to peak inside assemblies and see information about types, metadata and manifests
    - System.Reflection allows you to do the same!
    - Reflection basically allows you to access all the .net metadata
    - Serilization and IDE Intellisense all rely on metadata for types
    - Metadata for a type includes everything .. fields, method, interfaces, parameters and enumeration definitions.. YOu name it!
    - Using ildasm.exe and Reflection you can easily view everything.. including every string
            - Do not code passwords or other security sensitive information within the code!
    - Reflection is runtime type discovery using friendly object model
    - Key members of System.reflection (Name suggests what the handle or work with)
        - Assembly
        - AssemblyName
        - EventInfo
        - FieldInfo
        - MemberInfo
        - MethodInfo
        - Module
        - ParameterInfo
        - PropertyInfo

    System.Type
    -----------
    - Defines a number of members that return a types info from metadata using types from System.Reflection (see list above)
    - For example Type.GetMethods() returns an array of MethodInfo objects

    - List of System.Type members:
        - IsAbstract
        - IsArray
        - IsClass
        - IsComObject
        - IsEnum
        - IsGenericTypeDefinition
        - IsGenericParameter
        - IsInterface
        - IsPrimitive
        - IsNestedPrivate
        - IsNestedPublic
        - IsSealed
        - IsValueType
        - GetConstructors()         -- Gets from here return items using names and dont return arrays
        - GetEvents()
        - GetFields()
        - GetInterfaces()
        - GetMethods()
        - GetMembers()
        - GetNestedTypes()
        - GetProperties()
        - FindMembers()
        - GetType()                 -- For given string name it returns the type
        - InvokeMember()            -- Allows for latebinding

    How to obtain System.Type to give you this information for a specific Object
        - System.Type() is an abstract class you cannot create an instance using "new"
        - Option 1: All objects are based on System.Object and Object has a method called GetType() which will give you an instance of System.Type()
                    For current object. See example below
                    - Prob: You need know the type you want to investigate and you must have an instance of it
        - Option 2: Is to use Typeof() operator
                    Pro: You dont have to have an instance of the object to get a type object
                    Con: You still need to know the type
        - Option 3: Use static method System.Type.GetType() using the String name of the type
                    Pro: You dont need instance of object or strongly typed name at compile time
                    Pro: Two parameters: One to say not to throw exception if type not found.. Other is string name case sensitive
                    Pro: You can use full name references to get type info from external assemblies
                    Pro: You can use + to access nested types
*/

    class MetaDataUsingReflection
    {
        public void Example()
        {
            //Option 1
            //--------
            //All objects are based on System.Object and Object has a method called GetType() which will give you an instance of System.Type()
            //Getting an instance of System.Type (to retrieve metadata info) from an object instance
            //Using System.Object method of GetType()
            Square myShape = new Square(2);
            Type T = myShape.GetType();

            //Option 2
            //--------
            //Is to use Typeof() operator
            //Getting an instance of System.Type (to retrieve metadata info) from a type
            //Note: No instance of an object required! However you still need to know the type
            Type T1 = typeof(Square);

            //Option 3: 
            //--------
            //Use static method System.Type.GetType() using the String name of the type
            Type T2 = System.Type.GetType("Square",false,true);
            //To obtain type for a type from an external assembly
            Type T3 = System.Type.GetType("Assembly.NameSpace.Square", false, true);
            //To obtain a type for a nested type use the +.. could be for eample a enum type you need info on!
            Type T4 = System.Type.GetType("Assembly.NameSpace.Square+NestedType", false, true);
            //Anything with a generic you would have to include a back tick ` followed by the number of T values
            //For example:             System.Collections.Generic.List<T>
            Type T5 = System.Type.GetType("System.Collections.Generic.List`1", false, true);
            //For example:             System.Collections.Generic.Dictionary<T,Y>
            Type T6 = System.Type.GetType("System.Collections.Generic.Dictionary`2", false, true);


        }

        public static void TypeReflection()
        {
            string typename = "";

            do
            {
                Console.WriteLine("\nEntry type you want to detail using refelection");
                Console.WriteLine("or enter Q to quit");

                typename = Console.ReadLine();

                if (typename.ToUpper() == "Q")
                {
                    break;
                }

                try
                {
                    Type T = Type.GetType(typename,true,true);
                    printTypeDetails(T);
                }
                catch (Exception e)
                {
                    Console.WriteLine("**** Error ****");
                    Console.WriteLine("Method or Property Name: {0}", e.TargetSite);
                    Console.WriteLine("Method or Property: {0}", e.TargetSite.MemberType);
                    Console.WriteLine("Class: {0}", e.TargetSite.DeclaringType);
                    Console.WriteLine("Message: {0}", e.Message);
                    Console.WriteLine("Source: {0}", e.Source);
                    Console.WriteLine("Stack: {0}", e.StackTrace);

                    Console.WriteLine("Help Linke: {0}", e.HelpLink); Console.WriteLine("Sorry Type not found!");
                }
            } while(true);
        }


        public static void printTypeDetails(System.Type T)
        {
            ListMethods(T);
            ListFields(T);
            ListProps(T);
            ListVariousStats(T);
        }

        public static void ListMethods(System.Type T)
        {
            Console.WriteLine("---- Get methods ----");
            var mis = from n in T.GetMethods()
                              select n;

            foreach (var mi in mis)
            {
                Console.WriteLine("--> Method name {0}", mi.Name);
                Console.WriteLine("   Method return type {0}", mi.ReturnType.Name);
                foreach (ParameterInfo p in mi.GetParameters())
                {
                    Console.WriteLine("   Parameters: {0} {1}", p.Name, p.ParameterType.Name);
                }
            }

            Console.WriteLine();

        }

        public static void ListFields(System.Type T)
        {
            Console.WriteLine("---- Get Fields ----");
            var fieldNames = from f in T.GetFields()
                              select f.Name;

            foreach (var fname in fieldNames)
                Console.WriteLine(fname);

            Console.WriteLine();

        }

        public static void ListProps(System.Type T)
        {
            Console.WriteLine("---- Get Properties ----");
            var propNames = from P in T.GetProperties()
                             select P.Name;

            foreach (var name in propNames)
                Console.WriteLine(name);

            Console.WriteLine();

        }

        public static void ListInterfaces(System.Type T)
        {
            Console.WriteLine("---- Get Interfaces ----");
            var InterfaceTypes = from I in T.GetInterfaces()
                            select I;

            foreach (Type I in InterfaceTypes)
                Console.WriteLine(I.Name);

            Console.WriteLine();

        }

        public static void ListVariousStats(System.Type T)
        {
            Console.WriteLine("--- Various Stats ---");
            Console.WriteLine("Base class is {0}", T.BaseType);
            Console.WriteLine("Type is abstract {0}", T.IsAbstract);
            Console.WriteLine("Type is sealed {0}", T.IsSealed);
            Console.WriteLine("Type is generic {0}", T.IsGenericTypeDefinition);
            Console.WriteLine("Type is class {0}", T.IsClass);
            Console.WriteLine();
        }
    }
}
