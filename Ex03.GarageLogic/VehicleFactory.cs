

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{


    
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(EVehicleTypes vehicleType, Dictionary<string, string> args)
        {

            Vehicle vehicle;


            // create the wheel

            Wheel wheel = new Wheel(
                manufacturer: args["manufacturer"],
                currentAirPressure: float.Parse(args["currentAirPressure"]),
                maxAirPressure: float.Parse(args["maxAirPressure"])
                );




            switch (vehicleType)
            {
               /* public Car(string modelName, string licensePlateNumber, EnergySource energySource, Colors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber, energySource, wheelType)*/
                case EVehicleTypes.FueledCar:
                    // create energy source
                    
                    // create color

                    // create wheel type

                    vehicle = new Car
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        energySource: new Fueled(), //?? -> float value
                        color:(EColors) Enum.Parse(typeof(EColors),args["color"]),
                        numberOfDoors: int.Parse(args["numberOfDoors"]),
                        wheelType: wheel
                     );
                    break;


                default:
                    throw new ArgumentException("Unknown vehicle type");
            }

            return vehicle;
        }



        public static Vehicle CreateEmptyVehicle(EVehicleTypes vehicleType)
        {
            Vehicle vehicle;
            switch (vehicleType)
            {
                case EVehicleTypes.FueledCar:
                    return new FueledCar();
                case EVehicleTypes.ElectricCar:
                    return new Car(new Electrical());
                default:
                    throw new ArgumentException();
                
            }

            
        }
    }
}
