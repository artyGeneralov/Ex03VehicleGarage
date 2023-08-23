using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    class Car : Vehicle
    {
        protected override int numberOfWheels => 4;

        public enum Colors
        {
            Black,
            White,
            Red,
            Blue
        }

        private Colors color;
        private int numberOfDoors;

        public Car(string modelName, string licensePlateNumber, IEnergySource energySource, Colors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber, energySource, wheelType)
        {
            if (numberOfDoors < 2 || numberOfDoors > 5) 
            {
                throw new ValueOutOfRangeException();
            }
            this.color = color;
            this.numberOfDoors = numberOfDoors;
        }

    }
}
