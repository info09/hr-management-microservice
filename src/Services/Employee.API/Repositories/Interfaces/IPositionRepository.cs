using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;

namespace Employee.API.Repositories.Interfaces
{
    public interface IPositionRepository : IRepositoryBaseAsync<Positions, Guid, EmployeeContext>
    {
        Task<IEnumerable<Positions>> GetProducts();
        Task<Positions?> GetProduct(long id);
        Task<Positions?> GetProductByNo(string productNo);
        Task CreateProduct(Positions product);
        Task UpdateProduct(Positions product);
        Task DeleteProduct(long id);
    }
}
