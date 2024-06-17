using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<Vehicle> m_vehicles;

        //initializes a new instance of the Garage class that is empty
        public Garage()
        {
            m_vehicles = new List<Vehicle>();
        }

        //returns the vehicle with the given license number
        public Vehicle SearchVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in m_vehicles)
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

        public float validateRemainingEnergy(float i_remainingEnergy)
        {
            try
            {
                if(i_remainingEnergy < 0 || i_remainingEnergy > 100)
                {
                    throw new ArgumentException("\nRemaining energy must be a percent value between 0 and 100.");
                }
                
                return i_remainingEnergy;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_remainingEnergy < 0 || i_remainingEnergy > 100)
                {
                    Console.WriteLine("Please enter a valid remaining energy value:");
                    i_remainingEnergy = float.Parse(Console.ReadLine());
                }
                
                return i_remainingEnergy;
            }
        } 

        public eCarColor validateCarColor(string i_color)
        {
            try
            {
                eCarColor carColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_color);
                if (carColor != eCarColor.red && carColor != eCarColor.white && carColor != eCarColor.yellow && carColor != eCarColor.gray)
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
                    i_color = Console.ReadLine().ToLower();
                    if(i_color == "red" || i_color == "white" || i_color == "yellow" || i_color == "gray"){
                        //CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
                        validColor = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid car color.");
                    }
                    
                }
                return (eCarColor)Enum.Parse(typeof(eCarColor), i_color);
            }
        }

        public int validateDoor(string i_doors)
        {
            try
            {
                if (i_doors != "2" && i_doors != "3" && i_doors != "4" && i_doors != "5")
                {
                    throw new ArgumentException("\nInvalid number of doors.");
                }
                return int.Parse(i_doors);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while (i_doors != "2" && i_doors != "3" && i_doors != "4" && i_doors != "5")
                {
                    Console.WriteLine("Please enter a valid number of doors: (2, 3, 4, 5)");
                    i_doors = Console.ReadLine();
                }
                return int.Parse(i_doors);
            }
        }

        public float validateRemainingFuelLitersCar(float i_remainingFuelLiters){
            try
            {
                if(i_remainingFuelLiters < 0 || i_remainingFuelLiters > 45)
                {
                    throw new ArgumentException("\nRemaining fuel liters must be a positive value, and under the maximum value of 45 liters.");
                }
                return i_remainingFuelLiters;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_remainingFuelLiters < 0 || i_remainingFuelLiters > 45)
                {
                    Console.WriteLine("Please enter a valid remaining fuel liters value:");
                    i_remainingFuelLiters = float.Parse(Console.ReadLine());
                }
                return i_remainingFuelLiters;
            }
        }
        public float validateRemainingFuelLitersTruck(float i_remainingFuelLiters){
            try
            {
                if(i_remainingFuelLiters < 0 || i_remainingFuelLiters > 120)
                {
                    throw new ArgumentException("\nRemaining fuel liters must be a positive value, and under the maximum value of 120 liters.");
                }
                return i_remainingFuelLiters;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_remainingFuelLiters < 0 || i_remainingFuelLiters > 120)
                {
                    Console.WriteLine("Please enter a valid remaining fuel liters value:");
                    i_remainingFuelLiters = float.Parse(Console.ReadLine());
                }
                return i_remainingFuelLiters;
            }
        }

        public float validateRemainingEngineTime(float i_remainingEngineTime)
        {
            try
            {
                if(i_remainingEngineTime < 0 || i_remainingEngineTime > 25)
                {
                    throw new ArgumentException("\nRemaining engine time must be a positive value, and below the maximum");
                }
                return i_remainingEngineTime;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                while(i_remainingEngineTime < 0)
                {
                    Console.WriteLine("Please enter a valid remaining engine time value:");
                    i_remainingEngineTime = float.Parse(Console.ReadLine());
                }
                return i_remainingEngineTime;
            }
        }

        public eLicenseType validateLicenseType(string licenseType)
        {
            try
            {
                eLicenseType license = (eLicenseType)Enum.Parse(typeof(eLicenseType), licenseType);
                if (license != eLicenseType.A && license != eLicenseType.A1 && license != eLicenseType.AA && license != eLicenseType.B1)
                {
                    throw new ArgumentException("\nInvalid license type.");
                }

                return license;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                bool validLicense = false;
                while (validLicense == false)
                {
                    Console.WriteLine("Please enter a valid license type: (A, A1, A2, B)");
                    licenseType = Console.ReadLine().ToUpper();
                    if(licenseType == "A" || licenseType == "A1" || licenseType == "A2" || licenseType == "B"){
                        validLicense = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid license type.");
                    }
                    
                }
                return (eLicenseType)Enum.Parse(typeof(eLicenseType), licenseType);
            }
        }
        
        public int validateEngineVolume(string engineSize)
        {
           if (engineSize.Any(char.IsLetter) || int.Parse(engineSize) < 0)
           {
               Console.WriteLine("Engine size must be a positive value.");
               while (engineSize.Any(char.IsLetter) || int.Parse(engineSize) < 0)
               {
                   Console.WriteLine("Please enter a valid engine size:");
                   engineSize = Console.ReadLine();
               }
           }
            return int.Parse(engineSize);
        }
    }
}
