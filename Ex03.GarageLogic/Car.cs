using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public CarColor m_color;
        public int m_doors;

        // Constructor
        public Car(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus vehicleStatus, CarColor i_carColor, int i_numDoors) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            m_color = i_carColor;
            m_doors = i_numDoors;

            InitializeWheels(4, "Michelin", 31, 31);
        }
    }

    public class ElectricCar : Car, IElectricVehicle
    {
        private float m_RemainingEngineTime;
        private float m_MaxEngineTime;

        public ElectricCar(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, CarColor i_carColor, int i_numDoors, float i_remainingEngineTime) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_carColor, i_numDoors)
        {
            m_RemainingEngineTime = i_remainingEngineTime;
            m_MaxEngineTime = 35;
    
        }

        float IElectricVehicle.m_RemainingEngineTime 
        {
            get { return  m_RemainingEngineTime; }
            set {  m_RemainingEngineTime = value;}
        }
        float IElectricVehicle.m_MaxEngineTime => 35;

        public void Recharge(float minutes)
        {
            if (m_RemainingEngineTime + minutes <= m_MaxEngineTime)
            {
                m_RemainingEngineTime += minutes;
            }
        }
    }

    public class FuelCar : Car, IFuelVehicle
    {
        //private FuelType m_FuelType = FuelType.Octane95;
        private float m_RemainingFuelLiters;
        private float m_MaxAmountOfFuel = 45;

        public FuelCar(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, CarColor i_carColor, int i_numDoors, float i_remainingFuelLiters) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber, i_vehicleStatus, i_carColor, i_numDoors)
        {
            //m_FuelType = FuelType.Octane95;
            m_RemainingFuelLiters = i_remainingFuelLiters;
            m_MaxAmountOfFuel = 45;
        }

        float IFuelVehicle.m_RemainingFuelLiters
        {
            get { return  m_RemainingFuelLiters; }
            set {  m_RemainingFuelLiters = value;}
        }
        float IFuelVehicle.m_MaxAmountOfFuel => 45;

        FuelType IFuelVehicle.m_FuelType => FuelType.Octane95;

        public void Refuel(float i_currentFuel, float i_Amount, FuelType i_FuelType)
        {
            if (m_RemainingFuelLiters + i_Amount <= m_MaxAmountOfFuel)
            {
                m_RemainingFuelLiters += i_Amount;
            }
        }
    }
}
