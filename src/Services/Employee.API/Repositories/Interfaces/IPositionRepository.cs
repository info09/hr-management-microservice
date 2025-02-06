using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;

namespace Employee.API.Repositories.Interfaces
{
    public interface IPositionRepository : IRepositoryBaseAsync<Positions, Guid, EmployeeContext>
    {
        Task<IEnumerable<Positions>> GetPositions();
        Task<Positions?> GetPosition(Guid id);
        Task CreatePosition(Positions product);
        Task UpdatePosition(Positions product);
        Task DeletePosition(Guid id);
    }
}
