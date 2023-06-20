using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Server.Version.Union;

namespace CadlRanchProjects.Tests
{
    public class ServerVersionUnionTests : CadlRanchTestBase
    {
        [Test]
        public Task Server_Version_Union_customerDefined() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).CustomerDefinedAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Server_Version_Union_customerDefinedWithDefault() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).CustomerDefinedWithDefaultAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Server_Version_Union_templateDefined() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).TemplateDefinedAsync("dog");
            Assert.AreEqual(204, response.Status);
        });
    }
}
