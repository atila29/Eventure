using System;
using System.Collections.Generic;
using Eventure.Domain.DomainEvents;

namespace Eventure.Domain.Aggregate
{
    public interface IAggregateRoot : IAggregateRoot<Guid>
    {
    }
    
    public interface IAggregateRoot<TAggregateId> : IAggregateRoot<TAggregateId, Guid> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
    }
    
    public interface IAggregateRoot<TAggregateId, in TEventId> 
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        TAggregateId Id { get; }
        bool IsEnabled { get; }
        void AddEvent(IEvent<TEventId, TAggregateId> @event);
        void AddEvents(IEnumerable<IEvent<TEventId, TAggregateId>> @events);
        void CommitEvents();
        int Version { get; }
    }
}