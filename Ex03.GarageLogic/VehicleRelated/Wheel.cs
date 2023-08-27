using System.Text;
using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string wheelManufacturer;
        private float currentWheelAirPressure;
        private float maxWheelAirPressure;

        public Wheel(string wheelManufacturer, float currentWheelAirPressure, float maxWheelAirPressure)
        {
            this.wheelManufacturer = wheelManufacturer;
            this.currentWheelAirPressure = currentWheelAirPressure;
            this.maxWheelAirPressure = maxWheelAirPressure;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"> amount to inflate </param>
        /// <exception cref="ValueOutOfRangeException"/>
        public void inflate(float amount)
        {
            if(currentWheelAirPressure + amount > maxWheelAirPressure)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                currentWheelAirPressure += amount;
            }
        }

        public Wheel ShallowCopy()
        {
            return (Wheel)this.MemberwiseClone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"wheelManufacturer: {wheelManufacturer}\nCurrent air pressure: {currentWheelAirPressure}\nMax air pressure: {maxWheelAirPressure}");
            return sb.ToString();
        }

        public static Dictionary<string, Type> GetArgumentsDictionary() 
        {
            //string wheelManufacturer, float currentWheelAirPressure, float maxWheelAirPressure
            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("wheelManufacturer", typeof(string));
            args.Add("currentWheelAirPressure", typeof(float));
            args.Add("maxWheelAirPressure", typeof(float));
            return args;
        }
    }
}
