using System;

namespace Eventure.Domain.DomainEvents
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        int Version { get; }
    }
}