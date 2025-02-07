using Shared.Enums.Employee;

namespace Shared.Dtos.Employees.Contact
{
    public class CreateContactDto
    {
        public Guid EmployeeId { get; set; }
        public ContactType Type { get; set; }
        public string? ContactValue { get; set; }
    }
}
