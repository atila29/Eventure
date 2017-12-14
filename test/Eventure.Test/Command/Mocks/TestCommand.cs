using Eventure.Command;

namespace Eventure.Test.Command.Mocks
{
    public class TestCommand : ICommand
    {
        public bool Works { get; set; }

        public TestCommand(bool works)
        {
            Works = works;
        }
    }
}