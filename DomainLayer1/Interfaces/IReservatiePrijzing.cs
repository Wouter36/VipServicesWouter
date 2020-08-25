using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IReservatiePrijzing
    {
        abstract int GetPrice(Reservatie reservatie);

        public static int getPublicPrice(Reservatie reservatie)
        {
            if (reservatie.type == ReservatieType.Airport)
            {

            }
            return 0;
        }


        public static int GetStaffelKorting(Categorie categorie, int jaarReservatieAantal, int prijs)
        {
            if(categorie == Categorie.Vip)
            {
                if (jaarReservatieAantal > 15)
                {
                    return (int)(prijs * 0.1);
                }
                else if (jaarReservatieAantal > 7)
                {
                    return (int)(prijs * 0.075);
                }
                else if (jaarReservatieAantal > 2)
                {
                    return (int)(prijs * 0.05);
                }
            }
            else if(categorie == Categorie.Huwelijksplanner)
            {
                if (jaarReservatieAantal > 25)
                {
                    return (int)(prijs * 0.25);
                }
                else if (jaarReservatieAantal > 20)
                {
                    return (int)(prijs * 0.15);
                }
                else if (jaarReservatieAantal > 15)
                {
                    return (int)(prijs * 0.125);
                }
                else if (jaarReservatieAantal > 10)
                {
                    return (int)(prijs * 0.1);
                }
                else if (jaarReservatieAantal > 5)
                {
                    return (int)(prijs * 0.075);
                }
            }
            return 0;
        }
    }

    public class BusinessReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(Reservatie reservatie)
        {
            double rekenPrijs = 0;
            rekenPrijs += reservatie.Limosine.EersteUurPrijs;
            rekenPrijs += (reservatie.Limosine.EersteUurPrijs * 0.65) * (reservatie.Duur.Hours - 1);
            rekenPrijs -= IReservatiePrijzing.GetStaffelKorting(reservatie.Klant.KlantCategorie, reservatie.JaarReservaties, (int)rekenPrijs);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class AirportReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(Reservatie reservatie)
        {
            double rekenPrijs = 0;
            rekenPrijs += reservatie.Limosine.EersteUurPrijs;
            rekenPrijs += (reservatie.Limosine.EersteUurPrijs * 0.65) * (reservatie.Duur.Hours - 1);
            rekenPrijs -= IReservatiePrijzing.GetStaffelKorting(reservatie.Klant.KlantCategorie, reservatie.JaarReservaties, (int)rekenPrijs);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class WellnessReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(Reservatie reservatie)
        {
            double rekenPrijs = (int)reservatie.Limosine.WellnessPrijs;
            rekenPrijs -= IReservatiePrijzing.GetStaffelKorting(reservatie.Klant.KlantCategorie, reservatie.JaarReservaties, (int)rekenPrijs);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class NightLifeReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(Reservatie reservatie)
        {
            double rekenPrijs = (int)reservatie.Limosine.NightLifePrijs;
            rekenPrijs += reservatie.Overuren * (reservatie.Limosine.EersteUurPrijs * 1.4);
            rekenPrijs -= IReservatiePrijzing.GetStaffelKorting(reservatie.Klant.KlantCategorie, reservatie.JaarReservaties, (int)rekenPrijs);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class WeddingReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(Reservatie reservatie)
        {
            double rekenPrijs = (int)reservatie.Limosine.WeddingPrijs;
            rekenPrijs += (reservatie.Limosine.EersteUurPrijs * 0.65) * reservatie.Overuren;
            rekenPrijs -= IReservatiePrijzing.GetStaffelKorting(reservatie.Klant.KlantCategorie, reservatie.JaarReservaties, (int)rekenPrijs);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }
}
