using Api.Entities.Entities;
using Api.Repository.interfaces;
using Api.Services.interfaces;
using Api.Services.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeModel> GetEmployees(int pageNumber = 0, int pageSize = 10)
        {
            var employees = _unitOfWork.Employees.GetAll(pageNumber, pageSize);

            return _mapper.Map<IEnumerable<EmployeeModel>>(employees);
        }

        public EmployeeModel GetEmployee(int employeeId)
        {
            var employee = _unitOfWork.Employees.Get(employeeId);

            return _mapper.Map<EmployeeModel>(employee);
        }

        public async Task AddEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);

            _unitOfWork.Employees.Add(employee);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            var employee = _unitOfWork.Employees.Get(employeeModel.EmployeeId);

            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.Age = employeeModel.Age;
            employee.Address.UnitNumber = employeeModel.Address.UnitNumber;
            employee.Address.StreetNumber = employeeModel.Address.StreetNumber;
            employee.Address.StreetName = employeeModel.Address.StreetName;
            employee.Address.Suburb = employeeModel.Address.Suburb;
            employee.Address.City = employeeModel.Address.City;
            employee.Address.Postcode = employeeModel.Address.Postcode;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = _unitOfWork.Employees.Get(employeeId);
            _unitOfWork.Employees.Remove(employee);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
