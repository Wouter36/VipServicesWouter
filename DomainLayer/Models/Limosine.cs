﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Limosine
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int EersteUurPrijs { get; set; }
        public int NightLifePrijs { get; set; }
        public int WeddingPrijs { get; set; }
        public int WellnessPrijs { get; set; }

        public void AddLimosine(Limosine limosine)
        {
            throw new NotImplementedException();
        }

        public void RemoveLomosine(Limosine limosine)
        {
            throw new NotImplementedException();
        }
    }
}
