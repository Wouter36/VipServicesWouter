using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class LimosineRepository : ILimosineRepository
    {
        private ServicesContext servicesContext;

        public LimosineRepository(ServicesContext servicesContext)
        {
            this.servicesContext = servicesContext;
        }

        public void AddLimosine(Limosine limosine)
        {
            servicesContext.Limosines.Add(limosine);
        }

        public IEnumerable<Limosine> FindAll()
        {
            return servicesContext.Limosines.AsEnumerable();
        }

        public Limosine GetLimosine(int limosineID)
        {
            return servicesContext.Limosines.Find(limosineID);
        }

        public void RemoveLimosine(int id)
        {
            servicesContext.Limosines.Remove(servicesContext.Limosines.FirstOrDefault(l => l.Id == id));
        }
    }
}
