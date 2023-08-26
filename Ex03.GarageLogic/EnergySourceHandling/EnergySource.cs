using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public abstract List<string> GetArgumentList();

        public abstract EnergySource ShallowCopy();
    }
}
