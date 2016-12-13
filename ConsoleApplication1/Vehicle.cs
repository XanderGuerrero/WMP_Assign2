/*
	NAME	:	    Vehicle.cs
    PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
  	DESCRIPTION :	This source file is where the abstract class for the vehicle is kept.
  	                All other classes inherit the attributes and behaviours of Vehicle.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //the vehicle class defines what all cars should have
    // the other classes inhiret from this class and its attributes
    abstract class Vehicle
    {

        //publlic data member
        public int currentID;
        //proteced data members
        protected string type;
        protected string manufacturer;
        protected string model;
        protected int modelYear;
        protected float initialPurchasePrice;
        protected string purchaseDate;
        protected int currentOdometerReading;
        protected int engineSize;
        protected float currentValue;




        //constructor
        public Vehicle()
        {
            type = null;
            manufacturer = null;
            model = null;
            modelYear = 0;
            initialPurchasePrice = 0;
            purchaseDate = null;
            currentOdometerReading = 0;
            engineSize = 0;
            currentValue = 0;
        }



        //destructor
        ~Vehicle()
        {

        }




        // virtual function
        /*Function: public virtual float DepreciatedValue()
        * Paramerter(s):None
        * Description: take the old value and depreciated the value
         * to get a new value
        * Returns: current value - which is the new value
        */
        public virtual float DepreciatedValue()
        {

            return currentValue;
        }



        //getters/setters
        // set and get the id
        public int myID
        {
            get { return currentID; }
            set { currentID = value; }
        }



        // set and get the type
        public string myType
        {
            get { return type; }
            set { type = value; }
        }



        //set and get MyManufacturers
        public string MyManufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }



        //set and get MyModel
        public string MyModel
        {
            get { return model; }
            set { model = value; }
        }



        //set and get MyModelYear
        public int MyModelYear
        {
            get { return modelYear; }
            set { modelYear = value; }
        }



        //set and get MyPurchaseDate
        public string MyPurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }



        //set and get MyInitialPurchasePrice
        public float MyInitialPurchasePrice
        {
            get { return initialPurchasePrice; }
            set { initialPurchasePrice = value; }
        }



        //set and get MyCurrentOdometerReading
        public int MyCurrentOdometerReading
        {
            get { return currentOdometerReading; }
            set { currentOdometerReading = value; }
        }



        //set and get MyEngineSize
        public int MyEngineSize
        {
            get { return engineSize; }
            set { engineSize = value; }
        }
    }
}
