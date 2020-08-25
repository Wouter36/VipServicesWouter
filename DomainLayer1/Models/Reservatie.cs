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
        public int Overuren { get; set; }
        public int JaarReservaties { get; set; }

        [ForeignKey("LimosineId")]
        public Limosine Limosine { get; set; }
        public ReservatieType type { get; set; }
        public IReservatiePrijzing Prijzing;

        public Reservatie()
        {

        }

        public Reservatie(Klant klant, string aankomstPlaats, string vertrekPlaats, DateTime startMoment, int uren, Limosine limosine, ReservatieType type, IReservatiePrijzing prijzing, int overuren, int jaarReservaties)
        {
            this.Klant = klant;
            this.AankomstPlaats = aankomstPlaats;
            this.VertrekPlaats = vertrekPlaats;
            this.Startmoment = startMoment;
            this.Duur = new TimeSpan(uren, 0, 0);
            this.Limosine = limosine;
            this.type = type;
            this.Prijzing = prijzing;
            this.Overuren = overuren;
            this.JaarReservaties = jaarReservaties;

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

        public double GetPrice()
        {
            Prijzing.getPublicPrice(this);
            return 
                Prijzing.GetPrice(this);
        }

        private double GetKorting()
        {
            return 0;
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
