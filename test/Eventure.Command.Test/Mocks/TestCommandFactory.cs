using Eventure.Command.Handler;

namespace Eventure.Command.Test.Mocks
{
    public class TestCommandFactory : ICommandHandlerCreater<TestCommand, TestCommandHandler>
    {
        public TestCommandHandler Create(TestCommand command) => 
            new TestCommandHandler(command);
    }
}