
using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Electrical : EnergySource
    {
        private float currentRemainingHours;
        private readonly float maxRemainingHours;
        public Electrical()
        {

        }
        public Electrical(float currentRemainingHourse, float maxRemainingHours)
        {
            this.currentRemainingHours = currentRemainingHourse;
            this.maxRemainingHours = maxRemainingHours;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hours">hours to recharge</param>
        /// <exception cref="ValueOutOfRangeException"/>
        public void Recharge(float hours)
        {

                if (currentRemainingHours + hours >= maxRemainingHours)
                {
                    throw new ArgumentException("Attemp to overfuel");
                }
                else
                {
                currentRemainingHours += hours;
                }
            
        }

        public override List<string> GetArgumentList()
        {
            return new List<string> { "currentAmount", "maxAmount", "fuelType" };
        }

        public override EnergySource ShallowCopy()
        {
            return (Electrical)this.MemberwiseClone();
        }
    }
}
