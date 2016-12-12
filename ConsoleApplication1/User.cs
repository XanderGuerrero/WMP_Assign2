using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class User  : Vehicle
    {
        public User();

        ~User()
        {
            Console.WriteLine("calling u destructor");
        }

        //method to choose correct object to instaniate

        //getters/setters
        //MyManufacturers
        public int MyNumberOfDoors
        {
            get { return numberOfDoors; }
            set { numberOfDoors = value; }
        }
        public string MyTypeOfMotorcycle
        {
            get { return typeOfMotorcycle; }
            set { typeOfMotorcycle = value; }
        }
        public string MyFuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }
        public string MyManufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        //MyModel
        public string MyModel
        {
            get { return model; }
            set { model = value; }
        }
        public int MycargoCapacity
        {
            get { return cargoCapacity; }
            set { cargoCapacity = value; }
        }

        public int MytowingCapacity
        {
            get { return towingCapacity; }
            set { towingCapacity = value; }
        }

        //MyModelYear
        public int MyModelYear
        {
            get { return modelYear; }
            set { modelYear = value; }
        }

        //MyPurchaseDate
        public string MyPurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        //MyInitialPurchasePrice
        public float MyInitialPurchasePrice
        {
            get { return initialPurchasePrice; }
            set { initialPurchasePrice = value; }
        }

        //MyCurrentOdometerReading
        public int MyCurrentOdometerReading
        {
            get { return currentOdometerReading; }
            set { currentOdometerReading = value; }
        }

        //MyEngineSize
        public int MyEngineSize
        {
            get { return engineSize; }
            set { engineSize = value; }
        }

        
    }
}
