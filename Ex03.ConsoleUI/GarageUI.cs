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
            Console.WriteLine("[1] Insert a new vehicle");
            Console.WriteLine("[2] Display vehicle license numbers");
            Console.WriteLine("[3] Change vehicle status");
            Console.WriteLine("[4] Inflate tires to maximum");
            Console.WriteLine("[5] Refuel a vehicle");
            Console.WriteLine("[6] Charge a vehicle");
            Console.WriteLine("[7] Display vehicle information");
            Console.WriteLine("[8] Exit");
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

    // Inserts a new vehicle into the garage.
    private static void InsertNewVehicle()
    {
        Console.WriteLine("\nHello, please select a vehicle type:");
        Console.WriteLine("[1] Fuel Car");
        Console.WriteLine("[2] Electric Car");
        Console.WriteLine("[3] Fuel Motorcycle");
        Console.WriteLine("[4] Electric Motorcycle");
        Console.WriteLine("[5] Truck (Fuel)");
        string option = Console.ReadLine();
        try{
            if(option != "1" && option != "2" && option != "3" && option != "4" && option != "5")
            {
                throw new ArgumentException("\nInvalid option.");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            while(option != "1" && option != "2" && option != "3" && option != "4" && option != "5")
            {
                Console.WriteLine("\nPlease select a valid option:");
                option = Console.ReadLine();
            }
        }
        Console.WriteLine("\nWhat is the license number of the vehicle?");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = garage.SearchVehicle(licenseNumber);
        if (vehicle != null)
        {
            Console.WriteLine("\nVehicle already in the garage. what would you like to do?");

            return;
        }
        Console.WriteLine("\nWhat is the model name of the vehicle?");
        string modelName = Console.ReadLine();
        Console.WriteLine("\nWhat is the owner name of the vehicle?");
        string ownerName = Console.ReadLine();
        ownerName = garage.validateName(ownerName);
        Console.WriteLine("\nWhat is the owner phone number of the vehicle?");
        string ownerPhoneNumber = Console.ReadLine();
        ownerPhoneNumber = garage.validatePhoneNumber(ownerPhoneNumber);
        Console.WriteLine("\nWhat is the remaining energy of the vehicle? (as a percantage from 0 to 100)");
        float remainingEnergy = float.Parse(Console.ReadLine());
        remainingEnergy = garage.validateRemainingEnergy(remainingEnergy);
        if (option == "1")
        {
            // Create a new FuelCar
            Console.WriteLine("\nWhat is the color of the car?");
            string color = Console.ReadLine().ToLower();
            eCarColor carColor = garage.validateCarColor(color);
            Console.WriteLine("\nHow many doors does the car have?");
            string doors = Console.ReadLine();
            int doorss = garage.validateDoor(doors);
            garage.m_vehicles.Add(VehicleFactory.CreateFuelCar(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, eVehicleStatus.InRepair, carColor, doorss, 0));
            Console.WriteLine($"Fuel car with license number {licenseNumber} was added to garage.");

            return;

        }
        else if (option == "2")
        {
            // Create a new ElectricCar
            Console.WriteLine("\nWhat is the color of the car?");
            string color = Console.ReadLine().ToLower();
            eCarColor carColor = garage.validateCarColor(color);
            Console.WriteLine("\nHow many doors does the car have?");
            string doors = Console.ReadLine();
            int doorss = garage.validateDoor(doors);
            garage.m_vehicles.Add(VehicleFactory.CreateElectricCar(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, eVehicleStatus.InRepair, carColor, doorss, 0));
            Console.WriteLine($"Electric car with license number {licenseNumber} was added to garage.");

            return;
        }
        else if (option == "3")
        {
            // Create a new FuelMotorcycle
            Console.WriteLine("\nWhat is the license type of the motorcycle?");
            string licenseTypeString = Console.ReadLine();
            eLicenseType licenseType = garage.validateLicenseType(licenseTypeString);
            Console.WriteLine("\nWhat is the engine volume of the motorcycle?");
            string engineVolumeString = Console.ReadLine();
            int engineVolume = garage.validateEngineVolume(engineVolumeString);
            garage.m_vehicles.Add(VehicleFactory.CreateFuelMotorcycle(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, eVehicleStatus.InRepair, licenseType, engineVolume, 0));
            Console.WriteLine($"\nFuel motorcycle with license number {licenseNumber} was added to garage.\n");

            return;
        }
        else if (option == "4")
        {
            // Create a new ElectricMotorcycle
            Console.WriteLine("\nWhat is the license type of the motorcycle?");
            string licenseTypeString = Console.ReadLine();
            eLicenseType licenseType = garage.validateLicenseType(licenseTypeString);
            Console.WriteLine("\nWhat is the engine volume of the motorcycle?");
            string engineVolumeString = Console.ReadLine();
            int engineVolume = garage.validateEngineVolume(engineVolumeString);
            garage.m_vehicles.Add(VehicleFactory.CreateElectricMotorcycle(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, eVehicleStatus.InRepair, licenseType, engineVolume, 0));
            Console.WriteLine($"\nFuel motorcycle with license number {licenseNumber} was added to garage.\n");

            return;
        }
        else if (option == "5")
        {
            // Create a new Truck
            Console.WriteLine("\nIs the truck carrying dangerous materials? (yes/no)");
            bool isCarryingDangerousMaterials = Console.ReadLine().ToLower() == "yes";
            Console.WriteLine("\nWhat is the cargo volume of the truck?");
            float cargoVolume = float.Parse(Console.ReadLine());
            if(cargoVolume < 0)
            {
                while(cargoVolume < 0)
                {
                    Console.WriteLine("\nInvalid cargo volume.");
                    Console.WriteLine("Please enter a valid cargo volume:");
                    cargoVolume = float.Parse(Console.ReadLine());
                }

                return;
            }
            garage.m_vehicles.Add(VehicleFactory.CreateTruck(modelName, licenseNumber, remainingEnergy, ownerName, ownerPhoneNumber, eVehicleStatus.InRepair, isCarryingDangerousMaterials, cargoVolume, 0));
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
            Console.WriteLine("\n========Current Vehicles========\n");
            foreach (Vehicle vehicle in garage.m_vehicles)
            {
                Console.WriteLine("License: " + vehicle.LicenseNumber);
            }
        }
        else if(option == "2")
        {
            Console.WriteLine("Please select a status:");
            Console.WriteLine("[1] InRepair");
            Console.WriteLine("[2] Repaired");
            Console.WriteLine("[3] Paid");
            string option2 = Console.ReadLine();

            
            if (int.TryParse(option2, out int statusNumber) && statusNumber >= 1 && statusNumber <= 3)
            {
                Console.WriteLine("\n========Vehicles by Status========\n");
                eVehicleStatus status = (eVehicleStatus)(statusNumber - 1);
                foreach (Vehicle vehicle in garage.m_vehicles)
                {
                    if(vehicle.m_Status == status)
                    {
                        Console.WriteLine("\n License: " + vehicle.LicenseNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option, please enter 1 or 2 again.");
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
        string option = Console.ReadLine();

        if (int.TryParse(option, out int statusNumber) && statusNumber >= 1 && statusNumber <= 3)
        {
            eVehicleStatus status = (eVehicleStatus)(statusNumber - 1);
            vehicle.m_Status = status;
            Console.WriteLine("\nVehicle status updated.\n");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
        }
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
        Console.WriteLine("\nTires inflated to maximum.");
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
            eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), Console.ReadLine());
            if(fuelType != ((IFuelVehicle)vehicle).m_FuelType)
            {
                Console.WriteLine("Invalid fuel type.");

                return;
            }
            Console.WriteLine("\nPlease enter the amount of fuel to refuel:");
            float amount = float.Parse(Console.ReadLine());
            ((IFuelVehicle)vehicle).Refuel(((IFuelVehicle)vehicle).m_RemainingFuelLiters, amount, fuelType);
            Console.WriteLine("\nVehicle refueled successfully.");
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
            Console.WriteLine("Please enter the amount of hours to charge:");
            float minutes = float.Parse(Console.ReadLine());
            ((IElectricVehicle)vehicle).Recharge(minutes);
            Console.WriteLine("\nVehicle charged successfully.");

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
