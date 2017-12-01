using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.Handler
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}