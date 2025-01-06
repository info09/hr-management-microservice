using Contracts.Domains;
using Shared.Enums.Employee;

namespace Employee.API.Entities
{
    public class Contacts : EntityAuditBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        public ContactType Email { get; set; }
        public string ContactType { get; set; }
    }
}
