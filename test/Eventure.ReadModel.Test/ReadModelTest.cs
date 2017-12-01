using System;
using System.Threading.Tasks;
using Eventure.ReadModel.Extensions;
using Eventure.ReadModel.Handler;
using Eventure.ReadModel.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Eventure.ReadModel.Test
{
    public class ReadModelTest
    {
        public ReadModelTest()
        {
            TestResult.Works = false;
            TestResult.TestString = "";
        }
        
        [Fact]
        public void TestRegisterEventHandler()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            services.RegisterEventHandler<TestEvent, TestEventHandler>();
            var serviceProvider = services.BuildServiceProvider();
            
            // Act
            var handler = serviceProvider.GetService<IEventHandler<TestEvent>>();
            
            // Assert
            Assert.NotNull(handler);
            Assert.IsType<TestEventHandler>(handler);
        }

        [Fact]
        public void TestEventHandlerPreconditions()
        {
            Assert.Empty(TestResult.TestString);
            Assert.False(TestResult.Works);
        }

        [Fact]
        public async Task TestEventHandler()
        {
            // Arrange
            var id = Guid.NewGuid();
            const int version = 100;
            const string testData = "test";
            
            var handler = new TestEventHandler();
            var @event = new TestEvent(Guid.NewGuid(), id, version, testData);
            
            // Act
            await handler.Handle(@event);
            
            // Assert
            Assert.True(TestResult.Works);
            Assert.Equal(testData, TestResult.TestString);
        }
    }
    
    public static class TestResult
    {
        public static bool Works { get; set; }
        public static string TestString { get; set; }
    }
}