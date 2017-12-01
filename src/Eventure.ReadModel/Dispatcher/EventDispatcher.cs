using System;
using Eventure.Domain.DomainEvents;
using Eventure.ReadModel.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.ReadModel.Dispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _provider;
        
        public EventDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public void DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handler = _provider.GetService<IEventHandler<TEvent>>();
            handler.Handle(@event);
        }
    }
}