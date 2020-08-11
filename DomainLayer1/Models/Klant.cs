﻿using System;
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
        public string WoonAdres { get; set; }

        public override string ToString()
        {
            return Id + " - " + Naam + " - " + WoonAdres;
        }
    }

    public enum Categorie
    {
        Particulier,
        Organisatie,
        Vip,
        Concertpromotor, 
        Huwelijksplanner,
        Evenementenbureau,
    }
}
