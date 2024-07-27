using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Strongly typed Query language to access data in XML, Lists, reflection data and databases

        Not simlar to SQL: Happens to look like it only
        Provides a way to query loads of data in objects in the code using QUERY EXPRESSIONS

        .Net enhancements that support Linq:
        - Implicitly typed local variables
            - Most LINQ queries return types that are only know at complie time: Having implicit "var" strongly-typed types is useful
            - However functions that need to return result of a linq might have to define a type: Use IEnumerable<T> or ToList i.e. imediate execution
        - Object and collection initilization syntax
            - Ability to init lists for example with a specified list coupled with anonymous types 
              allows linq to retried collection of data and set againt a local variable that becomes a collection
        - Lambda Expressions
            - Many Ling statements work using delegates (function pointer types): Lambdas allow you to pass in method logic in which in the background becomes a lambda
        - Extension methods
            - Loads of the LINQ method calls are actually extension methods
            - Example below QueryOverStrings: System.Array does not implement IEnumerable<T> directly.. when using link System.Linq.Enumerable
              Extends the type so that you have loads of IEnumerable methods on it like: First<T> and Max<T>. 
            -  System.Linq.Enumerable can be referenced also to provide a number of useful extension methods that help work on LINQ results
        - Anonymous types
            - Allow you do define the shape of a data without giving it a name or class: Again usefull for LINQ where we can place query data 
              into temp anonymous type. Linq uses proection to project data into a collection: For example LINQ on Clients projects ClientName 
              and Age as a collection in anon type

        Linq can be used in vairous places:
            - LINQ to Objects
            - LINQ to XML
            - LINQ to Dataset
            - LINQ to entities: Entity framework queries
            - Parrallel Linq: Parrallel processing of returned data

        Libraries required:
            - System.Linq
            - System.Core.dll
            - System.Data.DataExtensions
            - System.XML.Linq

        Deffered Execution
            - LINQ queries are not actually run when defined
            - They are run when you work on the output variable: Like using foreach
            - Advantage: You always get the latest results
            - You can hover over the result and evaluate the ResultsView to see results
            - You can force imediate execution using: ToString<>, ToArray<>
                    See example below

        C# Linq Operators:
            - from, in                          Extract values
            - where                             Filter values
            - select                            Sequence from container
            - join, on, equals, into            Used to perform joins between data. Note: Not like SQL joins
            - orderby, ascending, descending    Order returning data
            - group, by                         Group returning data

        System.Linq.Enumerable
            - As well as provding loads of extension methods: All C# Linq Operators queries actually translate to Enumerable methods in teh background
            - For example when you use WHERE that gets translated to .where() which takes a delegate func<>
            - Rememer Func<> is a delegate type that can have up to 16 parameters and a return value
            - Most of the enumerable methods require delegates: However its easier to use the C# Linq Operators instead of using the Enumerable equivalent methods
            - In the background they translate to the same
            - Feel free to use the System.Linq.Extension methods as much as you want
            - Enumerable method based linq queries chain the methods and have lambda expressions for func<> delegates. Allot harder to read and CODE!

                - So in summary:
                    1. Linq query expressions are creating using Linq Operators
                    2. Linq operators are a shorthand for extension methods on Syste.Linq.Enumerable
                    3. The long handed Enumerable methods that are equivalent: Take delegates as parameters Func<>()
                    4. Any method requiring a delegate parameter can instead be given a LAMBDA expression
                    5. Lambda expressions are basically ANONYMOUS methods
                    6. Anonymous methods are basically shorthand to manually build delegate target methods (i.e. normal methods)

    */
    class LinqToObjects
    {
        public void Example()
        {
            //First Simple example 
            QueryOverStrings();

            //Same again using IMPLICIT Type: LINQ's return type could be anything some types are even hiddn
            //You can convert to the lowest type in the heirarchy IEnumerable<T> but its not the actual type
            //Therefore it is recomended to use IMPLICIT TYPE where you can (If you need to do IEnumerable<T> or IQuerable<T> its fine!)
            QueryOverStringsUsingImplicitType();

            LinqImediateExecution();

            //Need result so using IEnumerable<T> instead of implicit type
            IEnumerable<string> resultFromLinq = FunctionReturningLinqResult();

            //Need result so use imediate execution
            List<string> myList = FunctionReturningLinqResultUsingImediateExecution();

            LinqOnGenericCollectionWithWhereClause();

            LinqOnNonGenericCollectionWithWhereClause();    //How to use Linq on NONGeneric collections

            LinqWithSubSetSelect();

            Array myObjects = LinqWithSubSetSelectForAnonymousType();   //As anonymous types are not known have to handle them as objects
            Console.WriteLine(myObjects.ToString());                    //we lose strongly type-ness

            //Ven type methods (Enumerable extension methods)
            //================
            LinqExceptDisplayDiff();        //Via Enumerable we have a number of extension methods like except to do ven type functionality
            LinqIntersectDisplaySame();

            LinqUnionDisplayDistinct();

            LinqConcatDisplayAll();

            LinqConcatwithDistinctDisplayDistinct();

            //Aggregation type methods (Enumerable extension methods)
            //================

            DoSomeAggregations();



        }

        private void DoSomeAggregations()
        {
            var myNumbers = new List<int> { 2,3,54,65,23,34,54,65};

            Console.WriteLine(myNumbers.Max().ToString());
            Console.WriteLine(myNumbers.Min().ToString());
            Console.WriteLine(myNumbers.Sum().ToString());
            Console.WriteLine(myNumbers.Average().ToString());



        }

        private void LinqConcatwithDistinctDisplayDistinct()
        {
            var myCars = new List<string> { "Ford", "Honda", "Peugoet" };
            var yourCars = new List<string> { "Ford", "Ferrari", "BWM" };

            var myNewCars = (from c in myCars select c).Concat(from c1 in yourCars select c1);  //All values including duplicates        

            foreach(var c in myNewCars.Distinct())
            {
                Console.WriteLine(c);
            }

        }

        private void LinqConcatDisplayAll()
        {
            var myCars = new List<string> { "Ford", "Honda", "Peugoet" };
            var yourCars = new List<string> { "Ford", "Ferrari", "BWM" };

            var myNewCars = (from c in myCars select c).Concat(from c1 in yourCars select c1);  //All values including duplicates
        }

        private void LinqUnionDisplayDistinct()
        {
            var myCars = new List<string> { "Ford", "Honda", "Peugoet" };
            var yourCars = new List<string> { "Ford", "Ferrari", "BWM" };

            var myNewCars = (from c in myCars select c).Union(from c1 in yourCars select c1);
        }

        private void LinqIntersectDisplaySame()
        {
            var myCars = new List<string> { "Ford", "Honda", "Peugoet" };
            var yourCars = new List<string> { "Ford", "Ferrari", "BWM" };

            var myNewCars = (from c in myCars select c).Intersect(from c1 in yourCars select c1);
        }

        private void LinqExceptDisplayDiff()
        {
            var myCars = new List<string>{"Ford","Honda","Peugoet"};
            var yourCars = new List<string> { "Ford", "Ferrari", "BWM" };

            var myNewCars = (from c in myCars select c).Except(from c1 in yourCars select c1);

        }

        private Array LinqWithSubSetSelectForAnonymousType()
        {
            var myBikes = GetBikeGenericList();

            var bikesOverMaxSpeed = from b in myBikes
                                    where b.Speed >= b.MaxSpeed
                                    && b.Speed > 0
                                    select new { b.Model, b.Manufacturer }; //  Anonymous Type ***

            return bikesOverMaxSpeed.ToArray(); //We cant use generic here becuase we dont know type. We have to handle it as array of system.objects!
        }

        private void LinqWithSubSetSelect()
        {

            var myBikes = GetBikeGenericList();

            IEnumerable<String> bikesOverMaxSpeed = from b in myBikes
                                    where b.Speed >= b.MaxSpeed
                                    && b.Speed > 0
                                    orderby b.Model descending    //we are also ordering here.. ascending is default if not specified
                                    select b.Model; //Select b is similar to Select *
        }

        private IEnumerable<Bike> LinqOnGenericCollectionWithWhereClause()
        {
            var myBikes = GetBikeGenericList();

            var bikesOverMaxSpeed = from b in myBikes
                                    where b.Speed >= b.MaxSpeed
                                    && b.Speed > 0
                                    select b; //Select b is similar to Select *

            return bikesOverMaxSpeed.Reverse();    //Because of extension methods we can reverse
        }

        private void LinqOnNonGenericCollectionWithWhereClause()
        {
            //Non generic collections have an extension method which returns them as IEnumerable<T>

            //NonGeneric Collections like ArrayList can contain objects of many types
            //OfType<Bike>() can be used to return just specific type

            var myBikes = GetBikeNonGenericList();

            var myBikesEnumerable = myBikes.OfType<Bike>(); //Return as IEnumerable of T.. i.e. only objects of type T .. anything else fitler out

            var bikesOverMaxSpeed = from b in myBikesEnumerable
                                    where b.Speed >= b.MaxSpeed
                                    && b.Speed > 0
                                    select b;   //Select b is similar to Select *
        }


        private List<string> FunctionReturningLinqResultUsingImediateExecution()
        {
            string[] CurrentVideoGames = { "Fallout 4", "StarWars Battlefront", "COD 3", "Mortal Kombat", "Hardline" };

            return (from g in CurrentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g).ToList();

        }

        private IEnumerable<string> FunctionReturningLinqResult()
        {
            string[] CurrentVideoGames = { "Fallout 4", "StarWars Battlefront", "COD 3", "Mortal Kombat", "Hardline" };

            IEnumerable<string> subset = from g in CurrentVideoGames
                         where g.Contains(" ")
                         orderby g
                         select g;

            return subset;
        }

        public void QueryOverStrings()
        {
            string[] CurrentVideoGames = {"Fallout 4","StarWars Battlefront","COD 3","Mortal Kombat","Hardline"};

            IEnumerable<string> subset = from g in CurrentVideoGames    //Deffered Execution: Not actually run here
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            CurrentVideoGames[0] = "test"; //Because of deffered execution you will see this change at the end

            foreach (string s in subset)    //Executed here
                Console.WriteLine(s);
        }

        public void QueryOverStringsUsingImplicitType()
        {
            string[] CurrentVideoGames = { "Fallout 4", "StarWars Battlefront", "COD 3", "Mortal Kombat", "Hardline" };

            //implicit type "var"
            var subset = from g in CurrentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            //implicit type "var"
            foreach (var s in subset)
                Console.WriteLine(s);
        }

        public void LinqImediateExecution()
        {
            string[] CurrentVideoGames = { "Fallout 4", "StarWars Battlefront", "COD 3", "Mortal Kombat", "Hardline" };

            //implicit type "var"
            var subset = (from g in CurrentVideoGames
                         where g.Contains(" ")
                         orderby g
                         select g).ToList();    //To List forces execution sametime

            //implicit type "var".. Linq not executed agian because you forced imediate exection and now you are working on output
            foreach (var s in subset)
                Console.WriteLine(s);
        }

        public List<Bike> GetBikeGenericList()
        {
            return new List<Bike>
            {
                new Bike { Manufacturer="Honda",Model="H23",Speed=34,MaxSpeed=120},
                new Bike { Manufacturer="BMW",Model="B34",Speed=10,MaxSpeed=120},
                new Bike { Manufacturer="DUCATI",Model="D23",Speed=65,MaxSpeed=120},
                new Bike { Manufacturer="YAMAHAH",Model="Y45",Speed=77,MaxSpeed=120},
                new Bike { Manufacturer="VW",Model="V23",Speed=75,MaxSpeed=120}
            };
        }

        public ArrayList GetBikeNonGenericList()
        {
            return new ArrayList()
            {
                new Bike { Manufacturer="Honda",Model="H23",Speed=34,MaxSpeed=120},
                new Bike { Manufacturer="BMW",Model="B34",Speed=10,MaxSpeed=120},
                new Bike { Manufacturer="DUCATI",Model="D23",Speed=65,MaxSpeed=120},
                new Bike { Manufacturer="YAMAHAH",Model="Y45",Speed=77,MaxSpeed=120},
                new Bike { Manufacturer="VW",Model="V23",Speed=75,MaxSpeed=120}
            };
        }
    }

    class Bike
    {
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return String.Format("The bike has a speed of {0} and max speed of {1} and manufacturer {2} and the model is {3}", Speed, MaxSpeed,Manufacturer, Model);
        }

    }
}
