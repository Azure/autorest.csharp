using System.Threading.Tasks;
using custom_baseUrl_more_options.Operations.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseUrl_more_options : TestServerTestBase
    {
        [Test]
        public async Task GetEmpty()
        {
            await using var server = TestServerSession.Start("customuri_test12_key1");

            var result = PathsOperations.GetEmptyAsync(ClientDiagnostics, Pipeline, server.Host, string.Empty, "key1", "test12", string.Empty, "v1").GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
