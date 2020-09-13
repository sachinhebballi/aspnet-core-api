using Api.Services.Models;
using System.Collections.Generic;

namespace Api.Services.interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetEmployees(int pageNumber, int pageSize);

        EmployeeModel GetEmployee(int employeeId);

        void AddEmployee(EmployeeModel employeeModel);

         void UpdateEmployee(EmployeeModel employeeModel);

         void DeleteEmployee(int employeeId);
    }
}
