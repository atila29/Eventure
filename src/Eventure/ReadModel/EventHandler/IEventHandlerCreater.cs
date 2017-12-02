using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventHandler
{
    public interface IEventHandlerCreater<out TEventHandler, in TEvent> where TEvent : IEvent
    {
        TEventHandler Create(TEvent @event);
    }
}