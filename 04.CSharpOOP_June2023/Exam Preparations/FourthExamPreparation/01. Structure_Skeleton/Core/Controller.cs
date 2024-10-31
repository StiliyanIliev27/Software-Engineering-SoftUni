using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            
            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if(cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if(size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            if(booths.Models.Any(b => b.CocktailMenu.Models.Any(cm => cm.Name == cocktailName && cm.Size == size)))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            ICocktail cocktail;
            if(cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if(delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            if(booths.Models.Any(b => b.DelicacyMenu.Models.Any(cm => cm.Name == delicacyName)))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IDelicacy delicacy;
            if(delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";            
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId==boothId);

            return booth.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.Charge();
            booth.ChangeStatus();
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IEnumerable<IBooth> boothsReserved = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);          

            if(!boothsReserved.Any())
            {
                return $"No available booth for {countOfPeople} people!";
            }
            
            IBooth firstAvailableBooth = boothsReserved.First();

            firstAvailableBooth.ChangeStatus();

            return $"Booth {firstAvailableBooth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order.Split("/");

            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int countOfOrderedPieces = int.Parse(orderInfo[2]);

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if(itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine) 
                && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if(!booth.CocktailMenu.Models.Any(b => b.Name == itemName)
                && !booth.DelicacyMenu.Models.Any(b => b.Name == itemName))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            bool isCocktail = false;

            if(itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                isCocktail = true;
            }

            if(isCocktail)
            {
                string size = orderInfo[3];
                
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktail != null)
                {
                    double amount = cocktail.Price * countOfOrderedPieces;
                    booth.UpdateCurrentBill(amount);
                    return $"Booth {boothId} ordered {countOfOrderedPieces} {itemName}!";
                }
                    
                return $"There is no {size} {itemName} available!";                
            }
            
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);
            
            if(delicacy != null)
            {
                double amount = delicacy.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);
                return $"Booth {boothId} ordered {countOfOrderedPieces} {itemName}!";
            }
            
            return $"There is no {itemTypeName} {itemName} available!";                       
        }
    }
}
