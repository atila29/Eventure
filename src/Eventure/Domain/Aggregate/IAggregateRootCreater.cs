using System;

namespace Eventure.Domain.Aggregate
{
    public interface IAggregateRootCreater<out TAggregate> : IAggregateRootCreater<TAggregate, Guid> 
        where TAggregate : IAggregateRoot<Guid, Guid>
    {
        
    }
    
    public interface IAggregateRootCreater<out TAggregate, in TAggregateId> 
        : IAggregateRootCreater<TAggregate, TAggregateId, Guid> 
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId> 
        where TAggregate : IAggregateRoot<TAggregateId, Guid>
    {
    }
    
    public interface IAggregateRootCreater<out TAggregate, in TAggregateId, TEventId> 
        where TAggregate : IAggregateRoot<TAggregateId, TEventId>
        where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
        where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId>
    {
        TAggregate Create(TAggregateId id);
    }
}