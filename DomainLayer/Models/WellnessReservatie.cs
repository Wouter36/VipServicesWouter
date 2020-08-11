using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class WellnessReservatie : Reservatie, IVastePrijsReservatie
    {

        public double GetFixedPrice()
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
