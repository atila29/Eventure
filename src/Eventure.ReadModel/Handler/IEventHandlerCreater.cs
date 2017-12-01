using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.Handler
{
    public interface IEventHandlerCreater<out TEventHandler, in TEvent> where TEvent : IEvent
    {
        TEventHandler Create(TEvent @event);
    }
}