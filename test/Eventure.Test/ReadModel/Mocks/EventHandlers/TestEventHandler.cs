using System.Threading.Tasks;
using Eventure.ReadModel.EventHandler;
using Eventure.Test.ReadModel.Mocks.Events;

namespace Eventure.Test.ReadModel.Mocks.EventHandlers
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