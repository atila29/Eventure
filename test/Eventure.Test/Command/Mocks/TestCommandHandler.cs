using System.Threading.Tasks;
using Eventure.Command.CommandHandler;

namespace Eventure.Test.Command.Mocks
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public TestCommand Command { get; set; }


        public async Task ExecuteAsync(TestCommand command)
        {
            TestResult.Works = command.Works;
            await Task.CompletedTask;
        }
    }
}