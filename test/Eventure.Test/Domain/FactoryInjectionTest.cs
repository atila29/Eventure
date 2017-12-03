using System;
using Eventure.Domain.Aggregate;
using Eventure.Domain.Extensions;
using Eventure.Test.Domain.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eventure.Test.Domain
{
    public class FactoryInjectionTest
    {
        [Fact]
        public void InjectionTest()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            services.RegisterAggregateFactory<TestAggregateRoot, TestAggregateFactory>();
            var expectedId = Guid.NewGuid();
            
            // Act
            var provider = services.BuildServiceProvider();
            var creater = provider.GetAggregateFactory<TestAggregateRoot>();
            var aggregate = creater.Create(expectedId);

            // Assert
            Assert.NotNull(creater);
            Assert.IsAssignableFrom<IAggregateRootCreater<TestAggregateRoot, Guid, Guid>>(creater);
            Assert.IsType<TestAggregateFactory>(creater);
            Assert.NotNull(aggregate);
            Assert.IsType<TestAggregateRoot>(aggregate);
            Assert.Equal(expectedId, aggregate.Id);
        }
    }
}