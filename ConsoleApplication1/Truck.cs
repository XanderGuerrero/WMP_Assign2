/*
	NAME	:	    Truck.cs
    PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
  	DISCRIPTION :	This source file contains the properties of the Truck.
  	                It inherits from vehicle.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Truck :  Vehicle
    {
        //private data members
        private int cargoCapacity;
        private int towingCapacity;



        //constructer
        public Truck()
        { 
            cargoCapacity = 0;
            towingCapacity = 0; ;
        }



        //destructor
        ~Truck()
        {

        }



        //method
        /*Function:  public override float DepreciatedValue()
        * Paramerter(s):None
        * Description: take the old value and depreciated the value
         * to get a new value
        * Returns: current value - which is the new value
        */
        public override float DepreciatedValue()
        {

            float totalValue = 0;
            int howManyYears = 0;
            string[] words;
            int purchaseYear = 0;
            int km = 0;

            words = purchaseDate.Split('-', '-');
            purchaseYear = Convert.ToInt32(words[2]);

            if (km <= 25000)
            {
                //gives the amount depreciated per year
                totalValue = initialPurchasePrice * (float)(0.20);
                //howmany years has this been owned?
                howManyYears = purchaseYear - modelYear;
                totalValue = totalValue * howManyYears;
                totalValue = initialPurchasePrice - totalValue;
                currentValue = totalValue;
            }
            else if (km > 25000 || initialPurchasePrice > 0)
            {
                //gives the amount depreciated per year
                totalValue = initialPurchasePrice * (float)(0.18);
                //howmany years has this been owned?
                howManyYears = purchaseYear - modelYear;
                totalValue = totalValue * howManyYears;
                totalValue = initialPurchasePrice - totalValue;
                currentValue = totalValue;
                //calc extra depreciation
                totalValue = currentOdometerReading * (float)(.10);
                currentValue = currentValue - totalValue;
            }
            else
            {
                currentValue = initialPurchasePrice;
            }
            return currentValue;
        }




        //setter/'getters
        //get and set the cargo capacity
        public int MyCargoCapacity
        {
            get { return cargoCapacity; }
            set { cargoCapacity = value; }
        }



        //get and set the towing capacity
        public int MytowingCapacity
        {
            get { return towingCapacity; }
            set { towingCapacity = value; }
        }



        /*Function:  public void print(Truck print)
         * Paramerter(s):Truck print)
         * Description: print out what is currently in the Truck class
         * including the inhirited values from vehicle
         */
        public void print(Truck print)
        {
            Console.WriteLine("....Truck....");
            Console.WriteLine("Vehicle ID: " + print.myID);
            Console.WriteLine("Manufacturer: " + print.MyManufacturer);
            Console.WriteLine("Model: " + print.MyModel);
            Console.WriteLine("year: " + print.MyModelYear);
            Console.WriteLine("Price: $" + print.MyInitialPurchasePrice);
            Console.WriteLine("Purchase date: " + print.MyPurchaseDate);
            Console.WriteLine("ODO: " + print.MyCurrentOdometerReading);
            Console.WriteLine("Engine Size: " + print.MyEngineSize);
            Console.WriteLine("Cargo Capacity: " + print.MyCargoCapacity);
            Console.WriteLine("Towing Capacity: " + print.MytowingCapacity);
        }
    }
}
