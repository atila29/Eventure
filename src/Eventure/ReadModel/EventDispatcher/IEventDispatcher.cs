using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventDispatcher
{
    public interface IEventDispatcher : IEventDispatcher<Guid, Guid>
    {
    }
    
    public interface IEventDispatcher<in TEventId, in TAggregateId> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId> 
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId>
    {
        Task DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent<TEventId, TAggregateId>;
        Task DispatchEvents<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent<TEventId, TAggregateId>;
    }
}