using Eventure.Query.Extensions;
using Eventure.Query.Handler;
using Eventure.Query.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eventure.Query.Test
{
    public class QueryTest
    {
        [Fact]
        public void RegisterQueryHandlerTest()
        {
            
            // Arrange
            const string testString = "test";
            var query = new TestQuery(testString);
            
            IServiceCollection services = new ServiceCollection();
            services.RegisterQuery<TestQuery, TestQueryHandler, string>();

            var provider = services.BuildServiceProvider();
            
            // Act
            var handler = provider.GetService<IQueryHandler<TestQuery, string>>();
            var result = handler.Get(query);

            // Assert
            Assert.Equal(testString.ToUpper(), result);
            
        }
    }
}