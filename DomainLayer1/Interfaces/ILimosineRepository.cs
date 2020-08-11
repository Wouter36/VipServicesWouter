using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface ILimosineRepository
    {
        void AddLimosine(Limosine limosine);
        void RemoveLimosine(int id);
        Limosine GetLimosine(int limosineID);
        public IEnumerable<Limosine> FindAll();
    }
}
