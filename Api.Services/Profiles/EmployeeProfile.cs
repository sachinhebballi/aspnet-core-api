using Api.Entities.Entities;
using Api.Services.Models;
using AutoMapper;

namespace Api.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
