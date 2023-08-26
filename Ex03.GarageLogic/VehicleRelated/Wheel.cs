using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string manufacturer;
        private float currentAirPressure;
        private float maxAirPressure;


        public Wheel(string manufacturer, float currentAirPressure, float maxAirPressure)
        {
            this.manufacturer = manufacturer;
            this.currentAirPressure = currentAirPressure;
            this.maxAirPressure = maxAirPressure;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"> amount to inflate </param>
        /// <exception cref="ValueOutOfRangeException"/>
        public void inflate(float amount)
        {
            if(currentAirPressure + amount > maxAirPressure)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                currentAirPressure += amount;
            }
        }

        public Wheel ShallowCopy()
        {
            return (Wheel)this.MemberwiseClone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"manufacturer = {manufacturer}, current air pressure = {currentAirPressure}, max air pressure = {maxAirPressure}");
            return sb.ToString();
        }

        public static List<string> GetArgumentList() {

            return new List<string>() { "manufacturer", "currentAirPressure", "maxAirPressure" };
        }
    }
}
