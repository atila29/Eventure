using Eventure.Domain.DomainEvents;
using Eventure.ReadModel.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.ReadModel.Extensions
{
    public static class RegisterEventHandlerExtension
    {
        public static void RegisterEventHandler<TEvent, TEventHandler>(this IServiceCollection serviceCollection)
            where TEventHandler : class, IEventHandler<TEvent>
            where TEvent : IEvent
        {
            serviceCollection.AddTransient<IEventHandler<TEvent>, TEventHandler>();
        }
    }
}