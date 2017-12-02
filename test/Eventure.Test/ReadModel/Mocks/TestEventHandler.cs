using System.Threading.Tasks;
using Eventure.ReadModel.EventHandler;

namespace Eventure.Test.ReadModel.Mocks
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public async Task Handle(TestEvent @event)
        {
            TestResult.Works = true;
            TestResult.TestString = @event.EventData;
            await Task.CompletedTask;
        }
    }
}