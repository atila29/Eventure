using System;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventHandler
{
    public interface IEventHandler<in TEvent> : IEventHandler<TEvent, Guid, Guid> where TEvent : IEvent<Guid, Guid>
    {
    }
    
    public interface IEventHandler<in TEvent, TEventId, TAggregateId> 
        where TEvent : IEvent<TEventId, TAggregateId> 
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        Task Handle(TEvent @event);
    }
}