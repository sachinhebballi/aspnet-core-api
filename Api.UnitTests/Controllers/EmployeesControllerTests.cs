using System.Collections.Generic;
using Api.Services.interfaces;
using Api.Services.Models;
using aspnet_core_api.Controllers;
using FluentValidation;
using NSubstitute;
using Serilog;
using Xunit;

namespace Api.UnitTests.Controllers
{
    public class EmployeesControllerTests
    {
        private EmployeesController _employeesController;
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<EmployeeModel> _employeeValidator;
        private readonly ILogger _logger;

        public EmployeesControllerTests()
        {
            _employeeService = Substitute.For<IEmployeeService>();
            _employeeValidator = Substitute.For<IValidator<EmployeeModel>>();
            _logger = Substitute.For<ILogger>();
        }

        [Fact]
        public void ShouldGetEmployeesWhenCalled()
        {
            var pageNumber = 1;
            var pageSize = 10;

            _employeeService.GetEmployees(pageNumber, pageSize).Returns(GetMockEmployees());

            _employeesController = new EmployeesController(_employeeService, _employeeValidator, _logger);
            var employees = _employeesController.GetEmployees(pageNumber, pageSize);

            Assert.NotNull(employees);
            Assert.Single(employees);
        }

        private IEnumerable<EmployeeModel> GetMockEmployees()
        {
            return new List<EmployeeModel> 
            {
                new EmployeeModel
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30,
                    Address = new AddressModel
                    {
                        AddressId = 1,
                        UnitNumber = "100",
                        StreetNumber = "10",
                        StreetName = "Flinders Street",
                        Suburb = "Melbourne",
                        City = "Melbourne",
                        Postcode = 3000
                    }
                }
            };
        }
    }
}
