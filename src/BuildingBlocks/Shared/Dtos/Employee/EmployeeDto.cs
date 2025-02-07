using Shared.Enums.Employee;

namespace Shared.Dtos.Employee
{
    public class EmployeeDto
    {
        public EmployeeDto(string? firstName, string? lastName, DateTime dateOfBirth, GenderType gender, DateTime hireDate, Guid departmentId, Guid positionId, bool employeeStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            HireDate = hireDate;
            DepartmentId = departmentId;
            PositionId = positionId;
            EmployeeStatus = employeeStatus;
        }

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
