using System;

namespace DomainLayer
{
    public class Class1
    {
        public IUnitOfWork uow;
        public Class1(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
