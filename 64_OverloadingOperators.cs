using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Operator overloading
        ====================
        i.e. overloading + - * \ etc and manymore! Shorthands i.e. += -+ are atomatically done once you have done the + - etc
        You define what happens when YourObject + AnythingElse
        See examples below

        Make sure you operator overloading makes sense Point+Point makes sense. F1Car + F1Car doesnt!
    */

    class OverloadingOperators
    {
        public static void Example()
        {
            Point p1 = new Point(10, 20);
            Point p2 = new Point(5, 15);

            var p3 = p1 + p2;

            Console.WriteLine("P3.... X={0} and Y={1}",p3.X, p3.Y);

            p3 += p1;

            Console.WriteLine("P3.... X={0} and Y={1}", p3.X, p3.Y);

            var p4 = p1 + 100;

            Console.WriteLine(" p4.... X={0} and Y={1}", p4.X, p4.Y);

            p4++;

           // remember ++p4 vs p4++ .... pre and post apply in expression

            Console.WriteLine(" p4.... X={0} and Y={1}", p4.X, p4.Y);
        }
    }

    class Point: IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        //Operator overloads to add two point types together
        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p2.X + p1.X, p2.Y + p1.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p2.X - p1.X, p2.Y - p1.Y);
        }

        //Operator overloads to add two point types together
        public static Point operator +(Point p1, int change)
        {
            return new Point(p1.X + change, p1.Y + change);
        }

        public static Point operator -(Point p1, int change)
        {
            return new Point(p1.X - change, p1.Y - change);
        }

        //Unary Operators overloads to add two point types together
        public static Point operator ++(Point p1)
        {
            return new Point(p1.X+1, p1.Y+1);
        }

        public static Point operator --(Point p1)
        {
            return new Point(p1.X - 1, p1.Y - 1);
        }

        //Overloading the equals operators == != etc.
        //Rember if you override euals you also have to override GetHashCode
        public override bool Equals(object obj)
        {
            return this.ToString() == this.ToString();    
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        //Comparers
        // First implement IComparable
        // Then override operators

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
                return 1;
            if (this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }

        public static bool operator >(Point p1, Point p2)
        {
            return p1.CompareTo(p2) > 0;
        }

        public static bool operator <(Point p1, Point p2)
        {
            return p1.CompareTo(p2) < 0;
        }

        public static bool operator >=(Point p1, Point p2)
        {
            return p1.CompareTo(p2) >= 0;
        }

        public static bool operator <=(Point p1, Point p2)
        {
            return p1.CompareTo(p2) <= 0;
        }
    }
}
