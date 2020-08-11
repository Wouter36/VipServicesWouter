using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    class ReservatieRepository : IReservatie
    {
        private ServicesContext servicesContext;

        public ReservatieRepository(ServicesContext servicesContext)
        {
            this.servicesContext = servicesContext;
        }

        public void AddReservatie(Reservatie reservatie)
        {
            servicesContext.AirportReservaties.Add(reservatie);
        }

        public IEnumerable<Reservatie> FindAll()
        {
            throw new NotImplementedException();
        }

        public Reservatie GetLimosine(int reservatieID)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservatie(Reservatie reservatie)
        {
            throw new NotImplementedException();
        }
    }
}
