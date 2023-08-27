using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Garage
    {

        List<GarageEntry> garageEntryList;

        public Garage()
        {
            garageEntryList = new List<GarageEntry>();
        }

        public void AddToGarage(GarageEntry entry)
        {
            garageEntryList.Add(entry);
        }

        public bool IsVehicleInGarage(string license)
        {
            bool isInGarage = false;
            foreach(GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if(curVehicle.GetLicensePlateNumber().Equals(license))
                {
                    isInGarage = true;
                }
            }
            return isInGarage;
        }

        public EVehicleStatus getVehicleStatus(string licensePlateNum)
        {
            EVehicleStatus status = 0;
            if(!IsVehicleInGarage(licensePlateNum))
            {
                throw new ArgumentException("Vehicle does not exist in garage");
            }

            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    status = entry.GetStatus();
                }
            }
            return status;
        }


        public void ShowAllVehicles()
        {
            foreach(GarageEntry entry in garageEntryList)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        public void ShowAllVehiclesByStatus(EVehicleStatus status)
        {
            foreach (GarageEntry entry in garageEntryList)
            {
                if (entry.GetStatus() == status)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
        }


    }
}
