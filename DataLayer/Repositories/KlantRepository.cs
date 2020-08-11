using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    class KlantRepository : IKlant
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
            throw new NotImplementedException();
        }

        public Klant GetKlant(int klantID)
        {
            throw new NotImplementedException();
        }

        public void RemoveKlant(Klant klant)
        {
            throw new NotImplementedException();
        }
    }
}
