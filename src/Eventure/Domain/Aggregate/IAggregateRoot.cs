using System;
using System.Collections.Generic;
using Eventure.Domain.DomainEvents;

namespace Eventure.Domain.Aggregate
{
    public interface IAggregateRoot : IAggregateRoot<Guid>
    {
    }
    
    public interface IAggregateRoot<out TId>
    {
        TId Id { get; }
        bool IsEnabled { get; }
        void AddEvent(IEvent @event);
        void AddEvents(IEnumerable<IEvent> @events);
        void CommitEvents();
        int Version { get; }
    }
}