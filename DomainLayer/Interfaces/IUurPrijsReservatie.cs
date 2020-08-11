using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Interfaces
{
    public interface IUurPrijsReservatie : IReservatie
    {
        double GetHourPrice();

    }
}
