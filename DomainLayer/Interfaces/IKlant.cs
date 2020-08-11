using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IKlant
    {
        void AddKlant(Klant klant);
        void RemoveKlant(Klant klant);
        Klant GetKlant(int klantID);
        IEnumerable<Klant> FindAll();
    }
}
