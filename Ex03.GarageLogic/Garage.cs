using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<Vehicle> vehicles;

        //initializes a new instance of the Garage class that is empty
        public Garage()
        {
            vehicles = new List<Vehicle>();
        }

        //returns the vehicle with the given license number
        public Vehicle SearchVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                //Console.WriteLine(vehicle.LicenseNumber);
                if (vehicle.LicenseNumber.Equals(i_LicenseNumber))
                {
                    return vehicle;
                }
            }
            return null;
        }
    }
}
