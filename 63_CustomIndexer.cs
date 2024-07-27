using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CSharp6Net46._1_CSharpBasics;


namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Custom Indexer
        ===============
        - Giving your collection classes the ability to access collection members using an indexer []
        - For example: CarCollection[0] to set or retrie the first car from collection
        - You can do this on your NonGeneric Collection (legacy) or your Generic Collection (what you should be using)

        - Note you can also overload indexers i.e. more than one with different parameter types and logic
        - You can also have multidimension indexers DataTable[2,3] used to ref column and row
    */

    class CustomIndexer
    {
        public static void Example()
        {
            //NonGeneric Example (legacy)
            var CarCollectionOne = new CarCollection_NonGeneric();
            CarCollectionOne[0] = new Car("Williams","SD40");
            Console.WriteLine(CarCollectionOne[0].CarName);

            //Generic Collections give you indexers for free (these are what you should be using)
            List<Car> CarCollectionTwo = new List<Car>();
            CarCollectionTwo.Insert(0,new Car("Ferrar", "F40"));
            Console.WriteLine(CarCollectionTwo[0].CarName);

            //Generic Dictionary wrapped up in a class and with two indexers (Overloading)
            CarCollection_GenericDictionary CarCollectionThree = new CarCollection_GenericDictionary();
            CarCollectionThree["Mercedez"] = new Car("Mercedez", "m12");
            Console.WriteLine(CarCollectionThree["Mercedez"].CarName);

            CarCollectionThree[23] = new Car("Mercedez", "m12");
            Console.WriteLine(CarCollectionThree[23].CarName);

        }
    }

    class CarCollection_NonGeneric
    {
        private ArrayList arCars = new ArrayList(4);

        //Custom Indexer
        public Car this[int index]
        {
            get { return (Car)arCars[index]; }
            set { arCars.Insert(index,(Car)value); }
        }
    }

    class CarCollection_GenericDictionary
    {
        private Dictionary<string, Car> arCars = new Dictionary<string, Car>();

        //Custom Indexer
        public Car this[string key]
        {
            get { return arCars[key]; }
            set { arCars[key] = value; }
        }

        //Overloaded Indexer
        public Car this[int key]
        {
            get { return arCars[key.ToString()]; }
            set { arCars[key.ToString()] = value; }
        }
    }
}
