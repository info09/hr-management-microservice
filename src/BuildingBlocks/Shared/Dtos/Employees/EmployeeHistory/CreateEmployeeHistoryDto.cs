using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Employees.EmployeeHistory
{
    public class CreateEmployeeHistoryDto
    {
        public Guid EmployeeId { get; set; }
        public string? ChangeType { get; set; }
        public DateTime ChangeDate { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? Description { get; set; }
    }
}
