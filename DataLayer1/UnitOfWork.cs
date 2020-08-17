using DataLayer.Repositories;
using DomainLayer;
using System;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public ServicesContext context;
        private static UnitOfWork unitOfWork = null;

        public UnitOfWork(ServicesContext context)
        {
            this.context = context;

            Limosines = new LimosineRepository(context);
            Klanten = new KlantRepository(context);
            Reservaties = new ReservatieRepository(context);
        }

        public IReservatieRepository Reservaties { get; private set; }

        public IKlantRepository Klanten { get; private set; }

        public ILimosineRepository Limosines { get; private set; }

        public int Complete()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            //TODO : SqlExceptions
            {
                throw ex;
            }
        }

        public static UnitOfWork GetUnitOfWork()
        {
            if(unitOfWork == null)
            {
                unitOfWork = new UnitOfWork(new ServicesContext());
            }
            return unitOfWork;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
