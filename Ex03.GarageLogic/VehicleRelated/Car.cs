/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{



*//*    interface IElectric
    {
        public void Charge(float hours);
    }

    interface IFueled
    {
        public void Fuel(float fuel);
    }


    class FueledCar : IFueled
    { 
        
        
    }

    class ElectricCar : IElectric
    {

    }*//*
    class Car : Vehicle
    {
        private const int _numberOfWheels = 5;
        
        
        protected override int numberOfWheels => _numberOfWheels;



        private EColors color;
        private int numberOfDoors;

        public Car(EnergySource energySource) : base (energySource)
        {

        }
        public Car(string modelName, string licensePlateNumber, EnergySource energySource, EColors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber, energySource, wheelType)
        {
            if (numberOfDoors < 2 || numberOfDoors > 5) 
            {
                throw new ValueOutOfRangeException();
            }
            this.color = color;
            this.numberOfDoors = numberOfDoors;
        }

        public override List<string> GetArgumentsList()
        {
            List<string> args = new List<string>() { "modelName", "licensePlateNumber", "energySource", "color", "numberOfDoors" };
            args.Concat(Wheel.GetArgumentList());
            return args;
        }

    }
}
*/