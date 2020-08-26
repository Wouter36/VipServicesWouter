using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer
{
    public class Reservatie
    {
        #region variables
        public int Id { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public int LimosineId { get; set; }
        public Limosine Limosine { get; set; }
        public string AankomstPlaats { get; set; }
        public string VertrekPlaats { get; set; }
        public DateTime Startmoment { get; set; }
        public TimeSpan Duur { get; set; }
        public int Overuren { get; set; }
        public int JaarReservaties { get; set; }
        public ReservatieType type { get; set; }
        #endregion variables

        public Reservatie()
        {

        }

        public Reservatie(Klant klant, string aankomstPlaats, string vertrekPlaats, DateTime startMoment, int uren, Limosine limosine, ReservatieType type, int overuren, int jaarReservaties)
        {
            this.Klant = klant;
            this.AankomstPlaats = aankomstPlaats;
            this.VertrekPlaats = vertrekPlaats;
            this.Startmoment = startMoment;
            this.Duur = new TimeSpan(uren, 0, 0);
            this.Limosine = limosine;
            this.type = type;
            this.Overuren = overuren;
            this.JaarReservaties = jaarReservaties;
        }

        public double GetPrice()
        {
            return ReservatiePrijzing.getPrice(this);
        }

        public override string ToString()
        {
            string text = "Klant: " + Klant.Naam;
            text += " Limosine: " + Limosine.Naam;
            text += " Reservatie moment: " + Startmoment.ToString();
            return text;
        }
    }

    public enum ReservatieType
    {
        Airport,
        Business,
        NightLife,
        Wedding,
        Wellness
    }
}
