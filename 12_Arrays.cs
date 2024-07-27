using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Arrays
    {
        public static object[] Example()
        {
            //You can have an array of any type (primitive or objects)
            //Arrays are 0 indexed based
            //If value not set on an element: That element has the default for that type
            int[] myInts = new int[3];
            myInts[0] = 10;
            myInts[1] = 10;
            myInts[2] = 10;

            int[] myIntsArrayTwo = new int[] {11,12,13 }; //init with values
            string[] myIntsString = new string[] { "One", "Two", "Three" }; //init with values

            //without the new keyword
            bool[] myBoolArray = { false, true, false }; //size is inffered

            int[] myIntArrayTwo = new int[4] { 1,2,3,4};

            //implicit type
            var b = new[] { 1, 2, 3, 4 };               
            var c = new[] { "One", "Two", "Three" };
            //var d = new[] { 1, "Two", "Three" };      Generates an error as you cant use MIXED types

            //Object type array
            //Elements can be of any type that inherits from system.object which is nreally all types
            object[] myObjectsArray = new object[5];
            myObjectsArray[0] = 1;
            myObjectsArray[1] = "test";
            myObjectsArray[2] = new DateTime(2015,11,01);
            myObjectsArray[3] = new FormatException();
            myObjectsArray[4] = false;

            foreach(object o in myObjectsArray)
            {
                Console.WriteLine("Type:{0} Value{1}", o.GetType(), o);
            }

            //Multidimension array
            int[,] myMultiDimArray = new int[3,4];

            for(int i = 0; i < 3; i++)
                for (int h = 0; h < 4; h++)
                    myMultiDimArray[i, h] = 100;


            //Jagged Multidimension array  i.e. an array of arrays
            //Normal MD Array has elements that are arrays of the same size
            //Jagged MD array can have each element that is an array of a different size
            int[][] myJaggedArray = new int[5][];
            myJaggedArray[0] = new int[3];
            myJaggedArray[2] = new int[20];

            return myObjectsArray;

        }
    }
}
