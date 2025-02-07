namespace Shared.Dtos.Employee
{
    public class UpdateEmployeeDto : CreateOrUpdateEmployeeDto
    {
        public Guid Id { get; set; }
    }
}
