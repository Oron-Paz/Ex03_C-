using System;
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

        public Motorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, LicenseType i_licenseType, int i_engineVolume) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            LicenseType = i_licenseType;
            EngineVolume = i_engineVolume;
            InitializeWheels(2, "Michelin", 33, 33);
        }
    }

    public class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private float m_RemainingEngineTime;
        private float m_MaxEngineTime = 25;

        public ElectricMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, LicenseType i_licenseType, int i_engineVolume, float i_remainingEngineTime) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume)
        {
            m_RemainingEngineTime = i_remainingEngineTime;
            m_MaxEngineTime = 2;
        }

        float IElectricVehicle.m_RemainingEngineTime 
        { 
            get { return m_RemainingEngineTime; }
            set { m_RemainingEngineTime = value; }
        }
        float IElectricVehicle.m_MaxEngineTime => 25;


        public void Recharge(float i_minutes)
        {
            if (m_RemainingEngineTime + i_minutes <= m_MaxEngineTime)
            {
                m_RemainingEngineTime += i_minutes;
            }

        }
    }

    public class FuelMotorcycle : Motorcycle, IFuelVehicle
    {
        private float m_RemainingFuelLiters;
        private float m_MaxAmountOfFuel = 55;
        private FuelType m_FuelType = FuelType.Octane98;

        public FuelMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, LicenseType i_licenseType, int i_engineVolume, float i_remainingFuelLiters) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume)
        {
            m_RemainingFuelLiters = i_remainingFuelLiters;
        }

        float IFuelVehicle.m_RemainingFuelLiters
        {
            get { return m_RemainingFuelLiters; }
            set { m_RemainingFuelLiters = value; }
        }

        float IFuelVehicle.m_MaxAmountOfFuel => 55;
        FuelType IFuelVehicle.m_FuelType => m_FuelType;

        // Implementing the Refuel method
        public void Refuel(float i_currentFuel, float i_Amount, FuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException($"Fuel type {i_FuelType} is not compatible with {m_FuelType}");
            }

            if (m_RemainingFuelLiters + i_Amount > m_MaxAmountOfFuel)
            {
                throw new ArgumentException($"Amount of fuel exceeds the tank capacity of {m_MaxAmountOfFuel} liters.");
            }

            m_RemainingFuelLiters += i_Amount;
        }
    }
}
