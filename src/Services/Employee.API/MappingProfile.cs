using AutoMapper;
using Employee.API.Entities;
using Shared.Dtos.Employee;

namespace Employee.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDto, Employees>();
        }
    }
}
