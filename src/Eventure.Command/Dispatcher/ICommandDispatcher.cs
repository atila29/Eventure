using System.Threading.Tasks;

namespace Eventure.Command.Dispatcher
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}