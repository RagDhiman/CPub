using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Casting
    {
        public void Exmaple()
        {
            /*
            Implicit cast
            =============
            Derived classes can always be casted back to parent "implicit cast"
            */
            Shape TriangleShape = new Triangle();
            HandleShape(TriangleShape);

            //Remember everything is based on System.Object and therefore we can implicit cast to it
            Object TriangleObject = new Triangle();
            //HandleShape(TriangleObject); doesnt work because it expects Shape

            /*
            Expicit downcast
            =================
            ** Warning about explicit downcasting
            Not evaluated at compiletime .. evaluated at run time and therefore can error at runtime if NOT compatible time
            */        
            HandleShape((Shape)TriangleObject);

            //Use try and catch to handle explicit downcast errors


            /*Cast check using AS
            ===================*/
            Shape Triangle = TriangleObject as Shape;
            if (Triangle != null)
            {
                Console.WriteLine("Cast to shape successfull");
                HandleShape((Shape)TriangleObject);     //no need to try and catch because we know type is compatible
            }
            else
            {
                Console.WriteLine("Cast to shape failed!");
            }

            /*Cast check using IS
            ===================*/
            if (TriangleObject is Shape)
            {
                Console.WriteLine("Is Shape");
                HandleShape((Shape)TriangleObject);     //no need to try and catch because we know type is compatible
            }
            else
            {
                Console.WriteLine("Is not shape");
            }
        }

        public void HandleShape(Shape shapeToBeHandled)
        {

        }
    }
}
