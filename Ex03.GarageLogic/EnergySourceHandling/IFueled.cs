namespace Ex03.GarageLogic
{
    public interface IFueled : IEnergySource
    {
        void Refuel(float amount, EFuelTypes fuleType);
    }
}
