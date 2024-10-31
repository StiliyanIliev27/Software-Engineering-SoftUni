using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using static System.Formats.Asn1.AsnWriter;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new HeroFactory());
            engine.Run();
        }
//2
//Mike
//Warrior
//Tom
//Rogue
//200
    }
}