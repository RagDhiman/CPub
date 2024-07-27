using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class ObjectInitilization
    {
        public void Example()
        {

            //Object initilization syntax
            var myCar = new Car { CarName = "Test", EngineSize = 22 };

            //Whats happening here? Default constructor called then properties are set: Same as:
            //Above object init sytax is actually same as

            var yourCar = new Car();
            yourCar.CarName = "Test";
            yourCar.EngineSize = 22;

            //Forcing another constructor
            var theirCar = new Car("Ferrari","360") { CarName = "f40", EngineSize = 22 };

            //same as

            var otherCar = new Car("Ferrari", "360");
            otherCar.CarName = "f40";
            otherCar.EngineSize = 22;

            //You could embed initilization syntax within eatch other
            //var triangle = new triangle {StartingPoint = new Point{X = 23, Y=34}}
        }
    }
}
