using Raiding.Core.Interfaces;
using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;       
        private IHeroFactory heroFactory;
       
        private ICollection<BaseHero> heroes;
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            heroes = new List<BaseHero>();
        }
        public void Run()
        {
            int heroesCount = int.Parse(reader.ReadLine());

            for(int i = 0; i < heroesCount; i++)
            {
                try
                {
                    BaseHero hero = CreateHero();
                    heroes.Add(hero);
                }
                catch(InvalidHeroTypeException heroTypeException)
                {
                    writer.WriteLine(heroTypeException.Message);
                }                
            }
            Fight();
        }
        private BaseHero CreateHero()
        {
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();

            return heroFactory.Create(heroName, heroType);
        }
        private void Fight()
        {
            int bossPower = int.Parse(reader.ReadLine());

            int sumPower = 0;

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                sumPower += hero.Power;
            }

            if (sumPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

    }
}
