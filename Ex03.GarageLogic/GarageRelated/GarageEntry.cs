namespace Ex03.GarageLogic
{
    public class GarageEntry
    {

        
        private Owner owner;
        public EVehicleStatus vehicleStatus { get; set; }
        private Vehicle vehicle;
        public GarageEntry(Vehicle vehicle, string ownerName, string ownerPhone)
        {
            owner = new Owner(ownerName, ownerPhone);
            this.vehicle = vehicle.DeepCopy();
        }
        public string GetOwner()
        {
            return owner.ToString();
        }


        // Maybe delete??
        public void SetStatus(EVehicleStatus status)
        {
            this.vehicleStatus = status;
        }
    }
}
