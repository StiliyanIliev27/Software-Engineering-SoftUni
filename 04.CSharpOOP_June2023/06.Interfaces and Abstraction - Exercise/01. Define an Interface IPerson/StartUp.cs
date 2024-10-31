using P01.PersonInfoInterface.Core;
using P01.PersonInfoInterface.Core.Interfaces;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}