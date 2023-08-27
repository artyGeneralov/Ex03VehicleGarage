

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{


    
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(EVehicleTypes vehicleType, Dictionary<string, string> args)
        {

            Vehicle vehicle;



            Wheel wheel = new Wheel(
                manufacturer: args["manufacturer"],
                currentAirPressure: float.Parse(args["currentAirPressure"]),
                maxAirPressure: float.Parse(args["maxAirPressure"])
                );




            switch (vehicleType)
            {

                case EVehicleTypes.FueledCar:
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

                case EVehicleTypes.ElectricCar:
                    vehicle = new ElectricCar
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        maxCharge: float.Parse(args["maxCharge"]),
                        currentCharge: float.Parse(args["currentCharge"]),
                        color: (EColors)Enum.Parse(typeof(EColors), args["color"]),
                        numberOfDoors: int.Parse(args["numberOfDoors"]),
                        wheelType: wheel
                     );
                    break;

                case EVehicleTypes.FueledMotorcycle:
                    vehicle = new FueledMotorcycle
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        maxFuel: float.Parse(args["maxFuel"]),
                        currentFuel: float.Parse(args["currentFuel"]),
                        fuelType: (EFuelTypes)Enum.Parse(typeof(EFuelTypes), args["fuelType"]),
                        licenseType: (ELicenseTypes)Enum.Parse(typeof(ELicenseTypes), args["licenseType"]),
                        engineVolume: int.Parse(args["engineVolume"]),
                        wheelType: wheel
                     );
                    break;

                case EVehicleTypes.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        maxCharge: float.Parse(args["maxFuel"]),
                        currentCharge: float.Parse(args["currentFuel"]),
                        licenseType: (ELicenseTypes)Enum.Parse(typeof(ELicenseTypes), args["licenseType"]),
                        engineVolume: int.Parse(args["engineVolume"]),
                        wheelType: wheel
                     );
                    break;

                case EVehicleTypes.Truck:
                    vehicle = new Truck
                    (
                        modelName: args["modelName"],
                        licensePlateNumber: args["licensePlateNumber"],
                        maxFuel: float.Parse(args["maxFuel"]),
                        currentFuel: float.Parse(args["currentFuel"]),
                        fuelType: (EFuelTypes)Enum.Parse(typeof(EFuelTypes), args["fuelType"]),
                        isCooled:bool.Parse(args["isCooled"]),
                        cargoVolume: float.Parse(args["cargoVolume"]),
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
                    return new ElectricCar();
                case EVehicleTypes.FueledMotorcycle:
                    return new FueledMotorcycle();
                case EVehicleTypes.ElectricMotorcycle:
                    return new ElectricMotorcycle();
                case EVehicleTypes.Truck:
                    return new Truck();

                default:
                    throw new ArgumentException();
                
            }

            
        }
    }
}
