using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    class ReservatieFactory
    {
        static Reservatie CreateReservatie(Klant klant, string vertrekPlaats, string aankomstPlaats, DateTime startmoment, TimeSpan duur, Limosine limosine, ReservatieType type)
        {
            int price;
            switch (type)
            {
                case ReservatieType.Airport : 
                    price = limosine.EersteUurPrijs + (int)(limosine.EersteUurPrijs * 0.65) * (duur.Hours -1);
                    price = price - (price % 5);
                        break;
                case ReservatieType.Business:
                    
                    break;
                case ReservatieType.NightLife:
                    if(startmoment.Hour >= 7 && startmoment.Hour <= 15)
                    {
                        
                    }
                    else
                    {
                        // problem
                    }
                    //price = limosine.NightLifePrijs;
                    break;
                case ReservatieType.Wedding:
                    if (startmoment.Hour >= 20 && startmoment.Hour <= 24) // 24 of 0?
                    {
                        
                    }
                    else
                    {
                        // problem
                    }
                    //price = limosine.WeddingPrijs;
                    break;
                case ReservatieType.Wellness:
                    //price = limosine.WellnessPrijs;
                    break;
            }
            //Reservatie reservatie = new Reservatie(klant, vertrekPlaats, aankomstPlaats, startmoment, duur, limosine);
            return null;
        }
    }
}
