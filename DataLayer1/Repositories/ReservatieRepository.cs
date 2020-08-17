using DomainLayer;
using Microsoft.EntityFrameworkCore;
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
            List<Reservatie> ie = servicesContext.Reservaties
                .Where(r => r.KlantId == klantID).ToList();
            foreach(Reservatie r in ie)
            {
                r.Limosine = servicesContext.Limosines.Where(l => l.Id == r.LimosineId).FirstOrDefault();
            }
            return ie.AsEnumerable();
        }

        public IEnumerable<Reservatie> FindAll(DateTime date)
        {
            List<Reservatie> ie = servicesContext.Reservaties
                .Where(r => r.Startmoment.Date.Equals(date))
                .ToList();
            foreach (Reservatie r in ie)
            {
                r.Limosine = servicesContext.Limosines.Where(l => l.Id == r.LimosineId).FirstOrDefault();
            }
            return ie.AsEnumerable();
        }

        public IEnumerable<Reservatie> FindAll(int klantID, DateTime date)
        {
            List<Reservatie> ie = servicesContext.Reservaties
                .Where(r => r.KlantId == klantID).ToList();
            ie = ie.Where(r => r.Startmoment.Date.Equals(date)).ToList();


            foreach (Reservatie r in ie)
            {
                r.Limosine = servicesContext.Limosines.Where(l => l.Id == r.LimosineId).FirstOrDefault();
            }
            return ie.AsEnumerable();
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
