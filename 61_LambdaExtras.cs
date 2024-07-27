using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class LambdaExtras
    {
        public static void Example()
        {

            //Functional Programming!

            //0. Our Data
            //===========

            List<string> myNames = new List<string> { "Bob", "Kev", "rag", "tyson" };

            //1. What are Predicates?
            //=======================

            var foundnames = myNames.Find(FindRagPredicate);

            //Predicates are basically delegates i.e. function pointers (this example uses a names method)

            //2. Evolution:   
            //==============
            //Anonymous Methods (So we dont have to write a named method, instead we write a delegate) this saves us from creating a names method everytime

            var foundnames2 = myNames.Find(
                    delegate (string s)
                    {
                        return s == "rag";
                    }
                );

            //3. Lambda: 
            //==========
            //Still uses anonymous types, is an evolution to 2: More stream lined version:
            //a. Get rid of the delegate keyword
            //b. Get rid of the type because compiler can work what the type out is!
            //c. Use lambda operator => (which basically means GO TO and is called GOTO)
            //d. Get rid of the extra brackets and semi columns

            var foundnames3 = myNames.Find(s => s == "rag");

            //4. Summary:
            //===========
            //Lamda expression is compact way of implementing an anonymous methods. Now compact are concise and ideal to use in link e.g:

            var foundnames4 = myNames.Where(s => s == "rag");

            //5. Another Example (Slightly less concise but same thing and now multi line, hence extra brackets). If you have more than one parameter you do to extra brackets#
            //if you lambdas do start going to long maybe NAMED method is better!

            var foundnames5 = myNames.Where(
                    (string s) =>
                    {
                        string temp = s.ToLower();
                        return temp == "rag";
                    }
                       );

            //6. Consuming a Lamdba?
            //Passing it in as a parameter to a method?
            //Storing it for use in several places?
            //This is where Func and Actions come in. These are delegate TYPES
            //You assign your lambda to a compatible delegate type (Func or Action)

            //7. Action Delegate Type:
            //Does not return a value basically methods that return a void

            Action printEmptyLine = () => Console.WriteLine();                                               //No prameters () and No return

            Action<int> printNumber = (x) => Console.WriteLine(x);                                           //Type of int is taken in, X type is derived from T

            Action<int, int> printTwoNumbers = (x, y) => Console.WriteLine(String.Format("{0} {1}", x, y));      //Type of int is taken in, X type is derived from T

            //Calling these Action Delegate i.e. Lambdas
            printEmptyLine();
            printNumber(1);
            printTwoNumbers(1, 2);

            //8. Func Delegate Type
            //Last paramter is always return type

            Func<DateTime> GetDateTime = () => System.DateTime.Now;

            Func<int, bool> ValidAge = (x) => x > 0;     //One parameter of int and return bool

            Func<int, int, int> multiply = (x, y) => x * y;

            //9. What are EXPRESSIONS?
            //LingToSQL cant see inside Func. Try Func in debugger and hovering over a func wont show u definition
            //Solution Expression types:
            //Expression is a special type, that treats code as data, it gives you an expression tree. Data that is required by remote data providers (e.g LinqToSQL)
            //it enables Data providers to see the logic

            Expression<Func<int, int, int>> multiply2 = (x, y) => x * y;

            //You invoke it differently, .Compile() will return the original Func

            int returnValue = multiply2.Compile().Invoke(2, 3);

            //.Compile returns the underlying Func:

            Func<int, int, int> multiply3 = multiply2.Compile();

            //10. In-memory LINQ VS Remote Linq (LinqToSql, edm etc)
            //IEnumerable works with LinkToObject
            //IQuerable can work Remote providers e.g LinqToSql
            //Defines extension methods that do not take delegates (i.e. Func, Action) but takes EXPRESSIONS. Hence why it works with LinqToSQL

            IEnumerable<string> foundnames10 = myNames.Where(s => s == "rag");      //Check definition of where, it returns IEnumerable and parameters it can take are delegates i.e. Func

            //LingToSql\LineToEDM would return IQuerable
            IQueryable<string> foundnames11 = ((IQueryable<string>)myNames).Where(s => s == "rag");     //Check definition of where, it returns IQuerable and parameters it can take are Expressions 
                                                                                                        //Remote data providers use IQuerable and Expressions etc so they can see code as data to create their queries!


        }


        #region 1. What are Predicates?

        static bool FindRagPredicate(string name)
        {
            return name == "rag";
        }


        #endregion
    }

}
