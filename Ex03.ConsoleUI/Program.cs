
using System;
using System.Text;
using System.Collections.Generic;
using Ex03.GarageLogic;
using System.Reflection;

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
            EVehicleTypes chosenType = UserSelectEnumValueFromList<EVehicleTypes>();
            Console.WriteLine("chosen type = " + chosenType.ToString());
            Vehicle vehicle = VehicleFactory.CreateEmptyVehicle(chosenType);
            // empty car

            // get wheel - > wheel has to be created before vehicle
            Wheel w = new Wheel("abc",0f,0f);
            // get argument list from car
            Dictionary<string, string> userArgsForVehicle = UserInputForVehicle(vehicle);
            // parse user for those arguments and create a list.

            // parse user for info on vehicle:
            vehicle = VehicleFactory.CreateVehicle(chosenType, userArgsForVehicle);


            GarageEntry entry = new GarageEntry(vehicle, "avi", "012");
            Console.WriteLine(entry.GetVehicle().ToString());
            Console.ReadLine();
        }

        public static Dictionary<string, string> UserInputForVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Insert: ");
            Dictionary<string, string> result = new Dictionary<string, string>();

            Dictionary<string, Type> argumentsForCar = vehicle.GetArgumentsDictionary();
            foreach(KeyValuePair<string, Type> arg in argumentsForCar)
            {
                if (arg.Value.IsEnum)
                {
                    MethodInfo method = typeof(Program).GetMethod("UserSelectEnumValueFromList").MakeGenericMethod(new Type[] { arg.Value });
                    object selectedEnumValue = method.Invoke(null, null);
                    result.Add(arg.Key, selectedEnumValue.ToString());

                }
                else
                {
                    string input;
                    do {
                        Console.WriteLine(arg.Key + ": ");
                        input = Console.ReadLine();
                    } while (!CheckInputValidity(input, arg.Value));
                    result.Add(arg.Key, input);
                }
                
            }

            return result;
        }


        private static bool CheckInputValidity(string input, Type type)
        {
            bool isValid = false;
            if (type == typeof(string))
            {
                isValid = true;
            }
            else
            {
                MethodInfo tryParseMethod = type.GetMethod("TryParse", new[] { typeof(string), type.MakeByRefType() });
                if (tryParseMethod != null)
                {
                    object[] parameters = { input, null };
                    isValid = (bool)tryParseMethod.Invoke(null, parameters);
                }
            }
            return isValid;
        }

        public static TEnum UserSelectEnumValueFromList<TEnum>() where TEnum : Enum
        {
            StringBuilder listOfItems = new StringBuilder();
            listOfItems.Append("Please choose one item from the following list by number: \n");
            int count = 1;
            foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
            {
                listOfItems.Append(count.ToString() + ". ");
                listOfItems.Append(type.ToString());
                listOfItems.Append("\n");
                count++;
            }
            Console.WriteLine(listOfItems);

            string userIn;
            int userInAsNum;
            while (true)
            {
                userIn = Console.ReadLine();
                bool isNumber = int.TryParse(userIn, out userInAsNum);
                if (isNumber == false || userInAsNum <= 0 || userInAsNum > Enum.GetValues(typeof(TEnum)).Length)
                {
                    Console.WriteLine("Wrong input, please retry!");
                    continue;
                }
                break;
            }

            return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(userInAsNum - 1);
        }    

        
    }


}
