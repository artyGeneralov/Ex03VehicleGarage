using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        protected override int numberOfWheels => 2;

        public enum MotorcycleLicences
        {
            A,
            A1,
            A2,
            AB
        }

        private MotorcycleLicences licenseType;
        private int motorVolume;
        public Motorcycle(string modelName, string licensePlateNumber, EnergySource energySource, MotorcycleLicences licenseType, int motorVolume, Wheel wheelType) 
            : base(modelName, licensePlateNumber, energySource, wheelType)
        {
            this.licenseType = licenseType;
            this.motorVolume = motorVolume;
        }

        public override List<string> GetArgumentsList()
        {
            throw new NotImplementedException();
        }
    }
}
