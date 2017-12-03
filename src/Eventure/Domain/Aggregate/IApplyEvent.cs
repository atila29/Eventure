using System;
using Eventure.Domain.DomainEvents;

namespace Eventure.Domain.Aggregate
{
    public interface IApplyEvent<in TEvent> : IApplyEvent<TEvent, Guid, Guid> where TEvent : IEvent<Guid, Guid>
    {
    }
    
    
    public interface IApplyEvent<in TEvent, TEventId, TAggregateId> 
        where TEvent: IEvent<TEventId, TAggregateId> 
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        void Apply(TEvent @event);
    }
}