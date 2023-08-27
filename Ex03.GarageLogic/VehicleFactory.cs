

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

                case EVehicleTypes.FueledCar:
                    // create energy source
/*                    public FueledCar(string modelName, string licensePlateNumber, float maxFuel, float currentFuel, EFuelTypes fuelType, EColors color, int numberOfDoors, Wheel wheelType)
                : base(modelName, licensePlateNumber, maxFuel, currentFuel, wheelType)*/
                    // create color

                    // create wheel type

                    vehicle = new FueledCar
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        maxFuel: float.Parse(args["maxFuel"]),
                        currentFuel: float.Parse(args["currentFuel"]),
                        fuelType: (EFuelTypes) Enum.Parse(typeof(EFuelTypes), args["fuelType"]),
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

                default:
                    throw new ArgumentException();
                
            }

            
        }
    }
}
