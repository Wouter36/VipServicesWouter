using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Interfaces
{
    public interface IVastePrijsReservatie : IReservatie
    {
        double GetFixedPrice()
        {
            return 0;
        }
    }
}
