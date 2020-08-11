using System;

namespace DomainLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IReservatieRepository Reservaties { get; }
        IKlantRepository Klanten { get; }
        ILimosineRepository Limosines { get; }
        int Complete();
    }
}
