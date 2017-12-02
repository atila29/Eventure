using Eventure.Command.CommandHandler;

namespace Eventure.Test.Command.Mocks
{
    public class TestCommandFactory : ICommandHandlerCreater<TestCommand, TestCommandHandler>
    {
        public TestCommandHandler Create(TestCommand command) => 
            new TestCommandHandler(command);
    }
}