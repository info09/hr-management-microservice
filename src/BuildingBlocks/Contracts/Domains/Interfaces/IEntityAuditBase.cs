namespace Contracts.Domains.Interfaces
{
    internal interface IEntityAuditBase<T> : IEntityBase<T>, IAuditable
    {
    }
}
