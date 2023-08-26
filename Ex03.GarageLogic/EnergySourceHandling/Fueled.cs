using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Fueled : EnergySource
    {
        private float currentAmount;
        private readonly float maxAmount;
        private EFuelTypes fuelType;

        public Fueled()
        {

        }
        public Fueled(Dictionary<string, string> args)
        {
            this.currentAmount = float.Parse(args["currentAmount"]);
        }
        public Fueled(float currentAmount, float maxAmount, EFuelTypes fuelType)
        {
            this.currentAmount = currentAmount;
            this.maxAmount = maxAmount;
            this.fuelType = fuelType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="fuelTypeToFill"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ValueOutOfRangeException"/>
        public void Refuel(float amount, EFuelTypes? fuelTypeToFill)
        {
            if (fuelTypeToFill.HasValue)
            {
                if(fuelTypeToFill != this.fuelType)
                {
                    throw new ArgumentException("Attempt to fill incorrect fuel type");
                }
                else if(currentAmount + amount >= maxAmount)
                {
                    throw new ArgumentException("Attemp to overfuel");
                }
                else
                {
                    currentAmount += amount;
                }
            }
        }

        public override List<string> GetArgumentList()
        {
            return new List<string> { "currentAmount", "maxAmount", "fuelType" };
        }

        public override EnergySource ShallowCopy()
        {
            return (Fueled)this.MemberwiseClone();
        }
    }
}
