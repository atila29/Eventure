using System;
using Eventure.Domain;
using Eventure.Domain.Aggregate;

namespace Eventure.Test.Domain.Mocks
{
    public class TestAggregateFactory : IAggregateRootCreater<TestAggregateRoot>
    {
        public TestAggregateRoot Create(Guid id) => new TestAggregateRoot(id);
    }
}