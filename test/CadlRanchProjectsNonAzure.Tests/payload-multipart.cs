using System;
using System.IO;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Payload.MultiPart;
using Payload.MultiPart.Models;

namespace CadlRanchProjects.Tests
{
    public class PayloadMultipartTests : CadlRanchTestBase
    {
        private string SamplePngPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.png");
        private string SampleJpgPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.jpg");
        [Test]
        public Task Payload_Multipart_FormData_Basic() => Test(async (host) =>
        {
            MultiPartRequest body = new MultiPartRequest("123", File.OpenRead(SampleJpgPath));
            var response = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(body);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
        [Test]
        public Task Payload_Multipart_FormData_JsonPart() => Test(async (host) =>
        {
            Address addressX = new Address("X");
            JsonPartRequest data = new JsonPartRequest(addressX, File.OpenRead(SampleJpgPath));
            var response = await new MultiPartClient(host, null).GetFormDataClient().JsonPartAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
        [Test]
        public Task Payload_Multipart_FormData_BinaryArrayParts() => Test(async (host) =>
        {
            var pictures = new Stream[]
            {
                File.OpenRead(SamplePngPath),
                File.OpenRead(SamplePngPath)
            };
            BinaryArrayPartsRequest data = new BinaryArrayPartsRequest("123", pictures);
            var response = await new MultiPartClient(host, null).GetFormDataClient().BinaryArrayPartsAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
        [Test]
        public Task Payload_Multipart_FormData_Anonymous_Model() => Test(async (host) =>
        {
            var response = await new MultiPartClient(host, null).GetFormDataClient().AnonymousModelAsync(File.OpenRead(SampleJpgPath));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
