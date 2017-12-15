using System;
using Eventure.Domain.DomainEvents;

namespace Eventure.Test.ReadModel.Mocks.Events
{
    public class TestEvent2: IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public int Version { get; }
        public string EventData { get; }

        public TestEvent2(Guid id, Guid aggregateId, int version, string eventData)
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
            EventData = eventData;
        }
    }
}