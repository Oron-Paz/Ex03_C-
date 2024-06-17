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
        public static FuelCar CreateFuelCar(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_vehicleStatus, eCarColor i_color, int i_doors, float i_remainingFuelLiters)
        {  
            
            return new FuelCar(i_modelName, i_licenseNumber, i_remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair, i_color, i_doors, i_remainingFuelLiters);
        }

        public static ElectricCar CreateElectricCar(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_vehicleStatus, eCarColor i_color, int i_doors, float i_remainingEngineTime)
        {
            
            return new ElectricCar(i_modelName, i_licenseNumber, i_remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair, i_color, i_doors, i_remainingEngineTime);
        }

        public static FuelMotorcycle CreateFuelMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_vehicleStatus, eLicenseType i_licenseType, int i_engineVolume, float i_remainingFuelLiters)
        {
            
            float remainingFuelLiters = i_remainingEnergy/100 * 5.5f;
            
            return new FuelMotorcycle(i_modelName, i_licenseNumber, i_remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume, remainingFuelLiters);
        }

        public static ElectricMotorcycle CreateElectricMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_vehicleStatus, eLicenseType i_licenseType, int i_engineVolume, float i_remainingEngineTime)
        {
            
            float remainingEngineTime = i_remainingEnergy/100 * 2.5f;
            return new ElectricMotorcycle(i_modelName, i_licenseNumber, i_remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume, remainingEngineTime);
        }

        public static Truck CreateTruck(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_vehicleStatus, bool i_isCarryingDangerousMaterials, float i_cargoVolume, float i_RemainingFuelLiters)
        {
            float remainingFuelLiters = i_remainingEnergy/100 * 120;
            
            return new Truck(i_modelName, i_licenseNumber, i_remainingEnergy, i_OwnerName, i_OwnerPhoneNumber, i_vehicleStatus, i_isCarryingDangerousMaterials, i_cargoVolume, remainingFuelLiters);
        }
    }
}
