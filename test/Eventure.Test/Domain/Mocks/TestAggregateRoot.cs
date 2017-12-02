using System;
using Eventure.Domain;
using Eventure.Domain.Aggregate;
using Eventure.Test.Domain.Mocks.Events;

namespace Eventure.Test.Domain.Mocks
{
    public class TestAggregateRoot : AggregateRoot, 
        IApplyEvent<CreateTestEvent>, 
        IApplyEvent<UpdateTestEvent>
    {
        public string TestProp { get; set; }
        
        public TestAggregateRoot(Guid id) : base(id)
        {
        }

        public void Apply(CreateTestEvent @event)
        {
            TestProp = "";
            IsEnabled = true;
        }

        public void Apply(UpdateTestEvent @event)
        {
            TestProp = @event.newTestPropertyValue;
        }
    }
}