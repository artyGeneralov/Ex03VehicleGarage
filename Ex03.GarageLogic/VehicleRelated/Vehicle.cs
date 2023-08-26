﻿using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected abstract int numberOfWheels { get; }
        private string modelName;
        private string licensePlateNumber;
        private EnergySource energySource; // not this
        protected float maxEnergy, currentEnergy;

        private List<Wheel> wheels;

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
            copiedVehicle.energySource = this.energySource.ShallowCopy();
            copiedVehicle.wheels = this.wheels.Select(w => w.ShallowCopy()).ToList();
            return copiedVehicle;
        }

        public string GetLicenseplateNumber()
        {
            return licensePlateNumber;
        }

        public EnergySource GetEnergySource()
        {
            return energySource;
        }
        public override string ToString()
        {
            return $"Model name: {modelName}\nLicense plate number: {licensePlateNumber}";
        }


        public abstract List<string> GetArgumentsList();



    }
}