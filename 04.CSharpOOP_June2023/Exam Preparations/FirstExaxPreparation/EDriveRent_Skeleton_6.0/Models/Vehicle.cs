using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            batteryLevel = 100;
        }

        public string Brand
        { 
            get => brand;
            
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                { 
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }

                brand = value;
            }
        }

        public string Model 
        { 
            get => model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }

                model = value;
            }
        }

        public double MaxMileage 
        { 
            get => maxMileage;
            private set => maxMileage = value;
        }

        public string LicensePlateNumber 
        { 
            get => licensePlateNumber;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }

                licensePlateNumber = value;
            }
        }

        public int BatteryLevel 
        { 
            get => batteryLevel;
            private set => batteryLevel = value;
        }

        public bool IsDamaged 
        { 
            get => isDamaged;
            private set => isDamaged = value;
        }

        public void ChangeStatus()
        {
            IsDamaged = IsDamaged ? false : true;
        }

        public void Drive(double mileage)
        {
            BatteryLevel -= (int)Math.Round(mileage / MaxMileage * 100);

            if(this.GetType() == typeof(CargoVan))
            {
                BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(IsDamaged ? "damaged" : "OK")}";
        }
    }
}
