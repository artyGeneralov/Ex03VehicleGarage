using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string modelName {get; set;}
        private string licensePlateNumber {get; set;}
        private IEnergySource energySource {get; set;}
        private List<Wheel> wheels {get; set;}
        protected abstract int numberOfWheels { get; }

        protected Vehicle(string modelName, string licensePlateNumber, IEnergySource energySource, Wheel wheelType)
        {
            wheels = new List<Wheel>();
            for(int i = 0; i < numberOfWheels; i++)
            {
                wheels.Add(wheelType.ShallowCopy());
            }

            this.modelName = modelName;
            this.licensePlateNumber = licensePlateNumber;
            this.energySource = energySource;
        }

        public void RefuelOrRecharge(float amount, EFuelTypes? type = null)
        {
            if(energySource is IFueled fueledSource && type.HasValue)
            {
                fueledSource.Refuel(amount, type.Value);
            }
            else if(energySource is IElectric electricSource)
            {
                electricSource.Recharge(amount);
            }
        }

        public Vehicle DeepCopy()
        {
            Vehicle copiedVehicle = (Vehicle)this.MemberwiseClone();
            copiedVehicle.energySource = (IEnergySource)this.energySource.Clone();
            copiedVehicle.wheels = this.wheels.Select(w => w.ShallowCopy()).ToList();
            return copiedVehicle;
        }


    }
}
