using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Server.Version.Query;

namespace CadlRanchProjects.Tests
{
    public class ServerVersionQueryTests : CadlRanchTestBase
    {
        [Test]
        public Task Server_Version_Query_valid() => Test(async (host) =>
        {
            var response = await new QueryClient(host, new QueryClientOptions(QueryClientOptions.ServiceVersion.V1_1)).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
