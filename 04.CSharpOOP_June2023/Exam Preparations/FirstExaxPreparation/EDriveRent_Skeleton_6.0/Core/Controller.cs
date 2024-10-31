using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint 
                && x.EndPoint == endPoint && x.Length == length);  

            if(route != null)
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }

            route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint
                && x.EndPoint == endPoint && x.Length < length);

            if(route != null )
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }

            route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint
                && x.EndPoint == endPoint && x.Length > length);

            if(route != null)
            { 
               route.LockRoute();
            }

            var allRoutes = routes.GetAll().Count;

            Route newRoute = new Route(startPoint, endPoint, length, allRoutes + 1);

            routes.AddModel(newRoute);
            
            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = users.FindById(drivingLicenseNumber);
            var route = routes.FindById(routeId);
            var vehicle = vehicles.FindById(licensePlateNumber);

            if(user.IsBlocked)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }

            if(vehicle.IsDamaged) 
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }

            if (route.IsLocked)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var user = users.FindById(drivingLicenseNumber);

            if (user != null)
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }

            user = new User(firstName, lastName, drivingLicenseNumber);   
            users.AddModel(user);
           
            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string RepairVehicles(int count)
        {
            var vehiclesToRepair = vehicles.GetAll()
                .Where(x => x.IsDamaged == true)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .Take(count)
                .ToList();

            foreach(var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return $"{vehiclesToRepair.Count} vehicles are successfully repaired!";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if(vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            var vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicle != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            if(vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string UsersReport()
        {
           StringBuilder sb = new StringBuilder();
            
           var usersToString = users.GetAll()
              .OrderByDescending(x => x.Rating)
              .ThenBy(x => x.LastName)
              .ThenBy(x => x.FirstName)
              .ToList();

           sb.AppendLine("*** E-Drive-Rent ***");  
           
           foreach (var user in usersToString)
           {
              sb.AppendLine(user.ToString());
           }

           return sb.ToString().TrimEnd();
        }
    }
}
