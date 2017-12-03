using System;

namespace Eventure.Domain.DomainEvents
{
    public interface IEvent : IEvent<Guid, Guid>
    {
    }
    
    public interface IEvent<out TEventId, out TAggregateId>
        where TEventId : IComparable, IComparable<Guid>, IEquatable<Guid> 
        where TAggregateId : IComparable, IComparable<Guid>, IEquatable<Guid>
    {
        TEventId Id { get; }
        TAggregateId AggregateId { get; }
        int Version { get; }
    }
}