using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Converting between types:
        =========================

        Implicit conversion: Small type into a large type where data loss does not occur and derived class to base class

        Explicit conversion: Large type into small type. Where data loss can occur and you have to tell the compiler i know what im doing
                             BaseClass to derivedClass: Data loss can occur if base type was actually something else then the explicit derived

        Custom conversion: Where to types no related by heirarchy need to be converted: For example Rectangle to square (Assume conversion cannot happen using a parent!)
                           Using Implicit and Explicit keywords.. see below
                                - Its illegal do define implicit and explicit conversion on the same type if return parameter and input parameters are the same
                            
                           
        Remember just because you can create explict cast conversions doesnt mean you use them will nilly!
    */

    class CustomTypeConversions
    {
        public void Example() {

            //Implicit Conversion
            int SmallTypeValue = 10;
            long LargeTypeValue;

            LargeTypeValue = SmallTypeValue;

            //Explicit Conversion
            SmallTypeValue = (int)LargeTypeValue;   //Without cast this will not compile

            //Implicit Conversion using type hierarchies (derived class to base class)
            Shape myBaseType;
            myBaseType = new Triangle();

            //Explicit Conversion using type hierarchies (base class to derived class) //Data loss still could occur for example myBaseType was actually a SQUARE
            Triangle myDerivedType = (Triangle)myBaseType;

            //Explicit custom conversion "Rectangle to Square"
            Rectangle myRectangle = new Rectangle(34, 33);
            Square mySquare = (Square)myRectangle;          //Wow

            DrawSquare((Square)myRectangle);    //Use explicit custom conversion cast i can also pass rect into a function that requires square

            //Explicit custom conversion "Square to int"

            int myInt = (int)mySquare;

            //Customer Explicit Conversion "Int to Square".. You wouldnt really do this as you have a consturtor to create square from int
            Square mySquareFromInt = (Square)23;
            Square mySquareFromIntTwo = (Square)myInt;

            //Implicit conversion "Rectangle to square" see code below
            myRectangle = mySquare;
        }

        private void DrawSquare(Square mySquare)
        {
            //draw
        }
    }

    public class Square
    {
        public int Length { get; set; }

        public Square(int l)
        {
            Length = l;
        }

        //Customer Explicit Conversion "Rectangle to Square"
        //Has to be static
        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square(r.Height);
            return s;
        }

        //Customer Explicit Conversion "Square to int"
        //Has to be static
        public static explicit operator int(Square s)
        {
            return s.Length;
        }

        //Customer Explicit Conversion "Int to Square"
        //Has to be static
        public static explicit operator Square(int len)
        {
            Square s = new Square(len);
            return s;
        }
    }

    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h)
        {
            Width = w; Height = h;
        }

        //Customer Implicit Conversion "Square to Rectangle"
        //Has to be static
        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle(s.Length*2,s.Length);   //Assumption width for rect is always height*2
            return r;
        }
    }
}
