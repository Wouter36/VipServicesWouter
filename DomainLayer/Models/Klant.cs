using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Klant
    {
        public int Id { get; set; }
        public Categorie KlantCategorie { get; set; }
        public string Naam { get; set; }
        public string BTWNummer { get; set; }
        public string BankRekeningNummer { get; set; }
        public string OphaalAdres { get; set; }
        public string AankomstAdres { get; set; }

        public void AddKlant(Klant klant)
        {
            throw new NotImplementedException();
        }

        public void RemoveKlant(Klant klant)
        {
            throw new NotImplementedException();
        }
    }

    public enum Categorie
    {
        articulier,
        Organisatie,
        Vip,
        Concertpromotor, 
        Huwelijksplanner,
        Evenementenbureau,
    }
}
