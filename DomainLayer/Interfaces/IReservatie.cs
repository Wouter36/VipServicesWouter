using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IReservatie
    {
        void AddReservatie(Reservatie reservatie);
        void RemoveReservatie(Reservatie reservatie);
        Reservatie GetLimosine(int reservatieID);
        IEnumerable<Reservatie> FindAll();
    }
}
