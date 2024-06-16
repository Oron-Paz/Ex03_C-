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
        if(option != "1" && option != "2" && option != "3" && option != "4" && option != "5")
        {
            throw new ArgumentException("\nInvalid option.");
        }
        Console.WriteLine("What is the license number of the vehicle?");
        string licenseNumber = Console.ReadLine();
        if(licenseNumber.Contains(" "))
        {
            throw new ArgumentException("\nLicense number cannot contain spaces.");
        }
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle != null)
        {
            Console.WriteLine("\nVehicle already in the garage. what would you like to do?");
            return;
        }
        Console.WriteLine("What is the model name of the vehicle?");
        string modelName = Console.ReadLine();
        Console.WriteLine("\nWhat is the owner name of the vehicle?");
        string ownerName = Console.ReadLine();
        if(ownerName.Contains(" ") || ownerName.Any(char.IsDigit))
        {
            throw new ArgumentException("\nOwner name cannot contain spaces or numbers.");
        }
        Console.WriteLine("\nWhat is the owner phone number of the vehicle?");
        string ownerPhoneNumber = Console.ReadLine();
        if(!ownerPhoneNumber.All(char.IsDigit))
        {
            throw new ArgumentException("\nOwner phone number must be only digits.");
        }
        Console.WriteLine("\nWhat is the remaining energy of the vehicle?");
        float remainingEnergy = float.Parse(Console.ReadLine());
        if(remainingEnergy < 0 || remainingEnergy > 100)
        {
            throw new ArgumentException("\nRemaining energy must be a percent value between 0 and 100.");
        }
        if (option == "1")
        {
            // Create a new FuelCar
            Console.WriteLine("What is the color of the car?");
            string color = Console.ReadLine().ToLower();
            CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
            if (carColor != CarColor.red && carColor != CarColor.white && carColor != CarColor.yellow && carColor != CarColor.gray)
            {
                throw new ArgumentException("\nInvalid car color.");
            }
            Console.WriteLine("How many doors does the car have?");
            int doors = int.Parse(Console.ReadLine());
            if(doors < 2 || doors > 5)
            {
                throw new ArgumentException("\nNumber of doors must be between 2 and 5.");
            }
            Console.WriteLine("What is the remaining fuel liters of the car?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            if(remainingFuelLiters < 0 || remainingFuelLiters > 45)
            {
                throw new ArgumentException("\nRemaining fuel liters must be a positive value and under the maximum capacity of 45 liters.");
            }
            garage.vehicles.Add(VehicleFactory.CreateFuelCar(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, VehicleStatus.InRepair, carColor, doors, remainingFuelLiters));
            Console.WriteLine($"Fuel car with license number {licenseNumber} was added to garage.");
            return;

        }
        else if (option == "2")
        {
            // Create a new ElectricCar
            Console.WriteLine("What is the color of the car?");
            string color = Console.ReadLine().ToLower();
            CarColor carColor = (CarColor)Enum.Parse(typeof(CarColor), color);
            if (carColor != CarColor.red && carColor != CarColor.white && carColor != CarColor.yellow && carColor != CarColor.gray)
            {
                throw new ArgumentException("\nInvalid car color.");
            }
            Console.WriteLine("How many doors does the car have?");
            int doors = int.Parse(Console.ReadLine());
            if(doors < 2 || doors > 5)
            {
                throw new ArgumentException("\nNumber of doors must be between 2 and 5.");
            }
            Console.WriteLine("What is the remaining engine time of the car?");
            float remainingEngineTime = float.Parse(Console.ReadLine());
            if(remainingEngineTime < 0 || remainingEngineTime > 35)
            {
                throw new ArgumentException("\nRemaining engine time must be a positive value and under the maximum capacity of 35 hours.");
            }
            garage.vehicles.Add(VehicleFactory.CreateElectricCar(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, VehicleStatus.InRepair, carColor, doors, remainingEngineTime));
            Console.WriteLine($"Electric car with license number {licenseNumber} was added to garage.");
            return;
        }
        else if (option == "3")
        {
            // Create a new FuelMotorcycle
            Console.WriteLine("What is the license type of the motorcycle?");
            LicenseType licenseType = (LicenseType)Enum.Parse(typeof(LicenseType), Console.ReadLine());
            if(licenseType != LicenseType.A && licenseType != LicenseType.A1 && licenseType != LicenseType.AA && licenseType != LicenseType.B1)
            {
                throw new ArgumentException("\nInvalid license type.");
            }
            Console.WriteLine("What is the engine volume of the motorcycle?");
            int engineVolume = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining fuel liters of the motorcycle?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            if(remainingFuelLiters < 0 || remainingFuelLiters > 55)
            {
                throw new ArgumentException("\nRemaining fuel liters must be a positive value and under the maximum capacity of 55 liters.");
            }
            garage.vehicles.Add(VehicleFactory.CreateFuelMotorcycle(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, VehicleStatus.InRepair, licenseType, engineVolume, remainingFuelLiters));
            Console.WriteLine($"\nFuel motorcycle with license number {licenseNumber} was added to garage.\n");
            return;
        }
        else if (option == "4")
        {
            // Create a new ElectricMotorcycle
            Console.WriteLine("What is the license type of the motorcycle?");
            LicenseType licenseType = (LicenseType)Enum.Parse(typeof(LicenseType), Console.ReadLine());
            if(licenseType != LicenseType.A && licenseType != LicenseType.A1 && licenseType != LicenseType.AA && licenseType != LicenseType.B1)
            {
                throw new ArgumentException("\nInvalid license type.");
            }
            Console.WriteLine("What is the engine volume of the motorcycle?");
            int engineVolume = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the remaining engine time of the motorcycle?");
            float remainingEngineTime = float.Parse(Console.ReadLine());
            if(remainingEngineTime < 0 || remainingEngineTime > 25)
            {
                throw new ArgumentException("\nRemaining engine time must be a positive value and under the maximum capacity of 25 hours.");
            }
            garage.vehicles.Add(VehicleFactory.CreateElectricMotorcycle(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, VehicleStatus.InRepair, licenseType, engineVolume, remainingEngineTime));
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
            if(cargoVolume < 0)
            {
                throw new ArgumentException("\nCargo volume must be a positive value.");
            }
            Console.WriteLine("What is the remaining fuel liters of the truck?");
            float remainingFuelLiters = float.Parse(Console.ReadLine());
            if(remainingFuelLiters < 0 || remainingFuelLiters > 120)
            {
                throw new ArgumentException("\nRemaining fuel liters must be a positive value and under the maximum capacity of 120 liters.");
            }
            garage.vehicles.Add(VehicleFactory.CreateTruck(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, VehicleStatus.InRepair, isCarryingDangerousMaterials, cargoVolume, remainingFuelLiters));
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
                Console.WriteLine(vehicle.LicenseNumber + "\n");
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
            wheel.m_CurrentPressure = wheel.m_MaxAirRecomended;
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
            if(fuelType != ((IFuelVehicle)vehicle).m_FuelType)
            {
                Console.WriteLine("Invalid fuel type.");
                return;
            }
            Console.WriteLine("Please enter the amount of fuel to refuel:");
            float amount = float.Parse(Console.ReadLine());
            ((IFuelVehicle)vehicle).Refuel(((IFuelVehicle)vehicle).m_RemainingFuelLiters, ((IFuelVehicle)vehicle).m_MaxAmountOfFuel, amount, fuelType);
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
            ((IElectricVehicle)vehicle).Recharge(minutes);
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
        Console.WriteLine("Vehicle Information: ============================");
        Console.WriteLine($"Vehicle Model: {vehicle.m_ModelName}");
        Console.WriteLine($"Vehicle License Number: {vehicle.m_LicenseNumber}");
        Console.WriteLine($"Vehicle Remaining Energy: {vehicle.m_RemainingEnergy}");
        Console.WriteLine($"Vehicle Owner Name: {vehicle.m_OwnerName}");
        Console.WriteLine($"Vehicle Owner Phone Number: {vehicle.m_OwnerPhoneNumber}");
        Console.WriteLine($"Vehicle Status: {vehicle.m_Status}");
        if(vehicle is IFuelVehicle)
        {
            Console.WriteLine($"Vehicle Fuel Type: {((IFuelVehicle)vehicle).m_FuelType}");
            Console.WriteLine($"Vehicle Remaining Fuel Liters: {((IFuelVehicle)vehicle).m_RemainingFuelLiters}");
            Console.WriteLine($"Vehicle Maximum Fuel Capacity: {((IFuelVehicle)vehicle).m_MaxAmountOfFuel}");
        }
        if(vehicle is IElectricVehicle)
        {
            Console.WriteLine($"Vehicle Remaining Engine Time: {((IElectricVehicle)vehicle).m_RemainingEngineTime}");
            Console.WriteLine($"Vehicle Maximum Engine Time: {((IElectricVehicle)vehicle).m_MaxEngineTime}");
        }
        
        Console.WriteLine("Vehicle Wheels: ===================================");
        Console.WriteLine($"Number of wheels = {vehicle.m_Wheels.Count}");
        Console.WriteLine($"Wheel Manufacturer: {vehicle.m_Wheels[1].m_Manufacture}");
        Console.WriteLine($"Wheel Current Pressure: {vehicle.m_Wheels[1].m_CurrentPressure}");
        Console.WriteLine($"Wheel Maximum Air Pressure: {vehicle.m_Wheels[1].m_MaxAirRecomended}");

        Console.WriteLine("Vehicle Specific Information: ============================");
        if(vehicle is Car)
        {
            Console.WriteLine($"Vehicle Color: {((Car)vehicle).m_color}");
            Console.WriteLine($"Vehicle Number of Doors: {((Car)vehicle).m_doors}");
        }
        if(vehicle is Motorcycle)
        {
            Console.WriteLine($"Vehicle License Type: {((Motorcycle)vehicle).LicenseType}");
            Console.WriteLine($"Vehicle Engine Volume: {((Motorcycle)vehicle).EngineVolume}");
        }
        if(vehicle is Truck)
        {
            Console.WriteLine($"Vehicle Carrying Hazardous Materials: {((Truck)vehicle).m_CarryingHazardousMaterials}");
            Console.WriteLine($"Vehicle Cargo Volume: {((Truck)vehicle).m_CargoVolume}");
        }
        
    }

}
