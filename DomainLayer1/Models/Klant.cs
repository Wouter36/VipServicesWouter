using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Klant
    {
        #region variables
        public int Id { get; set; }
        public KlantType KlantCategorie { get; set; }
        public string Naam { get; set; }
        public string BTWNummer { get; set; }
        public string WoonAdres { get; set; }
        #endregion variables

        public override string ToString()
        {
            return Id + " - " + Naam + " - " + WoonAdres;
        }
    }

    public enum KlantType
    {
        Particulier,
        Organisatie,
        Vip,
        Concertpromotor, 
        Huwelijksplanner,
        Evenementenbureau,
    }
}
