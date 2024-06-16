﻿using System;
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
        public static FuelCar CreateFuelCar(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, CarColor color, int doors, float remainingFuelLiters)
        {  
            
            return new FuelCar(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, color, doors, 0);
        }

        public static ElectricCar CreateElectricCar(string modelName, string licenseNumber, float remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, CarColor color, int doors, float remainingEngineTime)
        {
            List<Wheel> wheelsList = new List<Wheel>();
            wheelsList.Add(new Wheel("Michelin", 31, 31));
            return new ElectricCar(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, color, doors, 0);
        }

        public static FuelMotorcycle CreateFuelMotorcycle(string licenseNumber, string modelName, float remainingEnergy, List<Wheel> wheels, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingFuelLiters)
        {
            

            return new FuelMotorcycle(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, licenseType, engineVolume, remainingFuelLiters);
        }

        public static ElectricMotorcycle CreateElectricMotorcycle(string licenseNumber, string modelName, float remainingEnergy, List<Wheel> wheels, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingEngineTime)
        {
            
            
            return new ElectricMotorcycle(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, licenseType, engineVolume, remainingEngineTime);
        }

        public static Truck CreateTruck(string licenseNumber, string modelName, float remainingEnergy, List<Wheel> wheels, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, bool isCarryingDangerousMaterials, float cargoVolume, float i_RemainingFuelLiters)
        {
            
            
            return new Truck(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, isCarryingDangerousMaterials, cargoVolume, i_RemainingFuelLiters);
        }

        public void addWheels(List<Wheel> wheels, int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }
}
