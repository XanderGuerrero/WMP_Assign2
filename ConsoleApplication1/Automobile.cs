/*
	NAME	:	    Automobile.cs
 *  PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
 * 	DISCRIPTION :	This source file contains the class definition of automobile.
 * 	                It is a sub class that inherits from vehicle.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    //defineing the class that will also 
    //inherit from vehicle
    class Automobile : Vehicle
    {
        private int numberOfDoors;
        private string fuelType;
        
        //Constructor
        public Automobile()
        {
            numberOfDoors = 0;
            fuelType = null;
        }
        //Destructor
        ~Automobile()
        {
         
        }

        //method
        /*Function:         public virtual float DepreciatedValue()
        * Paramerter(s):    None
        * Description:      take the old value and depreciate the value
        *                   to get a new value
        * Returns:          current value - which is the new value
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

            if (km < 20000)
            {
                //gives the amount depreciated per year
                totalValue = initialPurchasePrice * (float)(0.15);
                //how many years has this been owned?
                howManyYears = purchaseYear - modelYear;
                totalValue = totalValue * howManyYears;
                totalValue = initialPurchasePrice - totalValue;
                currentValue = totalValue;
            }
            else if (km > 20000 || initialPurchasePrice > 500)
            {
                //gives the amount depreciated per year
                totalValue = initialPurchasePrice * (float)(0.15);
                //how many years has this been owned?
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
        //setters/ getters
        //get and set the number of doors
        public int MyNumberOfDoors
        {
            get { return numberOfDoors; }
            set { numberOfDoors = value; }
        }
        //get and set the fuel type
        public string MyFuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }

        /*Function:         public void print(Automobile print)
         * Paramerter(s):   Automobile print)
         * Description:     print out what is currently in the autmobile class
         *                  including the the inherited values from vehicle
         */
        public void print(Automobile print)
        {
            Console.WriteLine("....Automobile....");
            Console.WriteLine("Vehicle ID: " + print.myID);
            Console.WriteLine("Manufacturer: " + print.MyManufacturer);
            Console.WriteLine("Model: " + print.MyModel);
            Console.WriteLine("year: " + print.MyModelYear);
            Console.WriteLine("Price: $" + print.MyInitialPurchasePrice);
            Console.WriteLine("Purchase date: " + print.MyPurchaseDate);
            Console.WriteLine("ODO: " + print.MyCurrentOdometerReading);
            Console.WriteLine("Engine Size: " + print.MyEngineSize);
            Console.WriteLine("# of doors: " + print.MyNumberOfDoors);
            Console.WriteLine("Fuel type: " + print.MyFuelType);
        }
    }
}
