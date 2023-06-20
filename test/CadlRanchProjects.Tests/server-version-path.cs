using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Server.Version.Path;

namespace CadlRanchProjects.Tests
{
    public class ServerVersionPathTests : CadlRanchTestBase
    {
        [Test]
        public Task Server_Version_Path_valid() => Test(async (host) =>
        {
            var response = await new PathClient(host, new PathClientOptions(PathClientOptions.ServiceVersion.V1_1)).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
