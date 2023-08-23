namespace Ex03.GarageLogic
{
    public interface IElectric : IEnergySource
    {
        void Recharge(float hours);
    }
}
