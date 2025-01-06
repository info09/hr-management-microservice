using Contracts.Domains;
using Shared.Enums.Employee;

namespace Employee.API.Entities
{
    public class Dependents : EntityAuditBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public Relationship Relations { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
