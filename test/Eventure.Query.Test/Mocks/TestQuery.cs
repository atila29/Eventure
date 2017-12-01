namespace Eventure.Query.Test.Mocks
{
    public class TestQuery : IQuery<string>
    {
        public string Data { get; set; }

        public TestQuery()
        {
            
        }
        
        public TestQuery(string data)
        {
            Data = data;
        }
    }
}