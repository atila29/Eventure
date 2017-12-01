using System;
using Eventure.Domain.DomainEvents;

namespace Eventure.Domain.Test.Mocks.Events
{
    public class CreateTestEvent : IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public int Version { get; }

        public CreateTestEvent(Guid id, Guid aggregateId, int version)
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
        }
    }
}