using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm.Client.Naming;
using Scm.Client.Naming.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class ClientNamingTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Client_Naming_Property_client() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ClientAsync(true);
            Assert.AreEqual(204, response.GetRawResponse().Status);

            Assert.NotNull(typeof(ClientNameModel).GetProperty("ClientName"));
            Assert.IsNull(typeof(ClientNameModel).GetProperty("DefaultName"));
        });

        [Test]
        public Task Client_Naming_Property_language() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).LanguageAsync(true);
            Assert.AreEqual(204, response.GetRawResponse().Status);

            Assert.NotNull(typeof(LanguageClientNameModel).GetProperty("CSName"));
            Assert.IsNull(typeof(LanguageClientNameModel).GetProperty("DefaultName"));
        });

        [Test]
        public Task Client_Naming_Property_compatibleWithEncodedName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).CompatibleWithEncodedNameAsync(true);
            Assert.AreEqual(204, response.GetRawResponse().Status);

            Assert.NotNull(typeof(ClientNameModel).GetProperty("ClientName"));
            Assert.IsNull(typeof(ClientNameModel).GetProperty("DefaultName"));
        });

        [Test]
        public Task Client_Naming_operation() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ClientNameAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_parameter() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ParameterAsync(clientName: "true");
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_Header_request() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).RequestAsync(clientName: "true");
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_Header_response() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ResponseAsync();
            Assert.IsTrue(response.GetRawResponse().Headers.TryGetValue("default-name", out _));
            foreach (var header in response.GetRawResponse().Headers)
            {
                var key = header.Key;
                if (key == "default-name")
                {
                    var value = header.Value;
                    Assert.AreEqual("true", value);
                }
            }
        });

        [Test]
        public Task Client_Naming_Model_client() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetClientModelClient().ClientAsync(new Scm.Client.Naming.Models.ClientModel(true));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_Model_language() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetClientModelClient().LanguageAsync(new CSModel(true));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_UnionEnum_unionEnumName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetUnionEnumClient().UnionEnumNameAsync(ClientExtensibleEnum.EnumValue1);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Client_Naming_UnionEnum_unionEnumMemberName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetUnionEnumClient().UnionEnumMemberNameAsync(ExtensibleEnum.ClientEnumValue1);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
