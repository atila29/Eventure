using System.Collections.Generic;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventDispatcher
{
    public interface IEventDispatcher
    {
        Task DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        Task DispatchEvents<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent;
    }
}