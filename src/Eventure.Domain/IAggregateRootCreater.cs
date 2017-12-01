using System;

namespace Eventure.Domain
{
    public interface IAggregateRootCreater<out TAggregate> where TAggregate : IAggregateRoot
    {
        TAggregate Create(Guid id);
    }
}