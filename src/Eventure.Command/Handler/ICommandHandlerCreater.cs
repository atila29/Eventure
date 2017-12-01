namespace Eventure.Command.Handler
{
    public interface ICommandHandlerCreater<in TCommand, out TCommandHandler> where TCommandHandler : ICommandHandler<TCommand> where TCommand : ICommand
    {
        TCommandHandler Create(TCommand command);
    }
}