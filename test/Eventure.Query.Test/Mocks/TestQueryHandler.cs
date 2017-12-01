using Eventure.Query.Handler;

namespace Eventure.Query.Test.Mocks
{
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        public string Get(TestQuery query)
        {
            return query.Data.ToUpper();
        }
    }
}