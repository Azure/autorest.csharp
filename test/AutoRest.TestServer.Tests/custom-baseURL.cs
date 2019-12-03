using System;
using System.Threading.Tasks;
using custom_baseUrl;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        [Test]
        public Task GetEmpty() => TestStatus("customuri", async host =>
            await PathsOperations.GetEmptyAsync(ClientDiagnostics, Pipeline, string.Empty, host.Replace("http://", string.Empty)));
    }
}
