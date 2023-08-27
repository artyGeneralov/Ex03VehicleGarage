
using System;
using System.Text;
using System.Collections.Generic;
using Ex03.GarageLogic;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    public static class Program
    {


        // Create new garage
        // main menu -> 1. add vehicle to garage
        //              2. show licenseplate list
        //              2.1 by EVehileStatus
        //              2.2 default order
        //              3. quit
        // ask for license plate num
        // check if exists in garage
        // userInputForVehicle
        // back to main menu
        static Garage garage;
        public static void Main()
        {
           garage = new Garage();
            bool hasEnded = false;
            while (!hasEnded)
            {

                Console.WriteLine("____\n\nMenu:\n____\n");
                EMainMenuItems userMainMenuChoise = UIParser.UserSelectEnumValueFromList<EMainMenuItems>();

                switch (userMainMenuChoise)
                {
                    case EMainMenuItems.AddVehicleToGarage:
                        AddVehicleToGarage();
                        break;
                    case EMainMenuItems.ShowVehiclesInGarage:
                        ShowVehicleByLicensePlateSubMenu();
                        break;
                    case EMainMenuItems.Quit:
                        hasEnded = true;
                        break;
                }
                if (!hasEnded)
                {
                    Console.WriteLine("\nPress Enter to Continue\n");
                    Console.ReadLine();
                }
            }
        }


        public static void AddVehicleToGarage()
        {
            // check license
            Console.WriteLine("Please enter a license plate number:");
            string licensePlateNum = Console.ReadLine();
            if (!garage.IsVehicleInGarage(licensePlateNum))
            {
                EVehicleTypes chosenType = UIParser.UserSelectEnumValueFromList<EVehicleTypes>();
                Console.WriteLine("chosen type = " + chosenType.ToString());
                Vehicle vehicle = VehicleFactory.CreateEmptyVehicle(chosenType);
                // empty car

                // get argument list from car
                Dictionary<string, string> userArgsForVehicle = UIParser.UserInputForVehicle(vehicle);
                // parse user for those arguments and create a list.

                // parse user for info on vehicle:
                vehicle = VehicleFactory.CreateVehicle(chosenType, userArgsForVehicle);

                Console.WriteLine("Enter Your Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Your Phone:");
                string phone = Console.ReadLine();
                GarageEntry entry = new GarageEntry(vehicle, name, phone);
                garage.AddToGarage(entry);
            }
            else
            {
                Console.WriteLine("Vehicle is already inside the garage, vehicle status is: ");
                Console.WriteLine(garage.getVehicleStatus(licensePlateNum).ToString());
            }
        }

        public static void ShowVehicleByLicensePlateSubMenu()
        {
            Console.WriteLine("____\n\nSub Menu:\n____\n");
            ESubMenu userMainMenuChoise = UIParser.UserSelectEnumValueFromList<ESubMenu>();

            switch (userMainMenuChoise)
            {
                case ESubMenu.DefaultOrder:
                    ShowAllVehiclesInGarage();
                    break;
                case ESubMenu.OrderByVehicleStatus:
                    EVehicleStatus status;
                    Console.WriteLine("Choose Status:\n____________");
                    status = UIParser.UserSelectEnumValueFromList<EVehicleStatus>();
                    ShowVehiclesInGarageByStatus(status);
                    break;
            }
        }


        public static void ShowAllVehiclesInGarage()
        {
            garage.ShowAllVehicles();
        }

        public static void ShowVehiclesInGarageByStatus(EVehicleStatus status)
        {
            garage.ShowAllVehiclesByStatus(status);
        }




    }


}
