
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar: Vehicle, IElectrical
    {
        private const int _maxNumOfWheels = 5;

        private EColors color;
        private int numberOfDoors;

        protected override int numberOfWheels => _maxNumOfWheels;

        public ElectricCar()
        {

        }

        public ElectricCar(string modelName, string licensePlateNumber, float maxCharge, float currentCharge, EColors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber,maxCharge, currentCharge, wheelType)
        {
            this.color = color;
            this.numberOfDoors = numberOfDoors;
        }





        public override Dictionary<string, Type> GetArgumentsDictionary()
        {

            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("modelName", typeof(string));
            args.Add("licensePlateNumber", typeof(string));
            args.Add("maxCharge", typeof(float));
            args.Add("currentCharge", typeof(float));
            args.Add("color", typeof(EColors));
            args.Add("numberOfDoors", typeof(int));
            Dictionary<string, Type> wheelsDict = Wheel.GetArgumentsDictionary();
            foreach (KeyValuePair<string, Type> pair in wheelsDict)
            {
                args.Add(pair.Key, pair.Value);
            }
            return args;
        }

        public void Recharge(float energyAmount)
        {
            if (currentEnergy + energyAmount >= maxEnergy)
            {
                throw new ArgumentException("Attemp to overcharge");
            }
            else
            {
                Console.WriteLine("curEnergy be4 = " + currentEnergy);
                currentEnergy += energyAmount;
                Console.WriteLine("curEnergy after= " + currentEnergy);
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append($"\nMax Charge: {maxEnergy}\nCurrent Charge: {currentEnergy}\n" +
                $"Color: {color.ToString()}\n" +
                $"Number of doors: {numberOfDoors}\n");
            str.Append("Wheel info:\n");
            str.Append(wheels[0].ToString());
            return str.ToString();
        }
    }
}
