using System;
using System.Threading.Tasks;

namespace Api.Repository.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        Task SaveChangesAsync();
    }
}
