﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        private string name;
        private string favouriteFood;
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }
        public override string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}{Environment.NewLine}DJAAF";
        }
    }
}
