using Shared.SeedWorks;

namespace Shared.Dtos.Employees.Employee
{
    public class EmployeeSearchDto : PagingRequestParameters
    {
        public string? SearchTerm { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? PositionId { get; set; }
    }
}
