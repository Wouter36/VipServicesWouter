using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class BusinessReservatie : Reservatie, IUurPrijsReservatie
    {
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
