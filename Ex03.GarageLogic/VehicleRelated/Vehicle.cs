using System.Collections.Generic;
using System.Linq;
using System;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected abstract int numberOfWheels { get; }
        private string modelName;
        private string licensePlateNumber;
        protected float maxEnergy, currentEnergy;

        protected List<Wheel> wheels;

        protected Vehicle()
        {
            
        }
        protected Vehicle(string modelName, string licensePlateNumber, float maxEnergy, float currentEnergy, Wheel wheelType)
        {
            wheels = new List<Wheel>();
            for(int i = 0; i < numberOfWheels; i++)
            {
                wheels.Add(wheelType.ShallowCopy());
            }

            this.modelName = modelName;
            this.licensePlateNumber = licensePlateNumber;
            this.maxEnergy = maxEnergy;
            this.currentEnergy = currentEnergy;
        }

        public void inflateAllWheels(float amount)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.inflate(amount);
            }
        }


        public Vehicle DeepCopy()
        {
            Vehicle copiedVehicle = (Vehicle)this.MemberwiseClone();
            copiedVehicle.wheels = this.wheels.Select(w => w.ShallowCopy()).ToList();
            return copiedVehicle;
        }

        public string GetLicensePlateNumber()
        {
            return licensePlateNumber;
        }


        public override string ToString()
        {
            return $"Model name: {modelName}\nLicense plate number: {licensePlateNumber}";
        }


        public abstract Dictionary<string, Type> GetArgumentsDictionary();



    }
}
