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

        public Motorcycle(string modelName, string licenseNumber, float remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume) : base(modelName, licenseNumber, remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            LicenseType = licenseType;
            EngineVolume = engineVolume;
            InitializeWheels(2, "Michelin", 33, 33);
        }
    }

    public class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private float m_RemainingEngineTime;
        private float m_MaxEngineTime = 25;

        public ElectricMotorcycle(string modelName, string licenseNumber, float remainingEnergy, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingEngineTime) : base(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, vehicleStatus, licenseType, engineVolume)
        {
            m_RemainingEngineTime = remainingEngineTime;
            m_MaxEngineTime = 2;
        }

        float IElectricVehicle.m_RemainingEngineTime 
        { 
            get { return m_RemainingEngineTime; }
            set { m_RemainingEngineTime = value; }
        }
        float IElectricVehicle.m_MaxEngineTime => 25;


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
        private float m_RemainingFuelLiters;
        private float m_MaxAmountOfFuel = 55;
        private FuelType m_FuelType = FuelType.Octane98;

        public FuelMotorcycle(string modelName, string licenseNumber, float remainingEnergy, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, LicenseType licenseType, int engineVolume, float remainingFuelLiters) : base(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, vehicleStatus, licenseType, engineVolume)
        {
            m_RemainingFuelLiters = remainingFuelLiters;
        }

        float IFuelVehicle.m_RemainingFuelLiters
        {
            get { return m_RemainingFuelLiters; }
            set { m_RemainingFuelLiters = value; }
        }

        float IFuelVehicle.m_MaxAmountOfFuel => 55;
        FuelType IFuelVehicle.m_FuelType => m_FuelType;

        // Implementing the Refuel method
        public void Refuel(float i_currentFuel, float maxFuel, float i_Amount, FuelType i_FuelType)
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
