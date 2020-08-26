using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Limosine
    {
        #region variables
        public int Id { get; set; }
        public string Naam { get; set; }
        public int EersteUurPrijs { get; set; }
        public int? NightLifePrijs { get; set; }
        public int? WeddingPrijs { get; set; }
        public int? WellnessPrijs { get; set; }
        #endregion variables

        public override string ToString()
        {
            return Naam;
        }
    }
}
