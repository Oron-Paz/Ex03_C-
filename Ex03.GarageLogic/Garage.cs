using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private List<Vehicle> vehicles;

        //initializes a new instance of the Garage class that is empty
        public Garage()
        {
            vehicles = new List<Vehicle>();
        }

        //returns the vehicle with the given license number
        public void SearchVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    return vehicle;
                }
            }
        }
        public void InsertVehicle(Vehicle vehicle)
        {

        }


        public void RemoveVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            // You can add additional logic here, such as removing the vehicle from a database or performing cleanup operations.
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }
    }
}
