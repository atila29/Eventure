using System;
using System.Collections.Generic;
using Eventure.Domain.DomainEvents;
using Eventure.Domain.Test.Mocks;
using Eventure.Domain.Test.Mocks.Events;
using Xunit;

namespace Eventure.Domain.Test
{
    public class AggregateTest
    {
        public AggregateTest()
        {
            
        }
        
        [Fact]
        public void FactoryTest()
        {
            // Arrange
            var creater = new TestAggregateFactory();
            var id = Guid.NewGuid();

            // Act
            var aggregate = creater.Create(id);

            // Assert
            Assert.Equal(0, aggregate.Version);
            Assert.Equal(id, aggregate.Id);
            Assert.False(aggregate.IsEnabled);
            Assert.Null(aggregate.TestProp);
        }
        
        [Fact]
        public void CreateTest()
        {
            // Arrange
            var creater = new TestAggregateFactory();
            var id = Guid.NewGuid();

            // Act
            var aggregate = creater.Create(id);
            aggregate.AddEvent(new CreateTestEvent(Guid.NewGuid(), id, 0));
            aggregate.CommitEvents();

            // Assert
            Assert.Equal(1, aggregate.Version);
            Assert.Equal(id, aggregate.Id);
            Assert.True(aggregate.IsEnabled);
            Assert.NotNull(aggregate.TestProp);
        }
        
        [Fact]
        public void UpdateTest()
        {
            // Arrange
            var creater = new TestAggregateFactory();
            var id = Guid.NewGuid();
            var expectedValue = "test";

            // Act
            var aggregate = creater.Create(id);
            aggregate.AddEvents(new List<IEvent>
            {
                new UpdateTestEvent(Guid.NewGuid(), id, 1, expectedValue),
                new CreateTestEvent(Guid.NewGuid(), id, 0)
            });
            aggregate.CommitEvents();

            // Assert
            Assert.Equal(2, aggregate.Version);
            Assert.Equal(id, aggregate.Id);
            Assert.True(aggregate.IsEnabled);
            Assert.Equal(expectedValue, aggregate.TestProp);
        }
    }
}