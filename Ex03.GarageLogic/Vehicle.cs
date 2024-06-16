using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public interface IElectricVehicle
    {
        float m_RemainingEngineTime { get; set; }
        float m_MaxEngineTime { get; }
        void Recharge(float minutes);
    }
    public interface IFuelVehicle
    {
        //remaining fuel

        void Refuel(float i_currentFuel, float i_Amount, eFuelType i_FuelType);

        float m_RemainingFuelLiters { get; set; }

        eFuelType m_FuelType { get; }

        float m_MaxAmountOfFuel { get; }
    }
    /// <summary>
    ///  every vehicle contains the following properties:
    ///  Model Name(String),License Number(String),Remaining Energy Percentage(Fuel/Battery) (float),Wheels, with each wheel containing the following:
    /// </summary>

    public class Vehicle
    {
        public string m_ModelName;
        public string m_LicenseNumber;
        public float m_RemainingEnergy;
        public List<Wheel> m_Wheels = new List<Wheel>();
        public string m_OwnerName { get; set; }
        public string m_OwnerPhoneNumber { get; set; }
        public eVehicleStatus m_Status { get; set; } = eVehicleStatus.InRepair;
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }

        public Vehicle(string i_modelName, string i_licenseNumber, float i_remainingEnergy, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_licenseNumber;
            m_RemainingEnergy = i_remainingEnergy;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Status = eVehicleStatus.InRepair;
        }

        public void InitializeWheels(int i_numWheels, string i_manufacturer, float i_currentAirPressure, float i_maxAirPressure)
        {
            for (int i = 0; i < i_numWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_manufacturer, i_currentAirPressure, i_maxAirPressure));
            }
        }
    }
}
