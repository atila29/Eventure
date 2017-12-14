using System;
using System.Threading.Tasks;
using Eventure.Command.CommandHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Command.CommandDispatcher
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
            var creater = _provider.GetService<ICommandHandler<TCommand>>();
            await creater.ExecuteAsync(command);
        }
    }
}