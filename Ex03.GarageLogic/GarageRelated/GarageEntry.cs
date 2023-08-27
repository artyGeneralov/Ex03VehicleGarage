using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageEntry
    {

        // add a way to modify car with entry information?

        private Owner owner;
        public EVehicleStatus vehicleStatus { get; set; }
        private Vehicle vehicle;

        // but we already get a vehicle!!
        public GarageEntry(Vehicle vehicle, string ownerName, string ownerPhone)
        {
            owner = new Owner(ownerName, ownerPhone);
            this.vehicle = vehicle;
        }


        public string GetOwner()
        {
            return owner.ToString();
        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }


        // Maybe delete??
        public void SetStatus(EVehicleStatus status)
        {
            this.vehicleStatus = status;
        }

        public EVehicleStatus GetStatus()
        {
            return this.vehicleStatus;
        }

        public string GetLicensePlateNumber()
        {
            return vehicle.GetLicensePlateNumber();
        }

        public void InflateAllTires()
        {
            vehicle.inflateAllWheels();
        }
        public string ToStringLong()
        {


            StringBuilder sb = new StringBuilder();
            sb.Append($"License number: {vehicle.GetLicensePlateNumber()}\n" +
                   $"Model: {vehicle.GetModelName()}\n" +
                   $"Owner Name: {owner.name}\n" +
                   $"Status: {vehicleStatus}\n");
            sb.Append(vehicle.ToString());

            return sb.ToString();
        }
        public string ToStringShort()
        {
            return $"License: {GetLicensePlateNumber()} Status: {GetStatus().ToString()}";
        }
    }
}
