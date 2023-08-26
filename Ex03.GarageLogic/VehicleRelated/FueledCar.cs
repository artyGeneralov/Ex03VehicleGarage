

using System.Collections.Generic;
using System.Linq;
using System;

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





        public override List<string> GetArgumentsList()
        {
            List<string> args = new List<string>() { "modelName", "licensePlateNumber", "maxFuel", "currentFuel", "fuelType", "energySource", "color", "numberOfDoors" };
            args.Concat(Wheel.GetArgumentList());
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
    }
}
