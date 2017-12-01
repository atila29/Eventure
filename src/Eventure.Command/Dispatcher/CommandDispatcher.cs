using System;
using System.Threading.Tasks;
using Eventure.Command.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Command.Dispatcher
{
    public sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var creater = _provider.GetService<ICommandHandlerCreater<TCommand,ICommandHandler<TCommand>>>();
            var handler = creater.Create(command);
            await handler.ExecuteAsync();
        }
    }
}