using Api.Services.interfaces;
using Api.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace aspnet_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> GetEmployees(int pageNumber = 1, int pageSize = 10)
        {
            return _employeeService.GetEmployees(pageNumber, pageSize);
        }

        [HttpGet("employeeId")]
        public EmployeeModel GetEmployee(int employeeId)
        {
            return _employeeService.GetEmployee(employeeId);
        }

        [HttpPost]
        public void AddEmployee([FromBody] EmployeeModel employeeModel)
        {
            _employeeService.AddEmployee(employeeModel);
        }

        [HttpPut]
        public void UpdateEmployee([FromBody] EmployeeModel employeeModel)
        {
            _employeeService.UpdateEmployee(employeeModel);
        }

        [HttpDelete("employeeId")]
        public void DeleteEmployee(int employeeId)
        {
            _employeeService.DeleteEmployee(employeeId);
        }
    }
}
