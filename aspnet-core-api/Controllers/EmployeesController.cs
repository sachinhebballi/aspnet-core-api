using System.Collections.Generic;
using Api.Services.interfaces;
using Api.Services.Models;
using aspnet_core_api.Extensions;
using aspnet_core_api.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace aspnet_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<EmployeeModel> _employeeValidator;
        private readonly ILogger _logger;

        public EmployeesController(
            IEmployeeService employeeService,
            IValidator<EmployeeModel> employeeValidator,
            ILogger logger)
        {
            _employeeService = employeeService;
            _employeeValidator = employeeValidator;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> GetEmployees(int pageNumber = 1, int pageSize = 10)
        {
            _logger.Debug($"Get employees: {pageNumber} - {pageSize}");

            return _employeeService.GetEmployees(pageNumber, pageSize);
        }

        [HttpGet("employeeId")]
        public ActionResult<EmployeeModel> GetEmployee(int employeeId)
        {
            _logger.Debug($"Get employee for id: {employeeId}");

            if (employeeId == 0)
            {
                return BadRequest(new FieldLevelError
                {
                    Code = "",
                    Message = "Invalid employee id"
                });
            }

            return Ok(_employeeService.GetEmployee(employeeId));
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel employeeModel)
        {
            _logger.Debug($"Add new employee : {employeeModel}");

            var validationResult = _employeeValidator.Validate(employeeModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.GetFieldLevelErrors());
            }

            _employeeService.AddEmployee(employeeModel);

            return Ok();
        }

        [HttpPut]
        public void UpdateEmployee([FromBody] EmployeeModel employeeModel)
        {
            _logger.Debug($"Update new employee : {employeeModel}");

            _employeeService.UpdateEmployee(employeeModel);
        }

        [HttpDelete("employeeId")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            _logger.Debug($"Delete employee : {employeeId}");

            if (employeeId == 0)
            {
                return BadRequest(new FieldLevelError
                {
                    Code = "",
                    Message = "Invalid employee id"
                });
            }

            _employeeService.DeleteEmployee(employeeId);

            return Ok();
        }
    }
}
