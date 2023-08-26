using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        protected override int numberOfWheels => 12;
        private bool isCooled;
        private float cargoVolume;

        public Truck(string modelName, string licensePlateNumber, EnergySource energySource, bool isCooled, float cargoVolume, Wheel wheelType)
                : base(modelName, licensePlateNumber, energySource, wheelType)
        {
            this.isCooled = isCooled;
            this.cargoVolume = cargoVolume;
        }

        public override List<string> GetArgumentsList()
        {
            throw new NotImplementedException();
        }
    }
}
