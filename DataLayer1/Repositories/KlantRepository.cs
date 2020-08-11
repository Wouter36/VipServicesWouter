using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    class KlantRepository : IKlantRepository
    {
        private ServicesContext servicesContext;

        public KlantRepository(ServicesContext servicesContext)
        {
            this.servicesContext = servicesContext;
        }

        public void AddKlant(Klant klant)
        {
            servicesContext.Klanten.Add(klant);
        }

        public IEnumerable<Klant> FindAll()
        {
            return servicesContext.Klanten.AsEnumerable<Klant>();
        }

        public Klant GetKlant(int klantID)
        {
            return servicesContext.Klanten.Find(klantID);
        }

        public void RemoveKlant(int id)
        {
            servicesContext.Klanten.Remove(new Klant { Id = id });
        }
    }
}
