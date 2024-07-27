using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Example of Generic Structure that has type T
        Note in the reset method we are using DEFAULT keyword which set the default value for a type
    */

    public struct Point<T>
    {
        private T XPos;
        private T YPos;

        public Point(T x, T y)
        {
            XPos = x;
            YPos = y;
        }

        public T X
        {
            get { return XPos; }
            set { XPos = value; }
        }

        public T Y
        {
            get { return YPos; }
            set { YPos = value; }
        }

        public void reset()
        {
            XPos = default(T);  // DEFAULT KEYWORD
            YPos = default(T);
        }
    }
}
