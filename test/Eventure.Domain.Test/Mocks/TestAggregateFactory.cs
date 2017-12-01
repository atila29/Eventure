using System;

namespace Eventure.Domain.Test.Mocks
{
    public class TestAggregateFactory : IAggregateRootCreater<TestAggregateRoot>
    {
        public TestAggregateRoot Create(Guid id) => new TestAggregateRoot(id);
    }
}