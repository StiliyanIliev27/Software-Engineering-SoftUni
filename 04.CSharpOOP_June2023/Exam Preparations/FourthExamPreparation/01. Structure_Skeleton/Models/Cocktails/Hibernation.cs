﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double LargeHibernation = 10.50;
        public Hibernation(string cocktailName, string size) 
            : base(cocktailName, size, LargeHibernation)
        {
        }
    }
}
