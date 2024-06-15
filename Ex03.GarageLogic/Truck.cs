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
        private bool m_CarryingHazardousMaterials;
        private float m_CargoVolume;
        private FuelType m_FuelType;
        private float m_maxAmountOfFuel;
        private float m_remainingFuelLiters


        public Truck(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, bool carryingHazardousMaterials, float cargoVolume, float currentFuelInLiters) : base(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber)
        {
            m_CarryingHazardousMaterials = carryingHazardousMaterials;
            m_CargoVolume = cargoVolume;
            m_FuelType = FuelType.Soler;
            m_remainingFuelLiters = currentFuelInLiters;
            m_maxAmountOfFuel = 120;

            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));
            wheels.Add(new Wheel("Michelin", 28, 28));

        }

        public FuelType FuelType => throw new NotImplementedException();

        public float RemainingFuelLiters => throw new NotImplementedException();

        public void Refuel(float remainingEnergy, float maxAmountOfFuel , float i_Amount, FuelType i_FuelType)
        {
            if (remainingEnergy + i_Amount <= maxAmountOfFuel)
            {
                remainingEnergy += i_Amount;
            }
        }

    }
}
