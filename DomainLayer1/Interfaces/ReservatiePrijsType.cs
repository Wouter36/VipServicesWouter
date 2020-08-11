using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface ReservatiePrijsType
    {
    }

    public interface IUurPrijsReservatie : ReservatiePrijsType
    {
        double GetPrice()
        {
            return 0;
        }
    }

    public interface IVastePrijsReservatie : ReservatiePrijsType
    {
        double GetPrice()
        {
            return 0;
        }
    }
}
