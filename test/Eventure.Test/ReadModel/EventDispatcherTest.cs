using System;
using System.Threading.Tasks;
using Eventure.Domain.DomainEvents;
using Eventure.ReadModel.EventDispatcher;
using Eventure.ReadModel.Extensions;
using Eventure.Test.ReadModel.Mocks;
using Eventure.Test.ReadModel.Mocks.EventHandlers;
using Eventure.Test.ReadModel.Mocks.Events;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eventure.Test.ReadModel
{
    public class EventDispatcherTest
    {
        private readonly ServiceCollection _services;

        public EventDispatcherTest()
        {
            _services = new ServiceCollection();
            _services.AddTransient<IEventDispatcher, EventDispatcher>();
            TestResult.Works = false;
            TestResult.TestString = "";
            TestResult.Works2 = false;
            TestResult.TestString2 = "";
        }
        
        [Fact]
        public void TestPreconditions()
        {
            Assert.Empty(TestResult.TestString);
            Assert.False(TestResult.Works);
            Assert.Empty(TestResult.TestString2);
            Assert.False(TestResult.Works2);
        }
        
        [Fact]
        public void DispatchEventTest()
        {
            // Arrange.
            _services.RegisterEventHandler<TestEvent, TestEventHandler>();
            var provider = _services.BuildServiceProvider();
            var id = Guid.NewGuid();
            const int version = 100;
            const string testData = "test";
            var @event = new TestEvent(Guid.NewGuid(), id, version, testData);

            // Act.
            provider.GetService<IEventDispatcher>().DispatchEvent(@event).Wait();

            // Assert
            Assert.True(TestResult.Works);
            Assert.Equal(testData, TestResult.TestString);

        }
        
        [Fact]
        public void DispatchEventsTest()
        {
            // Arrange.
            _services.RegisterEventHandler<TestEvent, TestEventHandler>();
            _services.RegisterEventHandler<TestEvent2, TestEventHandler2>();
            var provider = _services.BuildServiceProvider();
            var id = Guid.NewGuid();
            const int version = 100;
            const string testData = "test";
            var id2 = Guid.NewGuid();
            const int version2 = 101;
            const string testData2 = "test2";
            var events = new IEvent[]{new TestEvent(Guid.NewGuid(), id, version, testData), new TestEvent2(Guid.NewGuid(), id2, version2, testData2)} ;

            // Act.
            provider.GetService<IEventDispatcher>().DispatchEvents(events).Wait();

            // Assert
            Assert.True(TestResult.Works);
            Assert.Equal(testData, TestResult.TestString);
            Assert.True(TestResult.Works2);
            Assert.Equal(testData2, TestResult.TestString2);
        }
    }
}