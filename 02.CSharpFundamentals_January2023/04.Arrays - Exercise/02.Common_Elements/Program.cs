namespace _02.Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()!.Split();
            string[] arr2 = Console.ReadLine()!.Split();

            for (int i = 0; i < arr2.Length; i++)
            {
                string currentElement = arr2[i];

                if (arr1.Contains(currentElement))
                {
                    Console.Write(currentElement + " ");
                }
            }
        }
    }
}
