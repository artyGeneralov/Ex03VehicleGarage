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
            this.vehicle = vehicle.DeepCopy();
        }

        
        public string GetOwner()
        {
            return owner.ToString();
        }

        public Vehicle GetVehicle()
        {
            return vehicle.DeepCopy();
        }


        // Maybe delete??
        public void SetStatus(EVehicleStatus status)
        {
            this.vehicleStatus = status;
        }
    }
}
