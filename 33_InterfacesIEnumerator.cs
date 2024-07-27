using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{

    /*
        Example of IEnumerator implementation

        Note how YIELD iterator can be used to cache and return a IEnumerable of anything: You can then have multiple methods that return Iterators foreachs
    */

    class InterfacesIEnumerator
    {
        public void Example()
        {
            var myGarage = new Garage();

            foreach(Car c in myGarage) {
                Console.WriteLine("{0}",c.CarName);
            }

            foreach (Car c in myGarage.CarsLike("F"))
            {
                Console.WriteLine("{0}", c.CarName);
            }
        }

        public class Garage : IEnumerable
        {
            public Car[] cars { get; set; } = new Car[4];

            public Garage()
            {
                cars[0] = new Car("Ferrari", "F40");
                cars[1] = new Car("Williams", "W21");
                cars[2] = new Car("Merc", "M23");
                cars[3] = new Car("BMW", "B213");
                cars[4] = new Car("Toyota", "TR23");

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return cars.GetEnumerator();
            }

            public IEnumerable CarsLike(String like)
            {
                foreach (Car c in cars)
                {
                    if(c.CarName.Contains(like))
                    {
                        yield return c;
                    }
                }

                yield return null;
            }
        }


    }
}
