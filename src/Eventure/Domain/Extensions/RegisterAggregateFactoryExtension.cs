using System;
using Eventure.Domain.Aggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Domain.Extensions
{
    public static class RegisterAggregateFactoryExtension
    {
        public static void RegisterAggregateFactory<TAggregate, TCreater>(this IServiceCollection serviceCollection) 
            where TCreater : class, IAggregateRootCreater<TAggregate, Guid> where TAggregate : IAggregateRoot<Guid, Guid>
        {
            serviceCollection.RegisterAggregateFactory<TAggregate, Guid, TCreater>();
        }
        
        public static void RegisterAggregateFactory<TAggregate, TAggregateId, TCreater>
            (this IServiceCollection serviceCollection)
            where TCreater : class, IAggregateRootCreater<TAggregate, TAggregateId> 
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
            where TAggregate : IAggregateRoot<TAggregateId, Guid>
        {
            serviceCollection.RegisterAggregateFactory<TAggregate, TAggregateId, Guid, TCreater>();
        }
        
        public static void RegisterAggregateFactory<TAggregate, TAggregateId, TEventId,  TCreater>
            (this IServiceCollection serviceCollection) 
            where TAggregate : IAggregateRoot<TAggregateId, TEventId> 
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId> 
            where TEventId : IComparable, IComparable<TEventId>, IEquatable<TEventId> 
            where TCreater : class, IAggregateRootCreater<TAggregate, TAggregateId, TEventId>
        {
            serviceCollection.AddTransient<IAggregateRootCreater<TAggregate, TAggregateId, TEventId>, TCreater>();
        }
    }
}
