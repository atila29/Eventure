using System;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.Test.Mocks
{
    public class TestEvent : IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public int Version { get; }
        public string EventData { get; }

        public TestEvent(Guid id, Guid aggregateId, int version, string eventData)
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
            EventData = eventData;
        }
    }
}