using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer
{
    public class Reservatie
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public string AankomstPlaats { get; set; }
        public string VertrekPlaats { get; set; }
        public DateTime Startmoment { get; set; }
        public TimeSpan Duur { get; set; }
        public int LimosineId { get; set; }

        [ForeignKey("LimosineId")]
        public Limosine Limosine { get; set; }
        public ReservatieType type { get; set; }

        public Reservatie()
        {

        }

        public Reservatie(Klant klant, string aankomstPlaats, string vertrekPlaats, DateTime startMoment, int uren, Limosine limosine, ReservatieType type)
        {
            this.Klant = klant;
            this.AankomstPlaats = aankomstPlaats;
            this.VertrekPlaats = vertrekPlaats;
            this.Startmoment = startMoment;
            this.Duur = new TimeSpan(uren, 0, 0);
            this.Limosine = limosine;
            this.type = type;
        }

        //public Reservatie(Klant klant, string vertrekPlaats, string aankomstPlaats, DateTime startmoment, TimeSpan duur, Limosine limosine)
        //{
        //    this.Klant = klant;
        //    this.VertrekPlaats = vertrekPlaats;
        //    this.AankomstPlaats = aankomstPlaats;
        //    this.Startmoment = startmoment;
        //    this.Duur = Duur;
        //    this.Limosine = limosine;
        //}

        public double Getprice()
        {
            return 0;
        }

        private double GetKorting()
        {
            return 0;
        }

        public override string ToString()
        {
            string text = "Klant: " + Klant.ToString();
            text = text + " - Limosine: ";// + LimosineId + (Limosine == null).ToString();
            text = text + " - Reservatie: " + Id + " - " + AankomstPlaats + " - " + VertrekPlaats + " - ";
            text = text + Startmoment.ToString() + " - " + Duur + " - " + type.ToString();
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
