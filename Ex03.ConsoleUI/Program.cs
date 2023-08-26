using System;
using System.Text;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class Program
    {


        // please enter the license number of the vehicle you wish to insert into garage:


        // please pick the type of vehice (car, motorcycle, truck)
        // please pick the motor type (electrical / fueled) only if car/motorcycle

        // please pick the amount of fuel - current and max
        // please type the wheel status - manufacturer, maxPressure, currentPressure
        // motorcycle -> licenseType || car -> color, doors || truck -> isCooled

        // 1. ask for license plate
        // 2. if garageEntry with such license plate exists - change status of car to InRepair
        // 3. if doesn't exist: ask for vehicle type -- factory here?? => creates empty vehicle?
        // 4. ask for electric source according to electric source (?) 
        // 5. ask for wheel data

        // ?. Garage entry generated..
        
        public static void Main()
        {
            

            Garage garage = new Garage();
            EVehicleTypes chosenType = UserSelectVehicleTypeFromList();
            Console.WriteLine("chosen type = " + chosenType.ToString());
            Vehicle vehicle = VehicleFactory.CreateEmptyVehicle(chosenType);
            // empty car

            // get wheel - > wheel has to be created before vehicle
            Wheel w = new Wheel("abc",0f,0f);
            // get argument list from car

            // parse user for those arguments and create a list.

            // parse user for info on vehicle:
            // 1. energy source:
            //EnergySource source = UserInputForEnergySource(vehicle.GetEnergySource());


            GarageEntry entry = new GarageEntry(vehicle, "avi", "012");
            
            Console.ReadLine();
        }

        public static EnergySource UserInputForEnergySource(EnergySource energySource)
        {
            List<string> args = energySource.GetArgumentList();
            List<string> userInputs = new List<string>();
            Console.WriteLine("Please insert the following data for your fuel source: ");
            foreach(string arg in args)
            {
                Console.Write(arg + ": ");
                userInputs.Add(Console.ReadLine());
                
            }
            
            
            //return source;
            
        }

        public static EVehicleTypes UserSelectVehicleTypeFromList()
        {
            StringBuilder listOfVehicles = new StringBuilder();
            listOfVehicles.Append("Please choose one vehicle from the following list by number: \n");
            int count = 1;
            foreach(EVehicleTypes type in Enum.GetValues(typeof(EVehicleTypes)))
            {
                listOfVehicles.Append(count.ToString() + ". ");
                listOfVehicles.Append(type.ToString());
                listOfVehicles.Append("\n");
                count++;
            }
            Console.WriteLine(listOfVehicles);
            string userIn;
            int userInAsNum;
            while (true)
            {
                userIn = Console.ReadLine();
                bool isNumber = int.TryParse(userIn, out userInAsNum);
                if (isNumber == false || userInAsNum <= 0 || userInAsNum > Enum.GetValues(typeof(EVehicleTypes)).Length)
                {
                    Console.WriteLine("Wrong input, please retry!");
                    continue;
                }
                break;
            }

            return (EVehicleTypes)Enum.GetValues(typeof(EVehicleTypes)).GetValue(userInAsNum-1);
        }
    }


}
