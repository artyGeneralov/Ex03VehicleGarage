using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {

        List<GarageEntry> vehiclesInGarage;

        public Garage()
        {
            vehiclesInGarage = new List<GarageEntry>();
        }

        public void AddToGarage(GarageEntry entry)
        {
            vehiclesInGarage.Add(entry);
        }

        public bool IsVehicleInGarage(string license)
        {
            bool isInGarage = false;
            foreach(GarageEntry entry in vehiclesInGarage)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if(curVehicle.GetLicenseplateNumber().Equals(license))
                {
                    isInGarage = true;
                }
            }
            return isInGarage;
        }

        
    }
}
