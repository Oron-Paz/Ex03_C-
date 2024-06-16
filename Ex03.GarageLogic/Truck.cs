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


        public Truck(string modelName, string licenseNumber, float remainingEnergy, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, bool carryingHazardousMaterials, float cargoVolume, float i_RemainingFuelLiters) : base(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber)
        {
            m_CarryingHazardousMaterials = carryingHazardousMaterials;
            m_CargoVolume = cargoVolume;
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

        public void Refuel(float remainingEnergy, float maxAmountOfFuel , float i_Amount, FuelType i_FuelType)
        {
            if (remainingEnergy + i_Amount <= maxAmountOfFuel)
            {
                remainingEnergy += i_Amount;
            }
        }

    }
}
