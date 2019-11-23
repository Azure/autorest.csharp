using System;
using System.Threading.Tasks;
using custom_baseUrl.Operations.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        [Test]
        public async Task GetEmpty()
        {
            await using var server = TestServerSession.Start("customuri");

            var result = PathsOperations.GetEmptyAsync(ClientDiagnostics, Pipeline, string.Empty, server.Host.Replace("http://", string.Empty)).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
