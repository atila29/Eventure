using System;

namespace Eventure.Domain.Aggregate
{
    public interface IAggregateRootCreater<out TAggregate> : IAggregateRootCreater<TAggregate, Guid> 
        where TAggregate : IAggregateRoot
    {
        
    }
    
    public interface IAggregateRootCreater<out TAggregate, in TAggregateId> 
        where TAggregate : IAggregateRoot<TAggregateId>
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        TAggregate Create(TAggregateId id);
    }
}