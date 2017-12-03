using System;
using System.Collections.Generic;
using System.Linq;
using Eventure.Domain.DomainEvents;
using ReflectionMagic;

namespace Eventure.Domain.Aggregate
{
    public abstract class AggregateRoot : AggregateRoot<Guid>
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
    
    public abstract class AggregateRoot<TAggreagateId> : AggregateRoot<TAggreagateId, Guid> 
        where TAggreagateId : IComparable, IComparable<TAggreagateId>, IEquatable<TAggreagateId>
    {
        protected AggregateRoot(TAggreagateId id) : base(id)
        {
        }
    }
    
    public abstract class AggregateRoot<TAggreagateId, TEventId> : IAggregateRoot<TAggreagateId, TEventId>
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
        where TAggreagateId : IComparable, IComparable<TAggreagateId>, IEquatable<TAggreagateId>
    {
        protected readonly ICollection<IEvent<TEventId, TAggreagateId>> UncommittedEvents;

        public TAggreagateId Id { get; }
        public bool IsEnabled { get; protected set; }


        protected AggregateRoot(TAggreagateId id)
        {
            Id = id;
            UncommittedEvents = new List<IEvent<TEventId, TAggreagateId>>();
        }
        
        public void AddEvent(IEvent<TEventId, TAggreagateId> @event)
        {
            UncommittedEvents.Add(@event);
        }

        public void AddEvents(IEnumerable<IEvent<TEventId, TAggreagateId>> events)
        {
            foreach (var @event in events)
            {
                UncommittedEvents.Add(@event);
            }
        }
        
        protected void CommitEvent(IEvent<TEventId, TAggreagateId> @event)
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