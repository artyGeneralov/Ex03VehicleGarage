using System.Text;
using System.Collections.Generic;
using System;

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
            sb.Append($"Manufacturer: {manufacturer}\nCurrent air pressure: {currentAirPressure}\nMax air pressure: {maxAirPressure}");
            return sb.ToString();
        }

        public static Dictionary<string, Type> GetArgumentsDictionary() 
        {
            //string manufacturer, float currentAirPressure, float maxAirPressure
            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("manufacturer", typeof(string));
            args.Add("currentAirPressure", typeof(float));
            args.Add("maxAirPressure", typeof(float));
            return args;
        }
    }
}
