using Api.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetEmployees(int pageNumber, int pageSize);

        EmployeeModel GetEmployee(int employeeId);

        Task AddEmployee(EmployeeModel employeeModel);

        Task UpdateEmployee(EmployeeModel employeeModel);

        Task DeleteEmployee(int employeeId);
    }
}
