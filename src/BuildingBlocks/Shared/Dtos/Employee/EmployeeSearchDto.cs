using Shared.SeedWorks;

namespace Shared.Dtos.Employee
{
    public class EmployeeSearchDto : PagingRequestParameters
    {
        public string? SearchTerm { get; set; }
    }
}
