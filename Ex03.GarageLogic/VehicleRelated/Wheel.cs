using System.Text;

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
    }
}
