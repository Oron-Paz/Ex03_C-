﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public LicenseType LicenseType { get; set; }
        public int EngineVolume { get; set; }

        public Motorcycle(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume) : base(modelName, licenseNumber, remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            LicenseType = licenseType;
            EngineVolume = engineVolume;
            wheels.Add(new Wheel("Michelin", 33, 33));
            wheels.Add(new Wheel("Michelin", 33, 33));
        }
    }

    public class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private float m_RemainingEngineTime;
        private float m_MaxEngineTime;

        public ElectricMotorcycle(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingEngineTime, float maxEngineTime) : base(modelName, licenseNumber, remainingEnergy, wheels, ownerName, ownerPhoneNumber, vehicleStatus, licenseType, engineVolume)
        {
            m_RemainingEngineTime = remainingEngineTime;
            m_MaxEngineTime = 2;
        }

        float IElectricVehicle.m_RemainingEngineTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float IElectricVehicle.m_MaxEngineTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        

        public void Recharge(float minutes)
        {
            if (m_RemainingEngineTime + minutes <= m_MaxEngineTime)
            {
                m_RemainingEngineTime += minutes;
            }
        }
    }

    public class FuelMotorcycle : Motorcycle, IFuelVehicle
    {
        private FuelType m_FuelType;
        private float m_RemainingFuelLiters;
        private float m_MaxAmountOfFuel;

        public FuelMotorcycle(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingFuelLiters) : base(modelName, licenseNumber, remainingEnergy, wheels, ownerName, ownerPhoneNumber, vehicleStatus, licenseType, engineVolume)
        {
            m_FuelType = FuelType.Octane98;
            m_RemainingFuelLiters = remainingFuelLiters;
            m_MaxAmountOfFuel = 55;
        }

        float IFuelVehicle.m_RemainingFuelLiters { get; set; }
        float IFuelVehicle.m_MaxAmountOfFuel { get; set; }
        FuelType IFuelVehicle.m_FuelType { get ; set ; }

        public void Refuel(float currentFuel, float maxFuel, float i_Amount, FuelType i_FuelType)
        {
            if (m_RemainingFuelLiters + i_Amount <= m_MaxAmountOfFuel)
            {
                m_RemainingFuelLiters += i_Amount;
            }
        }
    }
}
