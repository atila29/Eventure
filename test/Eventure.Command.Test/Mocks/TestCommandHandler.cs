using System.Threading.Tasks;
using Eventure.Command.Handler;

namespace Eventure.Command.Test.Mocks
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public TestCommand Command { get; set; }

        public TestCommandHandler(TestCommand command)
        {
            Command = command;
        }

        public async Task ExecuteAsync()
        {
            TestResult.Works = true;
            await Task.CompletedTask;
        }
    }
}