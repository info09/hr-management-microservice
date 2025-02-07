using AutoMapper;
using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Employee.API.Repositories.Interfaces;
using Infrastructures.Common.Repositories;
using Shared.Dtos.Employees.Contact;
using Shared.SeedWorks;

namespace Employee.API.Repositories
{
    public class ContactRepository : RepositoryBaseAsync<Contacts, Guid, EmployeeContext>, IContactRepository
    {
        private readonly IMapper _mapper;
        public ContactRepository(EmployeeContext dbContext, IUnitOfWork<EmployeeContext> unitOfWork, IMapper mapper) : base(dbContext, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> AddContact(CreateContactDto dto)
        {
            var contact = _mapper.Map<Contacts>(dto);
            await CreateAsync(contact);
            return new ApiResult<bool>(true);
        }
    }
}
