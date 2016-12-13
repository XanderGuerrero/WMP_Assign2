/*
	NAME	:	    UserInterface.cs
 *  PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
 * 	DESCRIPTION :	This sourse file contains the UserInterface class.
 * 	                It contains the outputs that the user will see for ex. the menu options.
 * 	                The userInterFace class will also handle the communication of new entries
 * 	                to the system. It will ask the type of vhicle as well as all the data that
 * 	                comes with that certin vehicle type.
*/





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;





namespace ConsoleApplication1
{
    class UserInterface : Vehicle
    {
        private Vehicle person;



        /*Function: public int Menu()
        * Paramerter(s): none
        * Description: To display the menu option to the user
        * Returns: 0;
        */
        public int Menu()
        {
            Console.WriteLine("Vehicle Inventory\n");
            Console.Write("\n");
            Console.WriteLine("1. Add vehicle information");
            Console.WriteLine("2. Update odometer");
            Console.WriteLine("3. Search by vehicle type or model year");
            Console.WriteLine("4. View all records");
            Console.WriteLine("5. Delete specific record");
            Console.WriteLine("6. Exit");
            Console.Write("\n");
            Console.Write("Input: ");

            return 0;
        }



        //constructor
        public UserInterface()
        {

        }



        //destructor
        ~UserInterface()
        {

        }



        /*Function: public Vehicle tmpObject(string line)
        * Paramerter(s): string line
        * Description: takes the parameter which is the first line of the object
         * within the txt file. It compares it to the different types and then 
         * returns that type
        * Returns: exit - the exit type
        */
        public Vehicle tmpObject(string line)
        {
            //match what type it is
            if (line == "motorcycle")
            {
                person = new Motorcycle();
            }
            else if (line == "car")
            {
                person = new Automobile();

            }
            else if (line == "truck")
            {
                person = new Truck();
            }
            return person;//return the type of the vehicle
        }




        /*Function:         public Vehicle createObject(ref int typeVehicle)
        * Paramerter(s):    ref int typeVehicle
        * Description:      The point of this method is to create an object that will
        *                   inherit from vehicle and then return it the the main class and put it into the
        *                   list
        * Returns:          person; the new instantiated vehicle
        */
        public Vehicle createObject(ref int typeVehicle)
        {
            int input = 0;

            while (true)
            {

                Console.WriteLine("Please select which type of vehicle you are registering\n");
                Console.Write("1. motorcycle\n2. car\n3. truck\n");
                Console.Write("\nVehicle type: ");
                // get which option of vehicle
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Clear();
                    Console.WriteLine("Menu choice was not valid, please re-enter a menu choice");
                    Console.Out.Flush();
                    Console.Clear();
                    continue;
                }
                if (input > 3 || input < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Menu choice was not valid, please re-enter a menu choice");
                    continue;
                }
                else
                {//add the motorcycle
                    if (input == 1)
                    {
                        person = new Motorcycle();
                        typeVehicle = 1;
                        Console.Out.Flush();
                        Console.Clear();
                        break;
                    }
                    else if (input == 2)//option to add the automobile
                    {
                        person = new Automobile();
                        typeVehicle = 2;
                        Console.Out.Flush();
                        Console.Clear();
                        break;
                    }
                    else if (input == 3)//option to add the truck
                    {
                        person = new Truck();
                        typeVehicle = 3;
                        Console.Out.Flush();
                        Console.Clear();
                        break;
                    }
                }
            }
            return person;//return the type of vehicle
        }




