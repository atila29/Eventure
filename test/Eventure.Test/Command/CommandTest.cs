using System;
using Eventure.Command.CommandDispatcher;
using Eventure.Command.Extensions;
using Eventure.Test.Command.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eventure.Test.Command
{
    public class CommandTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICommandDispatcher _dispatcher;
        
        public CommandTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.RegisterCommandHandler<TestCommand, TestCommandHandler>();
            _serviceProvider = services.BuildServiceProvider();
            _dispatcher = new CommandDispatcher(_serviceProvider);
            TestResult.Works = false;
        }
        
        [Fact]
        public void TestCommand()
        {
            // Arrange
            var command = new TestCommand(true);
            
            // Act
            _dispatcher.Dispatch(command);

            // Assert
            Assert.True(TestResult.Works);
            
            
        }

        [Fact]
        public void TestCommandPreconditions()
        {
            Assert.False(TestResult.Works);
        }
    }

    public static class TestResult
    {
        public static bool Works { get; set; }
    }
}