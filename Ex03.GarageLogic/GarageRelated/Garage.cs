using System.Collections.Generic;
using System;
using System.Text;

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

        public bool IsVehicleInGarage(string licensePlateNum)
        {
            bool isInGarage = false;
            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    isInGarage = true;
                }
            }
            return isInGarage;
        }

        public EVehicleStatus getVehicleStatus(string licensePlateNum)
        {
            EVehicleStatus status = 0;


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

        public void SetVehicleStatus(string licensePlateNum, EVehicleStatus status)
        {


            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    entry.SetStatus(status);
                }
            }
        }


        public string ShowAllVehicles()
        {
            StringBuilder sb = new StringBuilder();
            foreach (GarageEntry entry in garageEntryList)
            {
                sb.Append(entry.ToStringShort() + "\n");
            }
            return sb.ToString();
        }

        public string ShowFullVehicleData(string licensePlateNum)
        {
            string str = "";
            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    str = entry.ToStringLong();
                }
            }

            return str;
        }

        public string ShowAllVehiclesByStatus(EVehicleStatus status)
        {
            StringBuilder sb = new StringBuilder();
            foreach (GarageEntry entry in garageEntryList)
            {
                if (entry.GetStatus() == status)
                {
                    sb.Append(entry.ToStringShort() + "\n");
                }
            }
            return sb.ToString();
        }

        public void InflateTires(string licensePlateNum)
        {


            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    curVehicle.inflateAllWheels();
                }
            }
        }


        public void RefuelOrRecharge(string licensePlateNum, EEnergySources sourceToFill, float energyAmount, EFuelTypes? fuelType = null)
        {
            foreach (GarageEntry entry in garageEntryList)
            {
                Vehicle curVehicle = entry.GetVehicle();
                if (curVehicle.GetLicensePlateNumber().Equals(licensePlateNum))
                {
                    if (curVehicle is IFueled && sourceToFill == EEnergySources.Fueled)
                    {
                        if (fuelType != null)
                        {
                            ((IFueled)curVehicle).Refuel(energyAmount, (EFuelTypes)fuelType);
                        }

                    }
                    else if (curVehicle is IElectrical && sourceToFill == EEnergySources.Electrical)
                    {
                        ((IElectrical)curVehicle).Recharge(energyAmount);
                    }
                    else
                    {
                        throw new ArgumentException("Fuel types not matching!");
                    }
                }
            }
        }

    }
}
