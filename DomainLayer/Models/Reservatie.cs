using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public abstract class Reservatie
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public string AankomstPlaats { get; set; }
        public string VertrekPlaats { get; set; }
        public DateTime Startmoment { get; set; }
        public Limosine limosine { get; set; }

        public abstract double Getprice();

        private double GetKorting()
        {
            return 0;
        }

        public void AddReservatie(Reservatie reservatie)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservatie(Reservatie reservatie)
        {
            throw new NotImplementedException();
        }
    }
}
