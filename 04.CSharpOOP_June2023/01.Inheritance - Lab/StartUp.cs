﻿namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}