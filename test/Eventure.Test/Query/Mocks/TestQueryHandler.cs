using Eventure.Query.QueryHandler;

namespace Eventure.Test.Query.Mocks
{
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        public string Get(TestQuery query)
        {
            return query.Data.ToUpper();
        }
    }
}