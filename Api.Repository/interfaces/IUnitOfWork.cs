using System;

namespace Api.Repository.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        void SaveChanges();
    }
}
