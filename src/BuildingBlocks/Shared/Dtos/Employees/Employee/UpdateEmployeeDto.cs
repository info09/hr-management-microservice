namespace Shared.Dtos.Employees.Employee
{
    public class UpdateEmployeeDto : CreateOrUpdateEmployeeDto
    {
        public Guid Id { get; set; }
    }
}
