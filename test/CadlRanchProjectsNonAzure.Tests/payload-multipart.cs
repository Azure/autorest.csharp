using System.IO;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Payload.MultiPart;
using Payload.MultiPart.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class PayloadMultipartTests : CadlRanchNonAzureTestBase
    {
        private string SamplePngPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.png");
        private string SampleJpgPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.jpg");

        [Test]
        public Task Payload_Multipart_FormData_Basic() => Test(async (host) =>
        {
            MultiPartRequest body = new MultiPartRequest("123", System.IO.File.OpenRead(SampleJpgPath));
            var response = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(body);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Payload_Multipart_FormData_JsonPart() => Test(async (host) =>
        {
            Address addressX = new Address("X");
            JsonPartRequest data = new JsonPartRequest(addressX, System.IO.File.OpenRead(SampleJpgPath));
            var response = await new MultiPartClient(host, null).GetFormDataClient().JsonPartAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Payload_Multipart_FormData_BinaryArrayParts() => Test(async (host) =>
        {
            var pictures = new Stream[]
            {
                System.IO.File.OpenRead(SamplePngPath),
                System.IO.File.OpenRead(SamplePngPath)
            };
            BinaryArrayPartsRequest data = new BinaryArrayPartsRequest("123", pictures);
            var response = await new MultiPartClient(host, null).GetFormDataClient().BinaryArrayPartsAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Payload_Multipart_FormData_Anonymous_Model() => Test(async (host) =>
        {
            var response = await new MultiPartClient(host, null).GetFormDataClient().AnonymousModelAsync(System.IO.File.OpenRead(SampleJpgPath));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [TestCase(true)]
        [TestCase(false)]
        public Task Payload_Multipart_FormData_multiBinaryParts(bool hasPicture) => Test(async (host) =>
        {
            MultiBinaryPartsRequest data = new MultiBinaryPartsRequest(System.IO.File.OpenRead(SampleJpgPath));
            if (hasPicture)
            {
                data.Picture = System.IO.File.OpenRead(SamplePngPath);
            }
            var response = await new MultiPartClient(host, null).GetFormDataClient().MultiBinaryPartsAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
