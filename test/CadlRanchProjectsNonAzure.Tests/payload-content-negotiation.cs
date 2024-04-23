using System.ClientModel;
using System.Threading.Tasks;
using Scm.Payload.ContentNegotiation;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using System.IO;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class payload_content_negotiation: CadlRanchNonAzureTestBase
    {
        private string SamplePngPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.png");
        private string SampleJpgPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.jpg");

        [Test]
        public Task Payload_ContentNegotiation_SameBody() => Test(async (host) =>
        {
            var response = await new ContentNegotiationClient(host, null).GetSameBodyClient().GetAvatarAsPngAsync();
            CollectionAssert.AreEqual(File.ReadAllBytes(SamplePngPath), response.Value.ToArray());

            response = await new ContentNegotiationClient(host, null).GetSameBodyClient().GetAvatarAsJpegAsync();
            CollectionAssert.AreEqual(File.ReadAllBytes(SampleJpgPath), response.Value.ToArray());
        });

        [Test]
        public Task Payload_ContentNegotiation_DifferentBody() => Test(async (host) =>
        {
            var response1 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsPngAsync();
            CollectionAssert.AreEqual(File.ReadAllBytes(SamplePngPath), response1.Value.ToArray());

            var response2 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsJsonAsync();
            CollectionAssert.AreEqual(File.ReadAllBytes(SamplePngPath), response2.Value.Content.ToArray());
        });

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
