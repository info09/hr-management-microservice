using Contracts.Domains;

namespace Employee.API.Entities
{
    public class EmployeeHistories : EntityAuditBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        public string ChangeType { get; set; }
        public DateTime ChangeDate { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Description { get; set; }
    }
}
