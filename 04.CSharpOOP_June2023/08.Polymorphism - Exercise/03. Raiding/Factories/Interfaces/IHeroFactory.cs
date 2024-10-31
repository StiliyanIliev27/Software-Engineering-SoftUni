using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        BaseHero Create(string heroName, string heroType);
    }
}
