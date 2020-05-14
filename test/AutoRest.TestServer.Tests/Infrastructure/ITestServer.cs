using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public interface ITestServer
    {
        HttpClient Client { get; }
        Uri Host { get; }
        Task<string[]> GetRequests();
        Task<string[]> GetMatchedStubs(string testName);
        Task ResetAsync();
        void Dispose();
    }
}
