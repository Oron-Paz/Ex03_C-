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

        public string validateName(string i_ownerName)
        {
            try
            {
                if(i_ownerName.Any(char.IsDigit))
                {
                    throw new ArgumentException("\nOwner name cannot contain digits.");
                }
                return i_ownerName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_ownerName.Any(char.IsDigit))
                {
                    Console.WriteLine("Please enter a valid owner name:");
                    i_ownerName = Console.ReadLine();
                }
                return i_ownerName;
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
                    Console.WriteLine("Please enter a valid owner phone number:");
                    i_ownerPhoneNumber = Console.ReadLine();
                }
                return i_ownerPhoneNumber;
            }
        }

        public float validateRemainingEnergy(float remainingEnergy)
        {
            try
            {
                if(remainingEnergy < 0 || remainingEnergy > 100)
                {
                    throw new ArgumentException("\nRemaining energy must be a percent value between 0 and 100.");
                }
                return remainingEnergy;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(remainingEnergy < 0 || remainingEnergy > 100)
                {
                    Console.WriteLine("Please enter a valid remaining energy value:");
                    remainingEnergy = float.Parse(Console.ReadLine());
                }
                return remainingEnergy;
            }
        } 

        public CarColor validateCarColor(string color)
        {
            try
            {
                CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
                if (carColor != CarColor.red && carColor != CarColor.white && carColor != CarColor.yellow && carColor != CarColor.gray)
                {
                    throw new ArgumentException("\nInvalid car color.");
                }
                return carColor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                bool validColor = false;
                while (validColor == false)
                {
                    Console.WriteLine("Please enter a valid car color: (Red, White, Yellow, Gray)");
                    color = Console.ReadLine().ToLower();
                    if(color == "red" || color == "white" || color == "yellow" || color == "gray"){
                        CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
                        validColor = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid car color.");
                    }
                    
                }
                return carColor;
            }
        }

        public int validateDoor(string doors)
        {
            try
            {
                if (doors != "2" && doors != "3" && doors != "4" && doors != "5")
                {
                    throw new ArgumentException("\nInvalid number of doors.");
                }
                return int.Parse(doors);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while (doors != "2" && doors != "3" && doors != "4" && doors != "5")
                {
                    Console.WriteLine("Please enter a valid number of doors: (2, 3, 4, 5)");
                    doors = Console.ReadLine();
                }
                return int.Parse(doors);
            }
        }

        public float validateRemainingFuelLiters(float remainingFuelLiters){
            try
            {
                if(remainingFuelLiters < 0)
                {
                    throw new ArgumentException("\nRemaining fuel liters must be a positive value.");
                }
                return remainingFuelLiters;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(remainingFuelLiters < 0)
                {
                    Console.WriteLine("Please enter a valid remaining fuel liters value:");
                    remainingFuelLiters = float.Parse(Console.ReadLine());
                }
                return remainingFuelLiters;
            }
        }

        public float validateRemainingEngineTime(float remainingEngineTime)
        {
            try
            {
                if(remainingEngineTime < 0 || remainingEngineTime > 25)
                {
                    throw new ArgumentException("\nRemaining engine time must be a positive value, and below the maximum");
                }
                return remainingEngineTime;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(remainingEngineTime < 0)
                {
                    Console.WriteLine("Please enter a valid remaining engine time value:");
                    remainingEngineTime = float.Parse(Console.ReadLine());
                }
                return remainingEngineTime;
            }
        }
    }
}
