using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    static class MainUI
    {
        static Garage garage = new Garage();
        public static void ShowMainMenu()
        {
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
                    case EMainMenuItems.ChangeVehicleState:
                        ChangeVehicleState();
                        break;
                    case EMainMenuItems.InflateTiresToMaximum:
                        InflateTiresToMax();
                        break;
                    case EMainMenuItems.FuelFueledVehicle:
                        RefuelOrRecharge(EEnergySources.Fueled);
                        break;
                    case EMainMenuItems.ChargeElectricalVehicle:
                        RefuelOrRecharge(EEnergySources.Electrical);
                        break;
                    case EMainMenuItems.ShowFullVehicleDataByLicenseNumber:
                        ShowFullVehicleDataByLicenseNumber();
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

        public static void ShowFullVehicleDataByLicenseNumber()
        {
            Console.WriteLine("Please enter desired license plate number: ");
            string licensePlateNum = Console.ReadLine();
            if (garage.IsVehicleInGarage(licensePlateNum))
            {
                Console.WriteLine(garage.ShowFullVehicleData(licensePlateNum));
            }
            else
            {
                Console.WriteLine("Vehicle is not in garage.");
            }
        }

        public static void RefuelOrRecharge(EEnergySources source)
        {
            Console.WriteLine("Please enter desired license plate number: ");
            string licensePlateNum = Console.ReadLine();
            if (garage.IsVehicleInGarage(licensePlateNum))
            {

                float fillAmount;
                do
                {
                    Console.WriteLine("Please enter the desired amount to fill: ");
                } while (!float.TryParse(Console.ReadLine(), out fillAmount));

                switch (source)
                {
                    case EEnergySources.Fueled:
                        try
                        {
                            Console.WriteLine("Pick fuel type to fill:");
                            EFuelTypes fuelType = UIParser.UserSelectEnumValueFromList<EFuelTypes>();
                            garage.RefuelOrRecharge(licensePlateNum, EEnergySources.Fueled, fillAmount, fuelType);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                    case EEnergySources.Electrical:
                        try
                        {
                            garage.RefuelOrRecharge(licensePlateNum, EEnergySources.Electrical, fillAmount);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vehicle is not in garage.");
            }


        }
        public static void InflateTiresToMax()
        {
            Console.WriteLine("Please enter desired license plate number: ");
            string licensePlateNum = Console.ReadLine();
            if (garage.IsVehicleInGarage(licensePlateNum))
            {
                garage.InflateTires(licensePlateNum);
            }
            else
            {
                Console.WriteLine("Vehicle is not in garage.");
            }
        }
        public static void ChangeVehicleState()
        {
            Console.WriteLine("Please enter desired license plate number: ");
            string licensePlateNum = Console.ReadLine();
            if (garage.IsVehicleInGarage(licensePlateNum))
            {
                EVehicleStatus status = UIParser.UserSelectEnumValueFromList<EVehicleStatus>();
                garage.SetVehicleStatus(licensePlateNum, status);
            }
            else
            {
                Console.WriteLine("Vehicle is not in garage.");
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
            Console.WriteLine(garage.ShowAllVehicles());
        }

        public static void ShowVehiclesInGarageByStatus(EVehicleStatus status)
        {
            Console.WriteLine(garage.ShowAllVehiclesByStatus(status));
        }





    }
}
