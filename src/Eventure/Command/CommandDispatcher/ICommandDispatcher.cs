using System.Threading.Tasks;

namespace Eventure.Command.CommandDispatcher
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}