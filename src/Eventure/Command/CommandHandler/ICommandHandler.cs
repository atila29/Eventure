using System.Threading.Tasks;

namespace Eventure.Command.CommandHandler
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync();
    }
}