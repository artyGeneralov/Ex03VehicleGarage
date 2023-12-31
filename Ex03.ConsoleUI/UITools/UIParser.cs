﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    static class UIParser
    {
        public static Dictionary<string, string> UserInputForVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Insert: ");
            Dictionary<string, string> result = new Dictionary<string, string>();

            Dictionary<string, Type> argumentsForVehicle = vehicle.GetArgumentsDictionary();
            foreach (KeyValuePair<string, Type> arg in argumentsForVehicle)
            {
                if (arg.Value.IsEnum)
                {
                    MethodInfo method = typeof(UIParser).GetMethod("UserSelectEnumValueFromList").MakeGenericMethod(new Type[] { arg.Value });
                    object selectedEnumValue = method.Invoke(null, null);
                    result.Add(arg.Key, selectedEnumValue.ToString());
                    
                }
                else
                {
                    string input;
                    do
                    {
                        Console.WriteLine(SplitByCapitalLetter(arg.Key) + ": ");
                        input = Console.ReadLine();
                    } while (!CheckInputValidity(input, arg.Value));
                    result.Add(arg.Key, input);
                }
            }

            return result;
        }


        public static bool CheckInputValidity(string input, Type type)
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
                listOfItems.Append(SplitByCapitalLetter(type.ToString()));
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

        private static string SplitByCapitalLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(char.ToUpper(input[0]));  // Add the first character as is, assuming it's uppercase

            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (char.IsUpper(currentChar))
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(currentChar);
            }

            return stringBuilder.ToString();
        }
    }
}
