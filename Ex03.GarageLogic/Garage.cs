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

        public void ValidateColor(string i_Color)
        {
            try
            {
                Enum.Parse(typeof(eColor), i_Color);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid color (Color must be: Red, White, Yellow, Gray)");
            }
        }
        public string validateName(string i_Name)
        {
            try
            {
                if(ownerName.Any(char.IsDigit))
                {
                    throw new ArgumentException("\nOwner name cannot contain digits.");
                }
                return ownerName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(ownerName.Any(char.IsDigit))
                {
                    Console.WriteLine("\nPlease enter a valid owner name:");
                    ownerName = Console.ReadLine();
                }
                return ownerName;
            }
        }

        public string validatePhoneNumber(string i_ownerPhoneNumber)
        {
            try
            {
                if(!i_ownerPhoneNumber.All(char.IsDigit))
                {
                    throw new ArgumentException("\nOwner phone number must be all digits.");
                }
                return i_ownerPhoneNumber;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_ownerPhoneNumber.All(char.IsDigit) == false)
                {
                    Console.WriteLine("\nPlease enter a valid owner phone number:");
                    i_ownerPhoneNumber = Console.ReadLine();
                }
                return i_ownerPhoneNumber;
            }
        }
    }
}
