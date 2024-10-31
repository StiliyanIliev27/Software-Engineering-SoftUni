using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero Create(string heroName, string heroType)
        {
            switch (heroType)
            {
                case "Druid":
                   return new Druid(heroName);                    
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);
                default:
                    throw new InvalidHeroTypeException();
            }
        }
    }
}
