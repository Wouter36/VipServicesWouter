using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    class ReservatieRepository : IReservatieRepository
    {
        private ServicesContext servicesContext;

        public ReservatieRepository(ServicesContext servicesContext)
        {
            this.servicesContext = servicesContext;
        }

        public void AddReservatie(Reservatie reservatie)
        {
            servicesContext.Reservaties.Add(reservatie);
        }

        public IEnumerable<Reservatie> FindAll(int klantID)
        {
            IEnumerable<Reservatie> ie = servicesContext.Reservaties.Where(r => r.KlantId == klantID);
            return servicesContext.Reservaties.AsEnumerable();
        }

        public Reservatie GetReservatie(int reservatieID)
        {
            return servicesContext.Reservaties.Find(reservatieID);
        }

        public void RemoveReservatie(int reservatieID)
        {
            servicesContext.Reservaties.Remove(servicesContext.Reservaties.FirstOrDefault(r => r.Id == reservatieID));
        }
    }
}
