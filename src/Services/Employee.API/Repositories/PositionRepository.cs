using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Employee.API.Repositories.Interfaces;
using Infrastructures.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Repositories
{
    public class PositionRepository : RepositoryBaseAsync<Positions, Guid, EmployeeContext>, IPositionRepository
    {
        public PositionRepository(EmployeeContext dbContext, IUnitOfWork<EmployeeContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task CreatePosition(Positions product)
        {
            return CreateAsync(product);
        }

        public async Task DeletePosition(Guid id)
        {
            var product = await GetPosition(id);
            if (product != null) Delete(product);
            await SaveChangesAsync();
        }

        public Task<Positions?> GetPosition(Guid id)
        {
            return GetByIdAsync(id);
        }

        public async Task<IEnumerable<Positions>> GetPositions()
        {
            return await FindAll().ToListAsync();
        }

        public Task UpdatePosition(Positions product)
        {
            return UpdateAsync(product);
        }
    }
}
