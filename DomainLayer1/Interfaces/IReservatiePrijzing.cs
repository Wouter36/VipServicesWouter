using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IReservatiePrijzing
    {
        abstract int GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren);
    }

    public class BusinessReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren)
        {
            double rekenPrijs = 0;
            rekenPrijs += EersteUurPrijs;
            rekenPrijs += (EersteUurPrijs * 0.65) * (Uren - 1);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class AirportReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren)
        {
            double rekenPrijs = 0;
            rekenPrijs += EersteUurPrijs;
            rekenPrijs += (EersteUurPrijs * 0.65) * (Uren - 1);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class WellnessReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren)
        {
            double rekenPrijs = WellnessPrijs;
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class NightLifeReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren)
        {
            double rekenPrijs = NightLifePrijs;
            rekenPrijs += Overuren * (EersteUurPrijs * 1.4);
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }

    public class WeddingReservatiePrijzing : IReservatiePrijzing
    {
        int IReservatiePrijzing.GetPrice(int EersteUurPrijs, int Uren, int WellnessPrijs, int NightLifePrijs, int WeddingPrijs, int Overuren)
        {
            double rekenPrijs = WeddingPrijs;
            rekenPrijs += (EersteUurPrijs * 0.65) * Overuren;
            rekenPrijs *= 1.06;
            int totaalPrijs = (int)rekenPrijs - ((int)rekenPrijs % 5);
            return (int)totaalPrijs;
        }
    }
}
