using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        // Supported vehicle types enumeration
        public enum VehicleType
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        // Method to create a vehicle based on the specified type

        // Private methods to create specific types of vehicles
        public static FuelCar CreateFuelCar(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string i_OwnerName, string i_OwnerPhoneNumber, VehicleStatus vehicleStatus, CarColor color, int doors)
        {
            // Example logic to create a FuelCar object
            // You need to implement the logic to create a FuelCar object
            //calucatle remianing fuel liters
            //public FuelCar(string modelName, string licenseNumber, float remainingEnergy, List<Wheel> wheels, string ownerName, string ownerPhoneNumber, VehicleStatus vehicleStatus, CarColor carColor, int numDoors, float remainingFuelLiters)

            return new FuelCar(modelName, licenseNumber, remainingEnergy, wheels, i_OwnerName, i_OwnerPhoneNumber, vehicleStatus, color, doors, 0);
        }

        public static ElectricCar CreateElectricCar(string licenseNumber)
        {
            // Example logic to create an ElectricCar object
            // You need to implement the logic to create an ElectricCar object
            //return new ElectricCar(/* parameters for initialization */);
            return null;
        }

        public static FuelMotorcycle CreateFuelMotorcycle(string licenseNumber)
        {
            // Example logic to create a FuelMotorcycle object
            // You need to implement the logic to create a FuelMotorcycle object
            //return new FuelMotorcycle(/* parameters for initialization */);
            return null;

        }

        public static ElectricMotorcycle CreateElectricMotorcycle(string licenseNumber)
        {
            // Example logic to create an ElectricMotorcycle object
            // You need to implement the logic to create an ElectricMotorcycle object
            //return new ElectricMotorcycle(/* parameters for initialization */);
            return null;

        }

        public static Truck CreateTruck(string licenseNumber)
        {
            // Example logic to create a Truck object
            // You need to implement the logic to create a Truck object
            //return new Truck(/* parameters for initialization */);
            return null;

        }
    }
}
