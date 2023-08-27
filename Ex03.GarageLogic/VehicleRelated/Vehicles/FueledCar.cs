using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FueledCar : Vehicle, IFueled
    {

        private const int _maxNumOfWheels = 5;

        private EColors color;
        private int numberOfDoors;
        private EFuelTypes fuelType;

        protected override int numberOfWheels => _maxNumOfWheels;

        public FueledCar()
        {

        }

        public FueledCar(string modelName, string licensePlateNumber, float maxFuel, float currentFuel, EFuelTypes fuelType, EColors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber, maxFuel, currentFuel, wheelType)
        {
            this.fuelType = fuelType;
            this.color = color;
            this.numberOfDoors = numberOfDoors;
        }





        public override Dictionary<string, Type> GetArgumentsDictionary()
        {

            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("modelName", typeof(string));
            args.Add("licensePlateNumber", typeof(string));
            args.Add("maxFuel", typeof(float));
            args.Add("currentFuel", typeof(float));
            args.Add("fuelType", typeof(EFuelTypes));
            args.Add("color", typeof(EColors));
            args.Add("numberOfDoors", typeof(int));
            Dictionary<string, Type> wheelsDict = Wheel.GetArgumentsDictionary();
            foreach(KeyValuePair<string, Type> pair in wheelsDict)
            {
                args.Add(pair.Key, pair.Value);
            }
            return args;
        }

        public void Refuel(float fuelAmount, EFuelTypes fuelType)
        {

            if (fuelType != this.fuelType)
            {
                throw new ArgumentException("Attempt to fill incorrect fuel type");
            }
            else if (currentEnergy + fuelAmount >= maxEnergy)
            {
                throw new ArgumentException("Attemp to overfuel");
            }
            else
            {
                currentEnergy += fuelAmount;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append($"\nMax Fuel: {maxEnergy}\nCurrent Fuel: {currentEnergy}\n" +
                $"Fuel Type: {fuelType.ToString()}\nColor: {color.ToString()}\n" +
                $"Number of doors: {numberOfDoors}\n");
            str.Append("Wheel info:\n");
            str.Append(wheels[0].ToString());
            return str.ToString();
        }
    }
}
