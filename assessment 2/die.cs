﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_2
{
    public class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

       
        public int Roll()
        {
            
            return random.Next(1, 7);
        }
    }
}
