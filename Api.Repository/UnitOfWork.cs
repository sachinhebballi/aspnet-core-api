using Api.Entities;
using Api.Repository.interfaces;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesContext _employeesContext;

        public IEmployeeRepository Employees { get; private set; }

        public UnitOfWork(EmployeesContext employeesContext)
        {
            _employeesContext = employeesContext;
            Employees = new EmployeeRepository(_employeesContext);
        }

        public async Task SaveChangesAsync()
        {
            await _employeesContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _employeesContext.Dispose();
        }
    }
}
