
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Vehicle, IElectrical
    {
        private const int _maxNumOfWheels = 2;

        private ELicenseTypes licenseType;
        private int engineVolume;

        protected override int numberOfWheels => _maxNumOfWheels;

        public ElectricMotorcycle()
        {

        }

        public ElectricMotorcycle(string modelName, string licensePlateNumber, float maxCharge, float currentCharge, ELicenseTypes licenseType, int engineVolume, Wheel wheelType)
                : base(modelName, licensePlateNumber, maxCharge, currentCharge, wheelType)
        {
            this.engineVolume = engineVolume;
            this.licenseType = licenseType;
        }





        public override Dictionary<string, Type> GetArgumentsDictionary()
        {

            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("modelName", typeof(string));
            args.Add("licensePlateNumber", typeof(string));
            args.Add("maxCharge", typeof(float));
            args.Add("currentCharge", typeof(float));
            args.Add("licenseType", typeof(ELicenseTypes));
            args.Add("engineVolume", typeof(int));
            Dictionary<string, Type> wheelsDict = Wheel.GetArgumentsDictionary();
            foreach (KeyValuePair<string, Type> pair in wheelsDict)
            {
                args.Add(pair.Key, pair.Value);
            }
            return args;
        }

        public void Recharge(float energyAmount)
        {

            if (currentEnergy + energyAmount >= maxEnergy)
            {
                throw new ArgumentException("Attemp to overcharge");
            }
            else
            {
                currentEnergy += energyAmount;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append($"\nMax Charge: {maxEnergy}\nCurrent Charge: {currentEnergy}\n" +
                $"License Type: {licenseType.ToString()}\n" +
                $"Engine Volume: {engineVolume}\n");
            str.Append("Wheel info:\n");
            str.Append(wheels[0].ToString());
            return str.ToString();
        }
    }
}