        /*Function:  public char EntryCases(int menuChoice, Vehicle person, int typevehicle)
        * Paramerter(s): int menuChoice, Vehicle person, int typevehicle
        * Description: The whole entries of the new vehicle is entered heere
         * The vehicle can be any of the type and the paramater typevehicle
         * will define the private data that the each vehicle will add
        * Returns: person; the new instantiated vehicle
        */
        public char EntryCases(int menuChoice, Vehicle person, int typevehicle)
        {

            string userInput = null;
            int modelYear = 0;
            int odometerReading = 0;
            int initialPurchasePrice = 0;
            //char exit = '\0';
            int purchaseYear = 0;
            string[] words;
            int engineSize = 0;
            char exit = '\0';
            int numberOfDoors = 0;
            int cargoCapacity = 0;
            int towingCapacity = 0;
            // Vehicle person = new Vehicle();

            while (true)
            {
                switch (menuChoice)
                {
                    //adding the manufacturer
                    case 1:
                        Console.Clear();
                        Console.Write("Please enter the manufacturer: ");
                        userInput = Console.ReadLine();
                        //if not valid input 
                        if (!Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
                        {
                            //display the error
                            Console.Write("Invalid input, please re-enter the manufacturer");
                            Console.ReadKey();
                            Console.Clear();
                            menuChoice = 1;
                            break;//quit the loop and loop around to re-enter data
                        }
                        else
                        {
                            //add data to oject

                            person.MyManufacturer = userInput;
                            ++menuChoice;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }

                    //adding the model
                    case 2:
                        Console.Write("Please enter the model: ");
                        userInput = Console.ReadLine();
                        //if not valid input 
                        if (!Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
                        {
                            //display the error
                            Console.Write("Invalid input, please re-enter the model");
                            Console.ReadKey();
                            Console.Clear();
                            menuChoice = 2;
                            break; //quit the loop and loop around to re-enter data
                        }
                        else
                        {
                            person.MyModel = userInput;
                            ++menuChoice;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }

                    //adding the model year
                    case 3:
                        Console.Write("Please enter the model year: ");
                        userInput = Console.ReadLine();
                        //if not valid input
                        //yeaf must be between 1900 and 2099
                        if (!Regex.IsMatch(userInput, @"^(19|20)\d{2}$"))
                        {
                            //display the error
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the model year");
                            Console.ReadKey();
                            Console.Clear();
                            Console.Out.Flush();
                            menuChoice = 3;
                            break; //quit the loop and loop around to re-enter data
                        }
                        else
                        {
                            modelYear = Convert.ToInt32(userInput);
                            person.MyModelYear = modelYear;
                            ++menuChoice;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }
                    //adding the cost of the vehicle
                    case 4:
                        Console.Write("Please enter the initial purchase price: ");
                        Console.Out.Flush();
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out initialPurchasePrice))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the purchase price");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 4;
                            break;
                        }
                        else if ((initialPurchasePrice.ToString().Length > 7) || (initialPurchasePrice.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the purchase price");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 4;
                            break;
                        }
                        else
                        {
                            //add value to memeber
                            person.MyInitialPurchasePrice = initialPurchasePrice;
                            ++menuChoice;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }

                    //adding the date of the purchase
                    case 5:
                        Console.Write("Please enter the purchase date: ");
                        userInput = Console.ReadLine();
                        words = userInput.Split('-', '-');
                        purchaseYear = Convert.ToInt32(words[2]);

                        //if not valid input
                        //dd-mm-yyyy
                        if (!Regex.IsMatch(userInput, @"^(?=\d)(?:(?!(?:(?:0?[5-9]|1[0-4])(?:\.|-|\/)10(?:\.|-|\/)(?:1582))|(?:(?:0?[3-9]|1[0-3])(?:\.|-|\/)0?9(?:\.|-|\/)(?:1752)))(31(?!(?:\.|-|\/)(?:0?[2469]|11))|30(?!(?:\.|-|\/)0?2)|(?:29(?:(?!(?:\.|-|\/)0?2(?:\.|-|\/))|(?=\D0?2\D(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:(?:\d\d)(?:[02468][048]|[13579][26])(?!\x20BC))|(?:00(?:42|3[0369]|2[147]|1[258]|09)\x20BC))))))|2[0-8]|1\d|0?[1-9])([-.\/])(1[012]|(?:0?[1-9]))\2((?=(?:00(?:4[0-5]|[0-3]?\d)\x20BC)|(?:\d{4}(?:$|(?=\x20\d)\x20)))\d{4}(?:\x20BC)?)(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]\d|2[0-3])(?::[0-5]\d){1,2})?$"))
                        {
                            //display the error
                            Console.Write("Invalid input, please re-enter the purchase date");
                            Console.ReadKey();
                            Console.Clear();
                            menuChoice = 5;
                            break; //quit the loop and loop around to re-enter data
                        }
                        else if (purchaseYear < modelYear)
                        {
                            Console.Write("Invalid input, please re-enter the purchase date");
                            Console.ReadKey();
                            Console.Clear();
                            menuChoice = 5;
                            break;
                        }
                        else
                        {
                            //add
                            ++menuChoice;
                            person.MyPurchaseDate = userInput;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }

                    //adding the current odo reading
                    case 6:
                        Console.Write("Please enter the odometer reading: ");
                        Console.Out.Flush();
                        //
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out odometerReading))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the purchase price");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 6;
                            break;
                        }
                        else if ((odometerReading.ToString().Length > 7) || (odometerReading.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the purchase price");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 6;
                            break;
                        }
                        else
                        {
                            ++menuChoice;
                            person.MyCurrentOdometerReading = odometerReading;
                            Console.Out.Flush();
                            Console.Clear();
                            break;
                        }

                    //adding the engine size
                    case 7:
                        Console.Write("Please enter the engine size: ");
                        Console.Out.Flush();
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out engineSize))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the engine size");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 7;
                            break;
                        }
                        else if ((engineSize.ToString().Length > 7) || (engineSize.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the engine size");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 7;
                            break;
                        }
                        else
                        {
                            //++menuChoice;
                            if (typevehicle == 1)
                            {
                                menuChoice = 8;
                            }
                            if (typevehicle == 2)
                            {
                                menuChoice = 9;
                            }
                            if (typevehicle == 3)
                            {
                                menuChoice = 11;
                            }
                            person.MyEngineSize = engineSize;
                            Console.Out.Flush();
                            Console.Clear();

                            break;
                        }
                    //adding the mortorcycle type
                    case 8:
                        Console.Write("Please enter the type of motorcycle: ");
                        userInput = Console.ReadLine();
                        //if not valid input 
                        if (!Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
                        {
                            //display the error
                            Console.Write("Invalid input, please re-enter the type of motorcycle");
                            Console.ReadKey();
                            Console.Out.Flush();
                            Console.Clear();
                            menuChoice = 8;
                            break; //quit the loop and loop around to re-enter data
                        }
                        else
                        {
                            //add the motorcycle type
                            Motorcycle entry = new Motorcycle();
                            entry = (Motorcycle)person;
                            entry.MyTypeOfMotorcycle = userInput;
                            Console.Out.Flush();
                            Console.Clear();
                            exit = 'b';
                            break;
                        }
                    //adding the number of doors
                    case 9:
                        Console.Write("Please enter the number of doors: ");
                        Console.Out.Flush();
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out numberOfDoors))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the number of doors");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 9;
                            break;
                        }
                        else if ((numberOfDoors.ToString().Length > 7) || (numberOfDoors.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the number of doors");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 9;
                            break;
                        }
                        else
                        {
                            ++menuChoice;
                            Automobile entry = new Automobile();
                            entry = (Automobile)person;
                            entry.MyEngineSize = engineSize;
                            Console.Out.Flush();
                            Console.Clear();

                            break;
                        }
                    //adding the fuel type
                    case 10:
                        Console.Write("Please enter the type of fuel: ");
                        userInput = Console.ReadLine();
                        //if not valid input 
                        if (!Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
                        {
                            //display the error
                            Console.Write("Invalid input, please re-enter the type of fuel");
                            Console.ReadKey();
                            Console.Out.Flush();
                            Console.Clear();
                            menuChoice = 10;
                            break; //quit the loop and loop around to re-enter data
                        }
                        else
                        {
                            //add the vehicle fuel type
                            Automobile entry = new Automobile();
                            entry = (Automobile)person;
                            entry.MyFuelType = userInput;
                            Console.Out.Flush();
                            Console.Clear();
                            menuChoice = 10;
                            exit = 'b';
                            break;
                        }
                    case 11: //adding the cargo capacity
                        Console.Write("Please enter the cargo capacity: ");
                        Console.Out.Flush();
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out cargoCapacity))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the cargo capacity");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 11;
                            break;
                        }
                        else if ((cargoCapacity.ToString().Length > 7) || (cargoCapacity.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the cargo capacity");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 11;
                            break;
                        }
                        else
                        {
                            ++menuChoice;
                            Truck entry = new Truck();
                            entry = (Truck)person;
                            entry.MyCargoCapacity = cargoCapacity;
                            Console.Out.Flush();
                            Console.Clear();

                            break;
                        }

                    case 12: //addding the towing capcity
                        Console.Write("Please enter the towing capacity: ");
                        Console.Out.Flush();
                        //if not valid input ............................................
                        if (!int.TryParse(Console.ReadLine(), out cargoCapacity))
                        {
                            Console.Clear();
                            Console.Write("Invalid entry, please re-eneter the towing capacity");
                            Console.ReadKey();
                            Console.Out.Flush();
                            menuChoice = 12;
                            break;
                        }
                        else if ((towingCapacity.ToString().Length > 7) || (towingCapacity.ToString().Length < 1))
                        {
                            Console.Clear();
                            Console.Write("Invalid input, please re-enter the towing capacity");
                            Console.ReadKey();
                            Console.Out.Flush();

                            menuChoice = 12;
                            break;
                        }
                        else
                        {
                            ++menuChoice;
                            Truck entry = new Truck();
                            entry = (Truck)person;
                            entry.MytowingCapacity = cargoCapacity;
                            Console.Out.Flush();
                            Console.Clear();
                            exit = 'b';
                            break;
                        }
                    case 13://user has finished input of data
                        exit = 'c';
                        Console.Clear();
                        break;
                }
                //type of exit that will take place
                if (exit == 'b')
                {
                    break;
                }
                if (exit == 'a')
                {
                    break;
                }
            }//end of while
            return exit;
        }

    }
}
