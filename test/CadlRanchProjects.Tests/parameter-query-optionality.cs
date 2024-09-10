using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using Parameters.QueryOptionality;

namespace CadlRanchProjects.Tests
{
    public class ParametersQueryOptionalityTests : CadlRanchTestBase
    {
        [Test]
        public Task Parameters_QueryOptionality_fromrequired() => Test(async (host) =>
        {
            var response = await new QueryOptionalityClient(host, null).FromRequiredAsync("required");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_QueryOptionality_fromoptional() => Test(async (host) =>
        {
            var response = await new QueryOptionalityClient(host, null).FromOptionalAsync("required");
            Assert.AreEqual(204, response.Status);
        });
    }
}
