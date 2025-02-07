using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Shared.Dtos.Employees.Contact;
using Shared.SeedWorks;

namespace Employee.API.Repositories.Interfaces
{
    public interface IContactRepository : IRepositoryBaseAsync<Contacts, Guid, EmployeeContext>
    {
        Task<ApiResult<bool>> AddContact(CreateContactDto dto);
    }
}
