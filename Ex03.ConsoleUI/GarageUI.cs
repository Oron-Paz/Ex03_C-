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
            garage.vehicles.Add(VehicleFactory.CreateFuelCar(modelName, licenseNumber, remainingEnergy, new List<Wheel>(), ownerName, ownerPhoneNumber, VehicleStatus.InRepair, carColor, doors));
            return;

        }
        else if (option == "2")
        {
            // Create a new ElectricCar
        }
        else if (option == "3")
        {
            // Create a new FuelMotorcycle
        }
        else if (option == "4")
        {
            // Create a new ElectricMotorcycle
        }
        else if (option == "5")
        {
            // Create a new Truck
        }
        else
        {
            Console.WriteLine("Invalid option, try again.");
        }
    }

    private static void DisplayVehicleLicenseNumbers()
    {
        // Implementation for displaying vehicle license numbers
    }

    private static void ChangeVehicleStatus()
    {
        // Implementation for changing vehicle status
    }

    private static void InflateTiresToMax()
    {
        // Implementation for inflating tires to max
    }

    private static void RefuelVehicle()
    {
        // Implementation for refueling a vehicle
    }

    private static void ChargeVehicle()
    {
        // Implementation for charging a vehicle
    }

    private static void DisplayVehicleInfo()
    {
        // Implementation for displaying vehicle information
    }

}
