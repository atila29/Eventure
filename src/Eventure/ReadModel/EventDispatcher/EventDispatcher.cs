using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;
using Eventure.ReadModel.EventHandler;
using Microsoft.Extensions.DependencyInjection;
using ReflectionMagic;

namespace Eventure.ReadModel.EventDispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _provider;
        
        public EventDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public async Task DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent<Guid, Guid>
        {
            var handler = _provider.GetService<IEventHandler<TEvent>>();
            await Task.Run(() => handler.Handle(@event));
        }

        public async Task DispatchEvents<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent<Guid, Guid>
        {
            foreach (var @event in events)
            {
                await Task.Run(() => ResolveEvent(@event));
            }
        }
        
        private void ResolveEvent(IEvent<Guid, Guid> @event)
        {
            var eventHandlerType = typeof(IEventHandler<>);

            var eventType = @event.GetType();
            
            Type[] typeArgsHandler = {eventType};
            
            var contructedEventHandlerType = eventHandlerType.MakeGenericType(typeArgsHandler);
            
            var creater =
                _provider.GetService(contructedEventHandlerType);
            creater.AsDynamic().Handle(@event);
        }
    }
}