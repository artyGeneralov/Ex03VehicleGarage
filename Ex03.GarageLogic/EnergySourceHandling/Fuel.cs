using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Fuel : IFueled
    {



        protected float currentFuelAmount;
        protected readonly float maxFuelAmount;
        private readonly EFuelTypes fuelType;

        
        public Fuel(float maxFuelAmount, float currentAmount, EFuelTypes fuelType)
        {
            this.maxFuelAmount = maxFuelAmount;
            this.fuelType = fuelType;
        }

        public void Refuel(float amount, EFuelTypes fuelType)
        {
            if (this.fuelType != fuelType)
            {
                throw new ArgumentException();
            }

            if(currentFuelAmount + amount > maxFuelAmount)
            {
                throw new ValueOutOfRangeException();
            }

            currentFuelAmount += amount;
            
        }

        public IEnergySource Clone()
        {
            return new Fuel(maxFuelAmount, currentFuelAmount, fuelType);
        }

    }
}
