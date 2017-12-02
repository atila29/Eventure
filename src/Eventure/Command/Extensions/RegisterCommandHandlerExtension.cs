using Eventure.Command.CommandHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Command.Extensions
{
    public static class RegisterCommandHandlerExtension
    {
        public static void RegisterCommandHandler<TCommand, TFactory>(this IServiceCollection serviceCollection)
            where TCommand : ICommand
            where TFactory : class, ICommandHandlerCreater<TCommand, ICommandHandler<TCommand>>
        {
            serviceCollection
                .AddTransient<ICommandHandlerCreater<TCommand, ICommandHandler<TCommand>>,
                    TFactory>();
        }
    }
}