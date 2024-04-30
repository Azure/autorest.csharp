using System.Threading.Tasks;
using _Azure.SpecialHeaders.XmsClientRequestId;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ClientRequestIDHeaderTests : CadlRanchTestBase
    {
        [Test]
        public Task Special_Headers_Client_Request_ID_Get() => Test(async (host) =>
        {
            Response response = await new XmsClientRequestIdClient(host, null).GetXmsClientRequestIdAsync();
            Assert.AreEqual(204, response.Status);
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-client-request-id", out var headerValue));
        });
    }
}
