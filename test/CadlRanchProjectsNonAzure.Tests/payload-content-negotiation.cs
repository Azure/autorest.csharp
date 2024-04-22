using System.ClientModel;
using System.Threading.Tasks;
using Payload.ContentNegotiation;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class payload_content_negotiation: CadlRanchNonAzureTestBase
    {
        [Test]
        public Task payload_content_negotiation_sameBody() => Test(async (host) =>
        {
            ClientResult result = await new ContentNegotiationClient(host, new ContentNegotiationClientOptions()).GetSameBodyClient().GetAvatarAsPngAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);
            foreach (var header in result.GetRawResponse().Headers)
            {
                var key = header.Key;
                if (key == "contentType")
                {
                    var value = header.Value;
                    Assert.AreEqual("image/png", value);
                }
            }
        });

        [Test]
        public Task payload_content_negotiation_differentBody() => Test(async (host) =>
        {
            ClientResult result = await new ContentNegotiationClient(host, new ContentNegotiationClientOptions()).GetSameBodyClient().GetAvatarAsPngAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);
            foreach (var header in result.GetRawResponse().Headers)
            {
                var key = header.Key;
                if (key == "contentType")
                {
                    var value = header.Value;
                    Assert.AreEqual("image/png", value);
                }
            }
        });
    }
}
