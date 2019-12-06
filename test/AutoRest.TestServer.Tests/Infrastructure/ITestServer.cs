using System.Net.Http;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public interface ITestServer
    {
        HttpClient Client { get; }
        string Host { get; }
        Task<string[]> GetRequests();
        Task<string[]> GetMatchedStubs();
        Task ResetAsync();
        void Dispose();
    }
}
