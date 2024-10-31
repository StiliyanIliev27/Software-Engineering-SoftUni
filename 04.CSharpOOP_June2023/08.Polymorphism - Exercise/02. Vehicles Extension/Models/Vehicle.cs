using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            private set
            {
                if (FuelQuantity > value)
                {
                    tankCapacity = 0;
                }
                else
                {
                    tankCapacity = value;
                }               
            }
        }

        public string Drive(double distance)
        {
            double consumption = FuelConsumption + increasedConsumption;
            
            if(FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmptyBus(double distance)
        {
            if (FuelQuantity < distance * FuelConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if(amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            if(amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
           
            FuelQuantity += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
