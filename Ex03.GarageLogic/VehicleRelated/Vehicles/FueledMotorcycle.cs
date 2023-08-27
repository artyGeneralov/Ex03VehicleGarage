using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FueledMotorcycle:Vehicle, IFueled
    {
        private const int _maxNumOfWheels = 2;

        private ELicenseTypes licenseType;
        private int engineVolume;
        private EFuelTypes fuelType;

        protected override int numberOfWheels => _maxNumOfWheels;

        public FueledMotorcycle()
        {

        }

        public FueledMotorcycle(string modelName, string licensePlateNumber, float maxFuel, float currentFuel, EFuelTypes fuelType, ELicenseTypes licenseType, int engineVolume, Wheel wheelType)
                : base(modelName, licensePlateNumber, maxFuel, currentFuel, wheelType)
        {
            this.fuelType = fuelType;
            this.engineVolume = engineVolume;
            this.licenseType = licenseType;
        }





        public override Dictionary<string, Type> GetArgumentsDictionary()
        {

            Dictionary<string, Type> args = new Dictionary<string, Type>();
            args.Add("modelName", typeof(string));
            args.Add("licensePlateNumber", typeof(string));
            args.Add("maxFuel", typeof(float));
            args.Add("currentFuel", typeof(float));
            args.Add("fuelType", typeof(EFuelTypes));
            args.Add("licenseType", typeof(ELicenseTypes));
            args.Add("engineVolume", typeof(int));
            Dictionary<string, Type> wheelsDict = Wheel.GetArgumentsDictionary();
            foreach (KeyValuePair<string, Type> pair in wheelsDict)
            {
                args.Add(pair.Key, pair.Value);
            }
            return args;
        }

        public void Refuel(float fuelAmount, EFuelTypes fuelType)
        {

            if (fuelType != this.fuelType)
            {
                throw new ArgumentException("Attempt to fill incorrect fuel type");
            }
            else if (currentEnergy + fuelAmount >= maxEnergy)
            {
                throw new ArgumentException("Attemp to overfuel");
            }
            else
            {
                currentEnergy += fuelAmount;
            }
        }

        public override string ToString()
        {

            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append($"\nMax Fuel: {maxEnergy}\nCurrent Fuel: {currentEnergy}\n" +
                $"Fuel Type: {fuelType.ToString()}\nLicense Type: {licenseType.ToString()}\n" +
                $"Engine Volume: {engineVolume}\n");
            str.Append("Wheel info:\n");
            str.Append(wheels[0].ToString());
            return str.ToString();
        }
    }
}
