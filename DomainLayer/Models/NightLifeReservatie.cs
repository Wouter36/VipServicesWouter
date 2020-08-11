using DomainLayer.Interfaces;
using System;

namespace DomainLayer
{
    public class NightLifeReservatie : Reservatie, IVastePrijsReservatie, IUurPrijsReservatie
    {

        public double GetFixedPrice()
        {
            throw new NotImplementedException();
        }

        public double GetHourPrice()
        {
            throw new NotImplementedException();
        }

        public double GetKorting()
        {
            throw new NotImplementedException();
        }

        public override double Getprice()
        {
            throw new NotImplementedException();
        }
    }
}
