
using System;
using System.Text;
using System.Collections.Generic;
using Ex03.GarageLogic;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    public static class Program
    {

        
        public static void Main()
        {
            Garage garage = new Garage();
            EVehicleTypes chosenType = UIParser.UserSelectEnumValueFromList<EVehicleTypes>();
            Console.WriteLine("chosen type = " + chosenType.ToString());
            Vehicle vehicle = VehicleFactory.CreateEmptyVehicle(chosenType);
            // empty car

            // get wheel - > wheel has to be created before vehicle
            Wheel w = new Wheel("abc",0f,0f);
            // get argument list from car
            Dictionary<string, string> userArgsForVehicle = UIParser.UserInputForVehicle(vehicle);
            // parse user for those arguments and create a list.

            // parse user for info on vehicle:
            vehicle = VehicleFactory.CreateVehicle(chosenType, userArgsForVehicle);


            GarageEntry entry = new GarageEntry(vehicle, "avi", "012");
            Console.WriteLine(entry.GetVehicle().ToString());
            Console.ReadLine();
        }

        

        
    }


}
