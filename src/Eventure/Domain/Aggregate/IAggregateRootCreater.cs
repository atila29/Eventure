using System;

namespace Eventure.Domain.Aggregate
{
    public interface IAggregateRootCreater<out TAggregate> where TAggregate : IAggregateRoot
    {
        TAggregate Create(Guid id);
    }
}