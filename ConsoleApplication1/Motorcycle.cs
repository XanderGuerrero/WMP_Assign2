/*
	NAME	:	    Motorcycle.cs
    PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
 	DESCRIPTION :	This source file contains the properties of the Motorcycle.
  	                It inherits from vehicle.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Motorcycle : Vehicle
    {
        public string typeOfMotorcycle;
        public Motorcycle()
        {
            typeOfMotorcycle = null;
        }

        ~Motorcycle()
        {

        }



        //method
        /*Function:         public override float DepreciatedValue()
        * Paramerter(s):    None
        * Description:      take the old value and depreciated the value
        *                   to get a new value
        * Returns:          current value - which is the new value
        */
        public override float DepreciatedValue()
        {

            float totalValue = 0;
            int howManyYears = 0;
            string[] words;
            int purchaseYear = 0;

            words = purchaseDate.Split('-', '-');
            purchaseYear = Convert.ToInt32(words[2]);

            if (initialPurchasePrice > 1500)
            {
                //gives the amount depreciated per year
                totalValue = initialPurchasePrice * (float)(0.15);
                //howmany years has this been owned?
                howManyYears = purchaseYear - modelYear;
                totalValue = totalValue * howManyYears;
                totalValue = initialPurchasePrice - totalValue;
                currentValue = totalValue;
            }
            else
            {
                currentValue = initialPurchasePrice;
            }
            return currentValue;
        }



        //setter/getter
        public string MyTypeOfMotorcycle
        {
            get { return typeOfMotorcycle; }
            set { typeOfMotorcycle = value; }
        }


        /* Function:        public void print(Motorcycle print)
         * Paramerter(s):   Motorcycle print
         * Description:     print out what is currently in the Motorcycle class
         *                  including the inherited values from vehicle
         */
        public void print(Motorcycle print)
        {
            Console.WriteLine("....Motorcycle....");
            Console.WriteLine("Vehicle ID: " + print.myID);
            Console.WriteLine("Manufacturer: " + print.MyManufacturer);
            Console.WriteLine("Model: " + print.MyModel);
            Console.WriteLine("year: " + print.MyModelYear);
            Console.WriteLine("Price: $" + print.MyInitialPurchasePrice);
            Console.WriteLine("Purchase date: " + print.MyPurchaseDate);
            Console.WriteLine("ODO: " + print.MyCurrentOdometerReading);
            Console.WriteLine("Engine Size: " + print.MyEngineSize);
            Console.WriteLine("Motorcycle type: " + print.MyTypeOfMotorcycle);

        }
    }
}
