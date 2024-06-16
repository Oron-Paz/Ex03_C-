using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, IFuelVehicle
    {
        public bool m_CarryingHazardousMaterials;
        public float m_CargoVolume;
        //private FuelType m_FuelType;
        private float m_MaxAmountOfFuel;
        private float m_RemainingFuelLiters;


        public Truck(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_ownerName, string i_ownerPhoneNumber, VehicleStatus i_vehicleStatus, bool i_carryingHazardousMaterials, float i_cargoVolume, float i_RemainingFuelLiters) : base(i_modelName, i_licenseNumber, i_remainingEnergy, i_ownerName, i_ownerPhoneNumber)
        {
            m_CarryingHazardousMaterials = i_carryingHazardousMaterials;
            m_CargoVolume = i_cargoVolume;
            //m_FuelType = FuelType.Soler;
            m_RemainingFuelLiters = i_RemainingFuelLiters;
            m_MaxAmountOfFuel = 120;
            InitializeWheels(12 , "Michelin", 28, 28);
        }

        float IFuelVehicle.m_RemainingFuelLiters 
        { 
            get { return m_RemainingFuelLiters; }
            set { m_RemainingFuelLiters = value; }
        }
        float IFuelVehicle.m_MaxAmountOfFuel => 120;

        FuelType IFuelVehicle.m_FuelType => FuelType.Soler;

        public void Refuel(float i_remainingEnergy, float i_Amount, FuelType i_FuelType)
        {
            if (i_remainingEnergy + i_Amount <= m_MaxAmountOfFuel)
            {
                i_remainingEnergy += i_Amount;
            }
        }

    }
}
