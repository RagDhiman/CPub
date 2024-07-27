using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Class_GoodPractices
    {
    }

    class Car
    {
        #region Constructors

        //Try and use constructor chaining to avoid loads of adhoc overloads of the constructor
        //Constructor chaining always HAS one main constructor
        //Other constructors chain to it passing it default values and doing extra things they need to do
        //Leads to cleaner more consice code

        //Alternative to using Constructor chaining is to use: Optional parameters on the one constrcutor

        public Car() :this("Ferrari","360",34)//Default Constructor
        {
            //Do something additional or set something extra that the MASTER CONSTRUCTOR does not support
        }

        public Car(string manutfacturer, string carName) :this(manutfacturer, carName, 43)
        {
            //Do something additional or set something extra that the MASTER CONSTRUCTOR does not support
        }

        //Always try to have one MASTER constructor and then chain other constructors to it: This is master constructor it takes all properties required
        //Other constructors provide defaults
        public Car(string manutfacturer, string carName, int engineSize)
        {
            this.manufacturer = manutfacturer;      //Use THIS to distinguish between parameter and class property
            CarName = carName;
            EngineSize = engineSize;
        }

        #endregion

        #region Members

        public string manufacturer;     // **Avoid** data elements that are public: Data integrity should be controlled using setters and getters properties

        //Recomended way Private variable with Public property to control assignment and retrival
        private string _carName;
        public string CarName
        {
            get
            {
                return _carName;
            }
            set
            {
                _carName = value;
            }
        }

        private int _engineSize;
        public int EngineSize
        {
            get
            {
                return _engineSize;
            }
            set
            {
                _engineSize = value;
            }
        }

        #endregion


    }
}
