using System;
using System.Collections.Generic;
using System.Linq;
using Eventure.Domain.DomainEvents;
using ReflectionMagic;

namespace Eventure.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        protected readonly ICollection<IEvent> UncommittedEvents;
        public Guid Id { get; }

        public bool IsEnabled { get; protected set; }

        protected AggregateRoot(Guid id)
        {
            Id = id;
            UncommittedEvents = new List<IEvent>();
        }

        public void AddEvent(IEvent @event)
        {
            UncommittedEvents.Add(@event);
        }

        public void AddEvents(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                UncommittedEvents.Add(@event);
            }
        }
        
        protected void CommitEvent(IEvent @event)
        {
            if (Version == @event.Version)
            {
                this.AsDynamic().Apply(@event);
                Version++;
            }
        }
        
        public void CommitEvents()
        {
            foreach (var uncommittedEvent in UncommittedEvents.OrderBy(@event => @event.Version))
            {
                CommitEvent(uncommittedEvent);
            }
        }

        public int Version { get; private set; }
    }
}