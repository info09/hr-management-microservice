﻿using Contracts.Domains;
using Shared.Enums.Employee;

namespace Employee.API.Entities
{
    public class Contacts : EntityAuditBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        public ContactType Type { get; set; }
        public string? ContactValue { get; set; }
    }
}
