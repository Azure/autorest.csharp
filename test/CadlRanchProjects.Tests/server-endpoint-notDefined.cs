using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Server.Endpoint.NotDefined;

namespace CadlRanchProjects.Tests
{
    public class ServerEndpointNotDefinedTests : CadlRanchTestBase
    {
        [Test]
        public Task Server_Endpoint_NotDefined_valid() => Test(async (host) =>
        {
            var response = await new NotDefinedClient(host, null).ValidAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}
