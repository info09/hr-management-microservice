using AutoMapper;
using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Employee.API.Repositories.Interfaces;
using Infrastructures.Common.Repositories;
using Shared.Dtos.Employees.EmployeeHistory;
using Shared.SeedWorks;

namespace Employee.API.Repositories
{
    public class EmployeeHistoryRepository : RepositoryBaseAsync<EmployeeHistories, Guid, EmployeeContext>, IEmployeeHistoryRepository
    {
        private readonly IMapper _mapper;
        public EmployeeHistoryRepository(EmployeeContext dbContext, IUnitOfWork<EmployeeContext> unitOfWork, IMapper mapper) : base(dbContext, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> AddHistory(CreateEmployeeHistoryDto dto)
        {
            var contact = _mapper.Map<EmployeeHistories>(dto);
            await CreateAsync(contact);
            return new ApiResult<bool>(true);
        }
    }
}
