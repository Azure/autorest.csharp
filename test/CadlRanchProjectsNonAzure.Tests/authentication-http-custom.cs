using System.Net.ClientModel;
using System.Threading.Tasks;
using Authentication.Http.Custom;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class AuthenticationHttpCustomTests: CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Authentication_Http_Custom_valid() => Test(async (host) =>
        {
            Result result = await new AuthenticationClient(host, new KeyCredential("valid-key"), null).GetHttpClient().GetHttpCustomClient().ValidAsync();
            Assert.AreEqual(204, result.GetRawResponse().Status);
        });
    }
}
