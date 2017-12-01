using System.Threading.Tasks;

namespace Eventure.Command.Handler
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync();
    }
}