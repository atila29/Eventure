using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.EventHandler
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}