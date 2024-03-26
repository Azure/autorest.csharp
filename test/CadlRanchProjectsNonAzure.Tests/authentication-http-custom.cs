using System.ClientModel;
using System.Threading.Tasks;
using Scm.Authentication.Http.Custom;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class AuthenticationHttpCustomTests: CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Authentication_Http_Custom_valid() => Test(async (host) =>
        {
            ClientResult result = await new CustomClient(host, new ApiKeyCredential("valid-key"), null).ValidAsync();
            Assert.AreEqual(204, result.GetRawResponse().Status);
        });
    }
}
