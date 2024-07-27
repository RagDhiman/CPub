using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class ObservableCollection
    {
        /*
            There are some useful generic collections under this name space:

            System.Collections.ObjectModel

            ObservableCollection<T>         -- provides notification when the collection gets added to or removed from or when refreshed

            ReadOnlyObservableCollection<T> -- Readonly version of the above
        */

        public void Example()
        {

            ObservableCollection<Car> myCars = new ObservableCollection<Car>(); //Works like List<T>

            myCars.CollectionChanged += CarsCollectionChanged;  //Link event

            myCars.Add(new Car("Ferrari","F45"));   //Calls CarsCollectionChanged on insert
            myCars.Add(new Car("Williams", "w23"));   //Calls CarsCollectionChanged on insert

            myCars.Remove(myCars[0]);   //Calls CarsCollectionChanged on remove

            myCars = new ObservableCollection<Car>(); //Calls CarsCollectionChanged on reresh
        }

        private void CarsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //e.Action  what triggered the event
            //e.NewItems items added
           // e.OldItems items removed
       
            throw new NotImplementedException();
        }
    }
}
