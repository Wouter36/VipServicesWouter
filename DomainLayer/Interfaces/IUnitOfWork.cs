using System;

namespace DomainLayer
{
    interface IUnitOfWork : IDisposable
    {
        IReservatie IReservaties { get; }
        IKlant IKlanten { get; }
        int Complete();
    }
}
