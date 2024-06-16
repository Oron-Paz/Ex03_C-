using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        // Supported vehicle types enumeration

        // Method to create a vehicle based on the specified type

        // Private methods to create specific types of vehicles
        public static FuelCar CreateFuelCar(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, CarColor color, int doors, float remainingFuelLiters)
        {  
            
            return new FuelCar(modelName, licenseNumber, remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, VehicleStatus.InRepair, color, doors, 0);
        }

        public static ElectricCar CreateElectricCar(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, CarColor color, int doors, float remainingEngineTime)
        {
            
            return new ElectricCar(modelName, licenseNumber, remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, VehicleStatus.InRepair, color, doors, 0);
        }

        public static FuelMotorcycle CreateFuelMotorcycle(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingFuelLiters)
        {
            

            return new FuelMotorcycle(modelName, licenseNumber, remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, licenseType, engineVolume, remainingFuelLiters);
        }

        public static ElectricMotorcycle CreateElectricMotorcycle(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingEngineTime)
        {
            
            
            return new ElectricMotorcycle(modelName, licenseNumber, remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, licenseType, engineVolume, remainingEngineTime);
        }

        public static Truck CreateTruck(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, bool isCarryingDangerousMaterials, float cargoVolume, float i_RemainingFuelLiters)
        {
            
            
            return new Truck(modelName, licenseNumber, remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, isCarryingDangerousMaterials, cargoVolume, i_RemainingFuelLiters);
        }
    }
}
