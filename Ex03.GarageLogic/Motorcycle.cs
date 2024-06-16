using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public eLicenseType LicenseType { get; set; }
        public int EngineVolume { get; set; }

        public Motorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, eVehicleStatus i_vehicleStatus, eLicenseType i_licenseType, int i_engineVolume) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            LicenseType = i_licenseType;
            EngineVolume = i_engineVolume;
            InitializeWheels(2, "Michelin", 33, 33);
        }
    }

    public class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private float m_RemainingEngineTime;
        private float m_MaxEngineTime = 2.5f;

        public ElectricMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, eVehicleStatus i_vehicleStatus, eLicenseType i_licenseType, int i_engineVolume, float i_remainingEngineTime) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume)
        {
            m_RemainingEngineTime = i_remainingEngineTime;
            m_MaxEngineTime = 2.5f;
        }

        float IElectricVehicle.m_RemainingEngineTime 
        { 
            get { return m_RemainingEngineTime; }
            set { m_RemainingEngineTime = value; }
        }
        float IElectricVehicle.m_MaxEngineTime => 2.5f;


        public void Recharge(float i_hours)
        {
            if (m_RemainingEngineTime + i_hours <= m_MaxEngineTime)
            {
                m_RemainingEngineTime += i_hours;
            }
            else
            {
                while(m_RemainingEngineTime + i_hours > m_MaxEngineTime)
                {
                    Console.WriteLine($"The amount of hours currently is{m_RemainingEngineTime} and the amount of hours you want to add is {i_hours}");
                    Console.WriteLine("The amount of hours exceeds the maximum recharge time of 2.5 hours.");
                    Console.WriteLine("Please enter a valid amount of hours to add:");
                    i_hours = float.Parse(Console.ReadLine());
                }
                m_RemainingEngineTime += i_hours;
                return;
            }

        }
    }

    public class FuelMotorcycle : Motorcycle, IFuelVehicle
    {
        private float m_RemainingFuelLiters;
        private float m_MaxAmountOfFuel = 5.5f;
        private eFuelType m_FuelType = eFuelType.Octane98;

        public FuelMotorcycle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, eVehicleStatus i_vehicleStatus, eLicenseType i_licenseType, int i_engineVolume, float i_remainingFuelLiters) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_licenseType, i_engineVolume)
        {
            m_RemainingFuelLiters = i_remainingFuelLiters;
        }

        float IFuelVehicle.m_RemainingFuelLiters
        {
            get { return m_RemainingFuelLiters; }
            set { m_RemainingFuelLiters = value; }
        }

        float IFuelVehicle.m_MaxAmountOfFuel => 5.5f;
        eFuelType IFuelVehicle.m_FuelType => m_FuelType;

        // Implementing the Refuel method
        public void Refuel(float i_currentFuel, float i_Amount, eFuelType i_FuelType)
        {
            if (m_RemainingFuelLiters + i_Amount <= m_MaxAmountOfFuel)
            {
                m_RemainingFuelLiters += i_Amount;
            }
            else
            {
                while(m_RemainingFuelLiters + i_Amount > m_MaxAmountOfFuel)
                {
                    Console.WriteLine($"The amount of fuel currently is{i_currentFuel} and the amount of fuel you want to add is {i_Amount}");
                    Console.WriteLine("The amount of fuel exceeds the maximum fuel capacity time of 5.5L.");
                    Console.WriteLine("Please enter a valid amount of fuel to add:");
                    i_Amount = float.Parse(Console.ReadLine());
                }
                m_RemainingFuelLiters += i_Amount;
                
                return;
            }
        }
    }
}
