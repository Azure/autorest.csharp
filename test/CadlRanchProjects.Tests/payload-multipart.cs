using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Payload.MultiPart;
using Payload.MultiPart.Models;
using Azure.Core;
using System.ClientModel.Primitives;

namespace CadlRanchProjects.Tests
{
    public class PayloadMultipartTests : CadlRanchTestBase
    {
        private string SamplePngPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.png");
        private string SampleJpgPath = Path.Combine(CadlRanchServer.GetSpecDirectory(), "assets", "image.jpg");
        [Test]
        public Task Payload_MultiPart_FormData_basic() => Test(async (host) =>
        {
            MultiPartRequest body = new MultiPartRequest("123", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            var response1 = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(body);
            Assert.AreEqual(204, response1.Status);
        });
        [Test]
        public Task Payload_MultiPart_FormData_basic_protocol() => Test(async (host) =>
        {
            using MultipartFormData multipartContent = new MultipartFormData();
            multipartContent.Add(BinaryData.FromString("123"), "id");
            multipartContent.Add(BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath), "application/octet-stream"), "profileImage", "profileImage.wav", null);
            //using RequestContent content = multipartContent.ToRequestContent();
            using RequestContent content = RequestContent.Create(multipartContent as IPersistableModel<MultipartFormData>, ModelReaderWriterOptions.MultipartFormData);
            var response1 = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(content);
            Assert.AreEqual(204, response1.Status);
        });
        [Test]
        public Task Payload_MultiPart_FormData_basic_protocol2() => Test(async (host) =>
        {
            using MultipartFormData multipartContent = new MultipartFormData();
            multipartContent.Add(BinaryData.FromString("123"), "id");
            multipartContent.Add(BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath), "application/octet-stream"), "profileImage", "profileImage.wav", null);
            //using RequestContent content = multipartContent.ToRequestContent();
            using RequestContent content = RequestContent.Create(multipartContent as IPersistableStreamModel<MultipartFormData>, ModelReaderWriterOptions.MultipartFormData);
            var response1 = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(content);
            Assert.AreEqual(204, response1.Status);
        });
        [Test]
        public Task Payload_MultiPart_FormData_basic_protocol_with_Model() => Test(async (host) =>
        {
            MultiPartRequest data = new MultiPartRequest("123", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            using RequestContent content = RequestContent.Create(data as IPersistableStreamModel<MultiPartRequest>, new ModelReaderWriterOptions("MPFD"));
            var response1 = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(content);
            Assert.AreEqual(204, response1.Status);
        });
    }
}
