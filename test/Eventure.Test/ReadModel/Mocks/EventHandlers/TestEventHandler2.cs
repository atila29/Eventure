using System.Threading.Tasks;
using Eventure.ReadModel.EventHandler;
using Eventure.Test.ReadModel.Mocks.Events;

namespace Eventure.Test.ReadModel.Mocks.EventHandlers
{
    public class TestEventHandler2 : IEventHandler<TestEvent2>
    {
        public async Task Handle(TestEvent2 @event)
        {
            TestResult.Works2 = true;
            TestResult.TestString2 = @event.EventData;
            await Task.CompletedTask;
        }
    }
}