using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm.Server.Endpoint.NotDefined;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class ServerEndpointNotDefinedTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Server_Endpoint_NotDefined_valid() => Test(async (host) =>
        {
            var response = await new NotDefinedClient(host, null).ValidAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
        });
    }
}
