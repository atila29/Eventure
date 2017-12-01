using System;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;

namespace Eventure.ReadModel.Dispatcher
{
    public interface IEventDispatcher
    {
        void DispatchEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}