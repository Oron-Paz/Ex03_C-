using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Ex03.GarageLogic;

public class GarageUI
{
    private static Garage garage = new Garage();
    public static void Main(string[] args)
    {
       
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Garage Management System");
            Console.WriteLine("1. Insert a new vehicle");
            Console.WriteLine("2. Display vehicle license numbers");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate tires to maximum");
            Console.WriteLine("5. Refuel a vehicle");
            Console.WriteLine("6. Charge a vehicle");
            Console.WriteLine("7. Display vehicle information");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    InsertNewVehicle();
                    break;
                case "2":
                    DisplayVehicleLicenseNumbers();
                    break;
                case "3":
                    ChangeVehicleStatus();
                    break;
                case "4":
                    InflateTiresToMax();
                    break;
                case "5":
                    RefuelVehicle();
                    break;
                case "6":
                    ChargeVehicle();
                    break;
                case "7":
                    DisplayVehicleInfo();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        } 
    }
    private static void InsertNewVehicle()
    {
        Console.WriteLine("Hello, please select a veichle type:");
        Console.WriteLine("[1] Fuel Car");
        Console.WriteLine("[2] Electric Car");
        Console.WriteLine("[3] Fuel Motorcycle");
        Console.WriteLine("[4] Electric Motorcycle");
        Console.WriteLine("[5] Truck (Fuel)");
        string option = Console.ReadLine();
        Console.WriteLine("What is the license number of the vehicle?");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle != null)
        {
            Console.WriteLine("Vehicle already in the garage. what would you like to do?");
            return;
        }
        Console.WriteLine("What is the model name of the vehicle?");
        string modelName = Console.ReadLine();
        Console.WriteLine("What is the owner name of the vehicle?");
        string ownerName = Console.ReadLine();
        Console.WriteLine("What is the owner phone number of the vehicle?");
        string ownerPhoneNumber = Console.ReadLine();
        Console.WriteLine("What is the remaining energy of the vehicle?");
        float remainingEnergy = float.Parse(Console.ReadLine());
        if (option == "1")
        {
            // Create a new FuelCar
            Console.WriteLine("What is the color of the car?");
            string color = Console.ReadLine();
            CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
            Console.WriteLine("How many doors does the car have?");
            int doors = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining fuel liters of the car?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            garage.vehicles.Add(VehicleFactory.CreateFuelCar(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, carColor, doors, remainingFuelLiters));
            Console.WriteLine($"Fuel car with license number {licenseNumber} was added to garage.");
            return;

        }
        else if (option == "2")
        {
            // Create a new ElectricCar
            Console.WriteLine("What is the color of the car?");
            string color = Console.ReadLine();
            CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
            Console.WriteLine("How many doors does the car have?");
            int doors = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining engine time of the car?");
            float remainingEngineTime = float.Parse(Console.ReadLine());
            garage.vehicles.Add(VehicleFactory.CreateElectricCar(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, carColor, doors, remainingEngineTime));
            Console.WriteLine($"Electric car with license number {licenseNumber} was added to garage.");
            return;
        }
        else if (option == "3")
        {
            // Create a new FuelMotorcycle
            Console.WriteLine("What is the license type of the motorcycle?");
            LicenseType licenseType = (LicenseType)Enum.Parse(typeof(LicenseType), Console.ReadLine());
            Console.WriteLine("What is the engine volume of the motorcycle?");
            int engineVolume = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining fuel liters of the motorcycle?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            garage.vehicles.Add(VehicleFactory.CreateFuelMotorcycle(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, licenseType, engineVolume, remainingFuelLiters));
            Console.WriteLine($"\nFuel motorcycle with license number {licenseNumber} was added to garage.\n");
            return;
        }
        else if (option == "4")
        {
            // Create a new ElectricMotorcycle
            Console.WriteLine("What is the license type of the motorcycle?");
            LicenseType licenseType = (LicenseType)Enum.Parse(typeof(LicenseType), Console.ReadLine());
            Console.WriteLine("What is the engine volume of the motorcycle?");
            int engineVolume = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining engine time of the motorcycle?");
            float remainingEngineTime = float.Parse(Console.ReadLine());
            garage.vehicles.Add(VehicleFactory.CreateElectricMotorcycle(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, licenseType, engineVolume, remainingEngineTime));
            Console.WriteLine($"\nFuel motorcycle with license number {licenseNumber} was added to garage.\n");
            return;
        }
        else if (option == "5")
        {
            // Create a new Truck
            Console.WriteLine("Is the truck carrying dangerous materials? (yes/no)");
            bool isCarryingDangerousMaterials = Console.ReadLine().ToLower() == "yes";
            Console.WriteLine("What is the cargo volume of the truck?");
            float cargoVolume = float.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining fuel liters of the truck?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            garage.vehicles.Add(VehicleFactory.CreateTruck(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, isCarryingDangerousMaterials, cargoVolume, remainingFuelLiters));
        }
        else
        {
            Console.WriteLine("Invalid option, try again.");
        }
    }

    private static void DisplayVehicleLicenseNumbers()
    {
        // Implementation for displaying vehicle license numbers
        Console.WriteLine("Please select a filter:");
        Console.WriteLine("[1] Display all vehicles");
        Console.WriteLine("[2] Display vehicles by status");

        string option = Console.ReadLine();
        if(option == "1")
        {
            foreach (Vehicle vehicle in garage.vehicles)
            {
                Console.WriteLine("\n" + vehicle.LicenseNumber);
            }
        }
        else if(option == "2")
        {
            Console.WriteLine("Please select a status:");
            Console.WriteLine("[1] InRepair");
            Console.WriteLine("[2] Fixed");
            Console.WriteLine("[3] Paid");
            VehicleStatus status = (VehicleStatus)Enum.Parse(typeof(VehicleStatus), Console.ReadLine());
            foreach (Vehicle vehicle in garage.vehicles)
            {
                if(vehicle.m_Status == status)
                {
                    Console.WriteLine("\n" + vehicle.LicenseNumber);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid option, try again.");
        }

    }

    private static void ChangeVehicleStatus()
    {
        // Implementation for changing vehicle status
        Console.WriteLine("Please enter the license number of the vehicle:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }
        Console.WriteLine("Please enter the new status of the vehicle:");
        Console.WriteLine("[1] InRepair");
        Console.WriteLine("[2] Repaired");
        Console.WriteLine("[3] Paid");
        VehicleStatus status = (VehicleStatus)Enum.Parse(typeof(VehicleStatus), Console.ReadLine());
        vehicle.m_Status = status;
        Console.WriteLine("Vehicle status updated.");
    }

    private static void InflateTiresToMax()
    {
        // Implementation for inflating tires to max
        Console.WriteLine("Please enter the license number of the vehicle:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }
        foreach (Wheel wheel in vehicle.m_Wheels)
        {
            wheel.m_CurrentAirPressure = wheel.m_MaxAirPressure;
        }
        Console.WriteLine("Tires inflated to maximum.\n");
    }

    private static void RefuelVehicle()
    {
        // Implementation for refueling a vehicle
        Console.WriteLine("Please enter the license number of the vehicle:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }
        if(vehicle is IFuelVehicle)
        {
            Console.WriteLine("Please enter the fuel type:");
            Console.WriteLine("[1] Octane95");
            Console.WriteLine("[2] Octane96");
            Console.WriteLine("[3] Octane98");
            Console.WriteLine("[4] Soler");
            FuelType fuelType = (FuelType)Enum.Parse(typeof(FuelType), Console.ReadLine());
            if(fuelType != ((IFuelVehicle)vehicle).FuelType)
            {
                Console.WriteLine("Invalid fuel type.");
                return;
            }
            Console.WriteLine("Please enter the amount of fuel to refuel:");
            float amount = float.Parse(Console.ReadLine());
            vehicle.Refuel(vehicle.RemainingFuelLiters, vehicle.MaxAmountOfFuel, amount, fuelType);
            return;
        }
        else
        {
            Console.WriteLine("Vehicle is not a fuel vehicle.");
            return;
        }
    }

    private static void ChargeVehicle()
    {
        // Implementation for charging a vehicle
        Console.WriteLine("Please enter the license number of the vehicle:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }
        if(vehicle is IElectricVehicle)
        {
            Console.WriteLine("Please enter the amount of minutes to charge:");
            float minutes = float.Parse(Console.ReadLine());
            vehicle.Recharge(minutes);
            return;
        }
        else
        {
            Console.WriteLine("Vehicle is not an electric vehicle.");
            return;
        }
    }

    private static void DisplayVehicleInfo()
    {
        // Implementation for displaying vehicle information
        Console.WriteLine("Please enter the license number of the vehicle:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }
        Console.WriteLine(vehicle.ToString());
    }

}
