using System;
using Eventure.Domain.DomainEvents;

namespace Eventure.Domain.Test.Mocks.Events
{
    public class UpdateTestEvent : IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public int Version { get; }
        public string newTestPropertyValue { get; }

        public UpdateTestEvent(Guid id, Guid aggregateId, int version, string newTestPropertyValue)
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
            this.newTestPropertyValue = newTestPropertyValue;
        }
    }
}