using Contracts.Domains;
using Shared.Enums.Employee;

namespace Employee.API.Entities
{
    public class Employees : EntityAuditBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public DateTime HireDate { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public bool EmployeeStatus { get; set; }
    }
}
