

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");
            List<Person> persons = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
                string firstName = command[0];
                string lastName = command[1];
                int age = int.Parse(command[2]);
                decimal salary = decimal.Parse(command[3]);

                Person person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);
            }
            
            Console.WriteLine($"First team has {team.FirstTeam.Count}");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count}");
        } 
    }
}