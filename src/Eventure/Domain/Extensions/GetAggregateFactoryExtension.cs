using System;
using Eventure.Domain.Aggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Domain.Extensions
{
    public static class GetAggregateFactoryExtension
    {
        public static IAggregateRootCreater<TAggregate, TAggregateId> GetAggregateFactory<TAggregate, TAggregateId>
            (this IServiceProvider provider) where TAggregate : IAggregateRoot<TAggregateId> 
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId> 
                => provider.GetService<IAggregateRootCreater<TAggregate, TAggregateId>>();

        public static IAggregateRootCreater<TAggregate, Guid> GetAggregateFactory<TAggregate>
            (this IServiceProvider provider) 
            where TAggregate : IAggregateRoot<Guid> 
                => provider.GetAggregateFactory<TAggregate, Guid>();

    }
}