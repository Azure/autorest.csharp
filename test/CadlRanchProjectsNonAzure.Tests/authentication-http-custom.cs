using System.ClientModel;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm.Authentication.Http.Custom;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class AuthenticationHttpCustomTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Authentication_Http_Custom_valid() => Test(async (host) =>
        {
            ClientResult result = await new CustomClient(host, new ApiKeyCredential("valid-key"), null).ValidAsync();
            Assert.AreEqual(204, result.GetRawResponse().Status);
        });

        [Test]
        public Task Authentication_Http_Custom_invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<ClientResultException>(() => new CustomClient(host, new ApiKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.AreEqual(403, exception.Status);
            return Task.CompletedTask;
        });
    }
}
