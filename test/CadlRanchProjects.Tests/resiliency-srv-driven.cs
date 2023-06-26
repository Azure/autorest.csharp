using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ResiliencySrvDrivenTests : CadlRanchTestBase
    {
        [Test]
        public Task Resiliency_ServiceDriven_AddOptionalParam_fromNone() => Test(async (host) =>
        {
            var response = await new Resiliency.ServiceDriven.Old.ResiliencyServiceDrivenClient(host, null).FromNoneAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
