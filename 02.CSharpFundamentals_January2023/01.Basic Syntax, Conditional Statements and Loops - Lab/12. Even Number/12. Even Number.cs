﻿namespace _12._Even_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            PrintEvenNumber(number);
        }
        static void PrintEvenNumber(int number)
        {
            while (true)
            {
                number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
        }
    }
}