using System;
using Eventure.Domain.Aggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Domain.Extensions
{
    public static class GetAggregateFactoryExtension
    {
        public static IAggregateRootCreater<TAggregate, TAggregateId, TEventId> 
            GetAggregateFactory<TAggregate, TAggregateId, TEventId>(this IServiceProvider provider) 
            where TAggregate : IAggregateRoot<TAggregateId, TEventId> 
            where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId> 
            => provider.GetService<IAggregateRootCreater<TAggregate, TAggregateId, TEventId>>();

        public static IAggregateRootCreater<TAggregate, TAggregateId, Guid> GetAggregateFactory<TAggregate,
                TAggregateId>
            (this IServiceProvider provider)
            where TAggregate : IAggregateRoot<TAggregateId, Guid>
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
            => provider.GetAggregateFactory<TAggregate, TAggregateId, Guid>();

        public static IAggregateRootCreater<TAggregate, Guid, Guid> GetAggregateFactory<TAggregate>
            (this IServiceProvider provider) 
            where TAggregate : IAggregateRoot<Guid, Guid> => 
            provider.GetAggregateFactory<TAggregate, Guid>();

    }
}