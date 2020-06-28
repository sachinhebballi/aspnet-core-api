using Api.Entities;
using Api.Entities.Entities;
using Api.Repository.interfaces;

namespace Api.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly EmployeesContext _employeesContext;

        public EmployeeRepository(EmployeesContext employeesContext)
            : base(employeesContext)
        {
            _employeesContext = employeesContext;
        }

        public EmployeesContext EmployeesContext()
        {
            return _employeesContext;
        }
    }
}
