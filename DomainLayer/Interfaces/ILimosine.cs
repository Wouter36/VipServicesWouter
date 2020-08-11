using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface ILimosine
    {
        void AddLimosine(Limosine limosine);
        void RemoveLomosine(Limosine limosine);
        Limosine GetLimosine(int limosineID);
        IEnumerable<Limosine> FindAll();
    }
}
