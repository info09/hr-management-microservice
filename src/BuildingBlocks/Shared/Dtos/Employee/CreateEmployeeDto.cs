using Shared.Enums.Employee;

namespace Shared.Dtos.Employee
{
    public class CreateEmployeeDto : CreateOrUpdateEmployeeDto
    {
        public CreateEmployeeDto(string? firstName, string? lastName, DateTime dateOfBirth, GenderType gender, DateTime hireDate, Guid departmentId, Guid positionId, bool employeeStatus)
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
    }
}
