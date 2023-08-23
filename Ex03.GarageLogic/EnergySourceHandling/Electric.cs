using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Electric : IElectric
    {
        private float remainingChargeHours;
        private readonly float maxChargeHours;
        public Electric(float remainingChargeHours, float maxChargeHours)
        {
            this.remainingChargeHours = remainingChargeHours;
            this.maxChargeHours = maxChargeHours;
        }

        public void Recharge(float hours)
        {
            if(remainingChargeHours + hours > maxChargeHours)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                remainingChargeHours += hours;
            }
        }

        public IEnergySource Clone()
        {
            return new Electric(remainingChargeHours, maxChargeHours);
        }
    }
}
