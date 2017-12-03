using System;

namespace Eventure.Domain.DomainEvents
{
    public interface IEvent : IEvent<Guid, Guid>
    {
    }
    
    public interface IEvent<out TEventId, out TAggregateId>
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        TEventId Id { get; }
        TAggregateId AggregateId { get; }
        int Version { get; }
    }
}