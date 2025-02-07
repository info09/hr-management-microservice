using AutoMapper;
using Employee.API.Entities;
using Shared.Dtos.Employees.Contact;
using Shared.Dtos.Employees.Employee;
using Shared.Dtos.Employees.EmployeeHistory;

namespace Employee.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDto, Employees>();
            CreateMap<UpdateEmployeeDto, Employees>();

            CreateMap<CreateContactDto, Contacts>();
            CreateMap<CreateEmployeeHistoryDto, EmployeeHistories>();
        }
    }
}
