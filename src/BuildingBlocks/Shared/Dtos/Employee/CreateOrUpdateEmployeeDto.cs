using Shared.Enums.Employee;

namespace Shared.Dtos.Employee
{
    public abstract class CreateOrUpdateEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public DateTime HireDate { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public bool EmployeeStatus { get; set; }
    }
}
