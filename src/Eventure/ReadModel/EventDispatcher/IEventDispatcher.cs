using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventDispatcher
{
    public interface IEventDispatcher
    {
        void DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}