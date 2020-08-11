using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IKlantRepository
    {
        void AddKlant(Klant klant);
        void RemoveKlant(int id);
        Klant GetKlant(int klantID);
        IEnumerable<Klant> FindAll();
    }
}
