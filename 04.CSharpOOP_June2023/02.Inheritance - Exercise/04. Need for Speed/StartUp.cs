namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {           
            SportCar sportCar = new(100, 110);
            sportCar.Drive(10);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}