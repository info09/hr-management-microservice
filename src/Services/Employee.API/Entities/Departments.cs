using Contracts.Domains;

namespace Employee.API.Entities
{
    public class Departments : EntityAuditBase<Guid>
    {
        public string? DepartmentName { get; set; }
    }
}
