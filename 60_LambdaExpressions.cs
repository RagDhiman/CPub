using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Lambda Expressions
        ==================
        - Inline way of doing anonymous methods
        - Previously we saw how we can create a delegate anonymous method

        - Lists take a delegate type of "System.Predicate<T>" on the FindAll method ... basically it requires a method
        - And that method must return BOOL i.e. true for each item so that FindAll can return a subset from the List

        - Lambda expressions
            - Can be used anywere anonymous methods or delegate methods can be used
            -
    */
    class LambdaExpressions
    {
        List<string> mytest = new List<string>();
      
        public void Example()
        {
            //mytest.FindAll();

            /*
                Behind the scenes this is:
                --------------------------
                - public List<T> FindAll(Predicate<T> match);
                - match is a delegate type of Predicate<T>

                - And delegate type Predicate is defined as: (Looks farmiliar to 55_GenericDelegates :-) )

                - public delegate bool Predicate<in T>(T obj);

                - Conclustion is predicate is a delegate that can be assigned a method.. a lambda expression is an inline unanonmous
            */

            TraditionalDelegateSyntax(); // Very excessive you are left with METHOD thats only used for the method

            AnonymousMethodSyntax();

            LambdaSyntax();
        }

        #region TraditionalDelegateSyntax
            public void TraditionalDelegateSyntax()
            {
                // This is how you would use a delegate on a list i.e not using lambda expression

                //Create List
                List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6 };

                //Calling findall using traditional delegate
                Predicate<int> callBack = IsEvenNumber;
                List<int> evenNumbers = myList.FindAll(callBack);
            }

            static bool IsEvenNumber(int i)
            {
                return (i % 2) == 0;
            }
        #endregion

        #region AnonymousMethodSyntax
        public void AnonymousMethodSyntax() {

            //Create List
            List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<int> evenNumbers = myList.FindAll(
                    delegate (int i) 
                    {
                        return (i % 2) == 0;
                    }
                );
        }

        #endregion

        #region LambdaSyntax
        public void LambdaSyntax()
        {

            //Create List
            List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<int> evenNumbers = myList.FindAll(i=>(i%2)==0);
        }

        #endregion
    }
}
