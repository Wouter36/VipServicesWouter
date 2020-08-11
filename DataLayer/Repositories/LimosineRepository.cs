using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    class LimosineRepository : ILimosine
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
            throw new NotImplementedException();
        }

        public Limosine GetLimosine(int limosineID)
        {
            throw new NotImplementedException();
        }

        public void RemoveLomosine(Limosine limosine)
        {
            throw new NotImplementedException();
        }
    }
}
