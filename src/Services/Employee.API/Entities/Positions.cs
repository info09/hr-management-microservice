using Contracts.Domains;

namespace Employee.API.Entities
{
    public class Positions : EntityAuditBase<Guid>
    {
        public string? PositionName { get; set; }
    }
}
