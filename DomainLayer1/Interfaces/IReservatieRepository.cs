using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IReservatieRepository
    {
        void AddReservatie(Reservatie reservatie);
        void RemoveReservatie(int reservatieID);
        Reservatie GetReservatie(int reservatieID);
        IEnumerable<Reservatie> FindAll(int klantID);
    }
}
