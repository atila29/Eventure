using Eventure.Command.CommandHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Command.Extensions
{
    public static class RegisterCommandHandlerExtension
    {
        public static void RegisterCommandHandler<TCommand, THandler>(this IServiceCollection serviceCollection)
            where TCommand : ICommand
            where THandler : class, ICommandHandler<TCommand>
        {
            serviceCollection
                .AddTransient<ICommandHandler<TCommand>,
                    THandler>();
        }
    }
}