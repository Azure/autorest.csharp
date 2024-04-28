using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm.Serialization.EncodedName.Json;
using Scm.Serialization.EncodedName.Json.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class SerializationEncodedNameJsonTests: CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Serialization_EncodedName_Json_Property_send() => Test(async (host) =>
        {
            var response = await new JsonClient(host, null).GetPropertyClient().SendAsync(new JsonEncodedNameModel(true));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Serialization_EncodedName_Json_Property_get() => Test(async (host) =>
        {
            var response = await new JsonClient(host, null).GetPropertyClient().GetPropertyAsync();
            Assert.AreEqual(true, response.Value.DefaultName);
        });
    }
}
