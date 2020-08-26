using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{

    /// <summary>
    /// A class to work with the pricing of reservations
    /// </summary>
    class ReservatiePrijzing
    {
        const double Btw = 1.06;

        public static int getPrice(Reservatie reservatie)
        {
            if (reservatie.type == ReservatieType.Airport)
            {
                int eersteUurPrijs = reservatie.Limosine.EersteUurPrijs;
                int reservatieUren = reservatie.Duur.Hours;
                KlantType klantCategorie = reservatie.Klant.KlantCategorie;
                int reservatiesInJaar = reservatie.JaarReservaties;
                return GetPriceAirport(eersteUurPrijs, reservatieUren, klantCategorie, reservatiesInJaar);
            }
            else if (reservatie.type == ReservatieType.Business)
            {
                int eersteUurPrijs = reservatie.Limosine.EersteUurPrijs;
                int reservatieUren = reservatie.Duur.Hours;
                KlantType klantCategorie = reservatie.Klant.KlantCategorie;
                int reservatiesInJaar = reservatie.JaarReservaties;
                return GetPriceBusiness(eersteUurPrijs, reservatieUren, klantCategorie, reservatiesInJaar);
            }
            else if (reservatie.type == ReservatieType.NightLife)
            {
                int eersteUurPrijs = reservatie.Limosine.EersteUurPrijs;
                int nightLifePrijs = (int)reservatie.Limosine.NightLifePrijs;
                int overUren = reservatie.Overuren;
                KlantType klantCategorie = reservatie.Klant.KlantCategorie;
                int reservatiesInJaar = reservatie.JaarReservaties;
                return GetPriceNightLife(eersteUurPrijs, nightLifePrijs, klantCategorie, reservatiesInJaar, overUren);
            }
            else if (reservatie.type == ReservatieType.Wedding)
            {
                int eersteUurPrijs = reservatie.Limosine.EersteUurPrijs;
                int nightLifePrijs = (int)reservatie.Limosine.WeddingPrijs;
                int overUren = reservatie.Overuren;
                KlantType klantCategorie = reservatie.Klant.KlantCategorie;
                int reservatiesInJaar = reservatie.JaarReservaties;
                return GetPriceWedding(eersteUurPrijs, nightLifePrijs, klantCategorie, reservatiesInJaar, overUren);
            }
            else if (reservatie.type == ReservatieType.Wellness)
            {
                int nightLifePrijs = (int)reservatie.Limosine.WellnessPrijs;
                KlantType klantCategorie = reservatie.Klant.KlantCategorie;
                int reservatiesInJaar = reservatie.JaarReservaties;
                return GetPriceWellness(nightLifePrijs, klantCategorie, reservatiesInJaar);
            }
            return -1;
        }

        private static int GetStaffelKorting(KlantType categorie, int jaarReservatieAantal, int prijs)
        {
            if (categorie == KlantType.Vip)
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
            else if (categorie == KlantType.Huwelijksplanner)
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

        #region pricingVariations
        private static int GetPriceAirport(int eersteUurPrijs, int reservatieUren, KlantType klantCategorie, int reservatiesInJaar)
        {
            double rekenPrijs = 0;
            rekenPrijs += eersteUurPrijs;
            rekenPrijs += (eersteUurPrijs * 0.65) * (reservatieUren - 1);
            rekenPrijs -= GetStaffelKorting(klantCategorie, reservatiesInJaar, (int)rekenPrijs);
            rekenPrijs *= Btw;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }

        private static int GetPriceBusiness(int eersteUurPrijs, int reservatieUren, KlantType klantCategorie, int reservatiesInJaar)
        {
            double rekenPrijs = 0;
            rekenPrijs += eersteUurPrijs;
            rekenPrijs += (eersteUurPrijs * 0.65) * (reservatieUren - 1);
            rekenPrijs -= GetStaffelKorting(klantCategorie, reservatiesInJaar, (int)rekenPrijs);
            rekenPrijs *= Btw;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
        private static int GetPriceWellness(int wellnessPrijs, KlantType klantCategorie, int reservatiesInJaar)
        {
            double rekenPrijs = wellnessPrijs;
            rekenPrijs -= GetStaffelKorting(klantCategorie, reservatiesInJaar, (int)rekenPrijs);
            rekenPrijs *= Btw;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }

        private static int GetPriceNightLife(int eersteUurPrijs, int nightLifePrijs, KlantType klantCategorie, int reservatiesInJaar, int overuren)
        {
            double rekenPrijs = nightLifePrijs;
            rekenPrijs += overuren * (eersteUurPrijs * 1.4);
            rekenPrijs -= GetStaffelKorting(klantCategorie, reservatiesInJaar, (int)rekenPrijs);
            rekenPrijs *= Btw;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }

        private static int GetPriceWedding(int eersteUurPrijs, int weddingPrijs, KlantType klantCategorie, int reservatiesInJaar, int overuren)
        {
            double rekenPrijs = weddingPrijs;
            rekenPrijs += (eersteUurPrijs * 0.65) * overuren;
            rekenPrijs -= GetStaffelKorting(klantCategorie, reservatiesInJaar, (int)rekenPrijs);
            rekenPrijs *= Btw;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
        #endregion pricingVariations
    }
}
