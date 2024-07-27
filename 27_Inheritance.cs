using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    /*
        Private members on base make protected if you want child to access them.
        Use SEALED class if you want to prevent inheritance: Useful for utility classes that are not supposed to be inherited from
        Structures are sealed by default
    */

    //Base Class, Parent Class or Super Class
    class Vehicile
    {
        public readonly int maxSpeed;
        protected int currentSpeed;

        //Has a relationship with engine
        protected Engine vehchileEngine = new Engine();

        #region Constructors
        public Vehicile(int maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }
        public Vehicile()
        {
            this.maxSpeed = 55;
        }
        #endregion

        #region Properties
        public int Speed
        { get {return currentSpeed; }
          set {
                currentSpeed = value;
                if (currentSpeed>maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }
        }

        public Engine Engine { get { return vehchileEngine; } set { vehchileEngine = value; } }

        #endregion

        #region Methods
        protected void DipCurrentSpeed()
        {
            currentSpeed--;
        }
        #endregion
    }

    //Derived or Child Class (Note: We have sealed it so that you cannot further inherit from it)
    // "is-a" relationship with base minivan is a vehicle
    sealed class MiniVan: Vehicile
    {
        public MiniVan(): base(34) //Remember base class consturctor is automatically fired first! Here we are explicitly calling a specific constructor on base because we want to set READONLY PROPERT OF base which can only be set from base constructor
        {
            currentSpeed = 23; //Had to make private currentspeed on baseClass protected so that child could access it
                               //Risk: Of giving child access to parents private members is that and validation or logic around the relavant property is bypassed


            DipCurrentSpeed(); //Private methods on the base class can also be made protected i.e. so that they can be fired by child app

        }
    }

    class Engine
    {
        public int engineSize = 44;

        public int EngineSize { get { return engineSize;} set {engineSize = value;} }

        //nested helper class thats only ever used by the engine and is not available to the out side world
        private class mpgCalculator
        {
            public int mpg = 44;
        }
    }
}
