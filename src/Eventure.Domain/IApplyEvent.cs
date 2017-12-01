using Eventure.Domain.DomainEvents;

namespace Eventure.Domain
{
    public interface IApplyEvent<in TEvent> where TEvent: IEvent
    {
        void Apply(TEvent @event);
    }
}