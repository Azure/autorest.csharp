using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _Type.Scalar;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using YamlDotNet.Core.Tokens;

namespace CadlRanchProjects.Tests
{
    public class TypeScalarTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Scalar_String_get() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetStringClient().GetStringAsync();
            Assert.AreEqual("test", response.Value);
        });
        [Test]
        public Task Type_Scalar_String_put() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetStringClient().PutAsync("test");
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Scalar_Boolean_get() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetBooleanClient().GetBooleanAsync();
            Assert.AreEqual(true, response.Value);
        });
        [Test]
        public Task Type_Scalar_Boolean_put() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetBooleanClient().PutAsync(true);
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Scalar_Unknown_get() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetUnknownClient().GetUnknownAsync();
            Assert.AreEqual("test", response.Value.ToObjectFromJson<string>());
        });
        [Test]
        public Task Type_Scalar_Unknown_put() => Test(async (host) =>
        {
            var body = BinaryData.FromString("\"test\"");
            var response = await new ScalarClient(host, null).GetUnknownClient().PutAsync(body);
            Assert.AreEqual(204, response.Status);
        });
    }
}
