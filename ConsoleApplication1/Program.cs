/*
	NAME	:	    Program.cs
 *  PROJECT :       ConsoleApplication1
	Date	:	    23/09/2014
	AUTHORS	:	    Manbir Singh + Alex Guerrero
 * 	DISCRIPTION :	The main of the program. The program contains a database system(textfile)
 * 	                which a user can modify. The user can add a new type of vehicle,
 * 	                delete a vehicle, update the odometer, search for a type of vechicle and display all vehicles.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace ConsoleApplication1
{

    class Program
    {


        static int Main()
        {
            int menuChoice = 0;
            //instantiate a class 
            UserInterface person = new UserInterface();
            UserInterface Display = new UserInterface();
            Vehicle goodtogo;
            Motorcycle bike = new Motorcycle();
            Automobile car = new Automobile();
            Truck truck = new Truck();
            string userInput = "null";
            int odometerReading = 0;
            char exit = '\0';
            int modelYear = 0;
            int typeVehicle = 0;
            int vehicleCount = 0;
            int vehicleId = 0;
            int motorcycleCount = 0;
            int carCount = 0;
            int truckCount = 0;
            StreamWriter sw;
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>();

            if (File.Exists("vehicleDatabase.txt"))
            {
                //get all information from file and store it into the dictionary
                using (StreamReader sr = new StreamReader("vehicleDatabase.txt"))
                {
                    //Add the data from the text file and add it to the vehicle
                    while (!sr.EndOfStream)
                    {
                        //read the line then add that line to the vehicle depeneding
                        // on what value it is
                        String line = sr.ReadLine();
                        goodtogo = person.tmpObject(line);
                        vehicleCount++;
                        goodtogo.myID = vehicleCount;

                        goodtogo.myType = line;
                        line = sr.ReadLine();
                        goodtogo.MyManufacturer = line;
                        line = sr.ReadLine();
                        goodtogo.MyModel = line;
                        line = sr.ReadLine();
                        goodtogo.MyModelYear = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        goodtogo.MyInitialPurchasePrice = Convert.ToSingle(line);
                        line = sr.ReadLine();
                        goodtogo.MyPurchaseDate = line;
                        line = sr.ReadLine();
                        goodtogo.MyCurrentOdometerReading = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        goodtogo.MyEngineSize = Convert.ToInt32(line);
                        //now comes down to the difference between the 3 types
                        // findout which type and then add the lines to the
                        // values needed
                        if (goodtogo.myType == "motorcycle")
                        {
                            if (motorcycleCount <= 10)
                            {
                                bike = (Motorcycle)goodtogo;
                                line = sr.ReadLine();
                                bike.MyTypeOfMotorcycle = line;
                                motorcycleCount++;//update the count of the motorcycle
                            }

                        }
                        else if (goodtogo.myType == "car")
                        {
                            if (carCount <= 10)
                            {
                                car = (Automobile)goodtogo;
                                line = sr.ReadLine();
                                car.MyNumberOfDoors = Convert.ToInt32(line);
                                line = sr.ReadLine();
                                car.MyFuelType = line;
                                carCount++;//update the count of the automobile
                            }
                        }
                        else if (goodtogo.myType == "truck")
                        {
                            if (truckCount <= 10)
                            {
                                truck = (Truck)goodtogo;
                                line = sr.ReadLine();
                                truck.MyCargoCapacity = Convert.ToInt32(line);
                                line = sr.ReadLine();
                                truck.MytowingCapacity = Convert.ToInt32(line);
                                truckCount++;//update the count of the truck
                            }
                        }
                        vehicleList.Add(vehicleCount, goodtogo);//add the new object to the llist
                        line = sr.ReadLine();//theses two reads just read the space between the data
                        line = sr.ReadLine();
                    }
                }
            }
            while (true)
            {

                //display menu
                Console.Clear();
                Display.Menu();

                //get input, validate it's an int, if not.....
                if (!int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    Console.Write("Menu choice was not valid, please re-enter a menu choice");
                    Console.Out.Flush();
                    Console.Clear();
                    menuChoice = 0;
                }
                //otherwise if the value of the menu input is greater than 6 or less than 1
                //display the error and ask again
                else if ((menuChoice > 6) || (menuChoice < 1))
                {
                    Console.WriteLine("Menu options are 1 to 6, you entered: ", menuChoice);
                    Console.Out.Flush();
                    Console.Clear();
                    menuChoice = 0;
                }
                //otherwise enter the application
                else
                {

                    while (true)
                    {
                        if (menuChoice == 0)
                        {
                            break;
                        }
                        //clear the screen
                        Console.Out.Flush();

                        //case statement to control program flow
                        switch (menuChoice)
                        {
                            //This section of code asks the user for vehicle information 
                            case 1:
                                Console.Clear();
                                goodtogo = person.createObject(ref typeVehicle);//get the object type that the user is entering
                                menuChoice = 0;
                                while (true)
                                {
                                    Console.Clear();
                                    // see if the type the user selected is full or not maximum 10 for each type
                                    if (typeVehicle == 1 && motorcycleCount >= 10)
                                    {
                                        Console.WriteLine("Maximum motorcylce entries have been reached");
                                        Console.WriteLine("Click any key to continue..");
                                        Console.ReadKey();
                                        break;
                                    }
                                    if (typeVehicle == 2 && carCount >= 10)
                                    {
                                        Console.WriteLine("Maximum automobile entries have been reached");
                                        Console.WriteLine("Click any key to continue..");
                                        Console.ReadKey();
                                        break;
                                    }
                                    if (typeVehicle == 3 && truckCount >= 10)
                                    {
                                        Console.WriteLine("Maximum truck entries have been reached");
                                        Console.WriteLine("Click any key to continue..");
                                        Console.ReadKey();
                                        break;
                                    }
                                    menuChoice = 1;
                                    //get the data from the user
                                    exit = Display.EntryCases(menuChoice, goodtogo, typeVehicle);
                                    vehicleCount++;//update the count of total vehicles
                                    goodtogo.myID = vehicleCount;// the id will equal the vehicle count
                                    if (typeVehicle == 1)
                                    {
                                        goodtogo.myType = "motorcycle";
                                        bike = (Motorcycle)goodtogo;// change the type to that vehicle
                                        bike.print(bike);//print what the user has entered for that vehicle
                                        motorcycleCount++;
                                    }
                                    if (typeVehicle == 2)
                                    {
                                        goodtogo.myType = "car";
                                        car = (Automobile)goodtogo;// change the type to that vehicle
                                        car.print(car);//print what the user has entered for that vehicle
                                        carCount++;
                                    }
                                    if (typeVehicle == 3)
                                    {
                                        goodtogo.myType = "truck";
                                        truck = (Truck)goodtogo;// change the type to that vehicle
                                        truck.print(truck);//print what the user has entered for that vehicle
                                        truckCount++;
                                    }
                                    vehicleList.Add(vehicleCount, goodtogo);// add the new vehicle to the list
                                    Console.WriteLine("Click any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                    //}
                                }//while loop
                                break;
                            //get the current odometer reading
                            case 2:
                                Console.Write("Please enter the vehicle id # to change odo: ");
                                if (!int.TryParse(Console.ReadLine(), out vehicleId))//check if the userinput is a number
                                {
                                    Console.Write("Invlaid entry, id # reading required");
                                    Console.ReadKey();
                                    Console.Out.Flush();
                                    Console.Clear();
                                    menuChoice = 2;
                                    break;
                                }
                                else if ((vehicleId.ToString().Length > 2) || (vehicleId.ToString().Length < 1))
                                {
                                    Console.WriteLine("Ivalid input, please re-enter the id # ");
                                    Console.ReadKey();
                                    Console.Out.Flush();
                                    Console.Clear();
                                    menuChoice = 2;
                                    break;
                                }
                                else
                                {// if the input is valid then check if the id is within the list
                                 //get data
                                    if (vehicleList.ContainsKey(vehicleId))
                                    {//the vehicle is in the list
                                        Console.Clear();
                                        Console.WriteLine("Please enter the new odometer: ");
                                        if (!int.TryParse(Console.ReadLine(), out odometerReading))//check userinput
                                        {
                                            Console.Clear();
                                            Console.Write("Invalid entry, please re-eneter the purchase price");
                                            Console.ReadKey();
                                            Console.Out.Flush();
                                            break;
                                        }
                                        else if ((odometerReading.ToString().Length > 7) || (odometerReading.ToString().Length < 1))
                                        {
                                            Console.Clear();
                                            Console.Write("Invalid input, please re-enter the purchase price");
                                            Console.ReadKey();
                                            Console.Out.Flush();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            vehicleList[vehicleId].MyCurrentOdometerReading = odometerReading;//the new odometer will be stored the vehicle
                                            Console.WriteLine("The new odometer has been added to the vehicle...");
                                            //print out what the newly updated vehicle looks like
                                            if (vehicleList[vehicleId].myType == "motorcycle")
                                            {
                                                bike = (Motorcycle)vehicleList[vehicleId];
                                                bike.print(bike);

                                            }
                                            else if (vehicleList[vehicleId].myType == "car")
                                            {
                                                car = (Automobile)vehicleList[vehicleId];
                                                car.print(car);

                                            }
                                            else if (vehicleList[vehicleId].myType == "truck")
                                            {
                                                truck = (Truck)vehicleList[vehicleId];
                                                truck.print(truck);
                                            }

                                        }

                                    }
                                    else//the vehicle doesnt exist
                                    {
                                        Console.WriteLine("The id was not found: ");
                                    }
                                    Console.WriteLine("Click any key to continue..");
                                    Console.ReadKey();
                                    Console.Out.Flush();
                                    Console.Clear();
                                    exit = 'b';
                                }

                                break;
                            //search by type or model year
                            case 3:
                                Console.Write("Please enter the type( motorcycle, car , and truck) or model year: ");
                                userInput = Console.ReadLine();//get userinput
                                if (int.TryParse(userInput, out modelYear))//check if they entered a year
                                {
                                    for (int i = 1; i <= vehicleCount; i++)
                                    {
                                        if (!vehicleList.ContainsKey(i))//check if the vehicle is there or not
                                        {
                                            //if it doesnt exist dont do a thing
                                        }
                                        else if (vehicleList[i].MyModelYear == modelYear && vehicleList[i].myType == "motorcycle")
                                        {
                                            bike = (Motorcycle)vehicleList[i];
                                            bike.print(bike);//display the motorcycle
                                            Console.WriteLine("\n");
                                        }
                                        else if (vehicleList[i].MyModelYear == modelYear && vehicleList[i].myType == "car")
                                        {
                                            car = (Automobile)vehicleList[i];
                                            car.print(car);//display the car
                                            Console.WriteLine("\n");

                                        }
                                        else if (vehicleList[i].MyModelYear == modelYear && vehicleList[i].myType == "truck")
                                        {
                                            truck = (Truck)vehicleList[i];
                                            truck.print(truck);//display the truck
                                            Console.WriteLine("\n");

                                        }

                                    }
                                }
                                else//they entered a string so check the type
                                {
                                    for (int i = 1; i <= vehicleCount; i++)//loop and print all they vehicles that match the search
                                    {
                                        if (!vehicleList.ContainsKey(i))
                                        {
                                            //dont do a thing since there is no key for the list
                                        }
                                        else if (userInput == "motorcycle" && vehicleList[i].myType == "motorcycle")//match the userinput and display the type of vehicle
                                        {
                                            bike = (Motorcycle)vehicleList[i];
                                            bike.print(bike);

                                        }
                                        else if (userInput == "car" && vehicleList[i].myType == "car")
                                        {
                                            car = (Automobile)vehicleList[i];
                                            car.print(car);

                                        }
                                        else if (userInput == "truck" && vehicleList[i].myType == "truck")
                                        {
                                            truck = (Truck)vehicleList[i];
                                            truck.print(truck);

                                        }
                                        Console.WriteLine("\n");
                                    }
                                }
                                Console.WriteLine("Click any key to continue..");
                                Console.ReadKey();
                                Console.Out.Flush();
                                Console.Clear();
                                exit = 'b';
                                break;

                            //display all records
                            case 4:
                                Console.WriteLine("\nAll records: ");
                                for (int i = 1; i <= vehicleCount; i++)//print out all the records
                                {

                                    //see which iteam belongs to which type 
                                    if (!vehicleList.ContainsKey(i))
                                    {
                                        //the key in the vehicle doesnt exist so do nothing
                                    }
                                    else if (vehicleList[i].myType == "motorcycle")
                                    {
                                        bike = (Motorcycle)vehicleList[i];
                                        bike.print(bike);

                                    }
                                    else if (vehicleList[i].myType == "car")
                                    {
                                        car = (Automobile)vehicleList[i];
                                        car.print(car);

                                    }
                                    else if (vehicleList[i].myType == "truck")
                                    {
                                        truck = (Truck)vehicleList[i];
                                        truck.print(truck);

                                    }
                                    Console.WriteLine("\n");
                                }
                                Console.WriteLine("Click any key to continue..");
                                Console.ReadKey();
                                Console.Out.Flush();
                                Console.Clear();
                                exit = 'b';
                                break;
                            //delete
                            case 5:
                                Console.Write("Please enter the ID of the vehicle you wish to delete: ");
                                if (!int.TryParse(Console.ReadLine(), out vehicleId))//check if the userinput is a int or not
                                {
                                    Console.Write("Invlaid entry, ID required");
                                    Console.ReadKey();

                                    Console.Out.Flush();
                                    Console.Clear();
                                    menuChoice = 5;
                                    break;
                                }
                                else if ((vehicleId.ToString().Length > 2) || (vehicleId.ToString().Length < 1))
                                {
                                    Console.WriteLine("Ivalid input, please re-enter ID number");
                                    Console.ReadKey();
                                    Console.Out.Flush();
                                    Console.Clear();
                                    menuChoice = 5;
                                    break;
                                }
                                else if (vehicleList.ContainsKey(vehicleId))//check if the vehicle exists or not
                                {
                                    //if the vehicle exists then decriment the count of the type the vehicle was
                                    if (vehicleList[vehicleId].myType == "motorcycle")
                                    {
                                        motorcycleCount--;
                                    }
                                    else if (vehicleList[vehicleId].myType == "car")
                                    {
                                        carCount--;
                                    }
                                    else if (vehicleList[vehicleId].myType == "truck")
                                    {
                                        truckCount--;
                                    }

                                    if (vehicleList.Remove(vehicleId))//delete the vehicle
                                    {
                                        Console.WriteLine("Vehicle has been deleted");

                                        exit = 'b';

                                    }
                                }
                                else//vehicle didnt exist
                                {
                                    Console.WriteLine("This vehicle doesnt exist");

                                }
                                Console.WriteLine("Click any key to continue..");
                                Console.ReadKey();
                                Console.Out.Flush();
                                Console.Clear();
                                break;
                            //exit
                            case 6:
                                sw = new StreamWriter("vehicleDataBase.txt");
                                for (int i = 1; i <= vehicleCount; i++)
                                {
                                    // add what all of the vehicles share to the
                                    // database txt file
                                    sw.WriteLine(vehicleList[i].myType);
                                    sw.WriteLine(vehicleList[i].MyManufacturer);
                                    sw.WriteLine(vehicleList[i].MyModel);
                                    sw.WriteLine(vehicleList[i].MyModelYear);
                                    sw.WriteLine(vehicleList[i].MyInitialPurchasePrice);
                                    sw.WriteLine(vehicleList[i].MyPurchaseDate);
                                    sw.WriteLine(vehicleList[i].MyCurrentOdometerReading);
                                    sw.WriteLine(vehicleList[i].MyEngineSize);

                                    // add the different attributes of the vehicle into
                                    // the database txt file
                                    if (vehicleList[i].myType == "motorcycle")
                                    {
                                        bike = (Motorcycle)vehicleList[i];

                                        sw.WriteLine(bike.MyTypeOfMotorcycle);

                                    }
                                    else if (vehicleList[i].myType == "car")
                                    {
                                        car = (Automobile)vehicleList[i];
                                        sw.WriteLine(car.MyNumberOfDoors);
                                        sw.WriteLine(car.MyFuelType);
                                    }
                                    else if (vehicleList[i].myType == "truck")
                                    {
                                        truck = (Truck)vehicleList[i];
                                        sw.WriteLine(truck.MyCargoCapacity);
                                        sw.WriteLine(truck.MytowingCapacity);
                                    }
                                    sw.WriteLine("\n");
                                }
                                sw.Close();
                                Console.Write("GoodBye");
                                Console.ReadKey();
                                Console.Out.Flush();
                                Console.Clear();
                                //if user enters  carriage return, exit program
                                //otherwise, scan input for letters only
                                exit = 'a';
                                break;

                        }
                        if (exit == 'a')
                        {
                            break;
                        }
                        if (exit == 'b')
                        {
                            break;
                        }
                    }

                }//third while ends here
                if (exit == 'a')
                {
                    break;
                }

            }//second while ends here 
            return 0;
        }
    }
}
