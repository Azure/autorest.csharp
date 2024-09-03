using _Specs_.Azure.ClientGenerator.Core.Access.Models;
using _Specs_.Azure.ClientGenerator.Core.Access;
using _Specs_.Azure.ClientGenerator.Core.FlattenProperty;
using _Specs_.Azure.ClientGenerator.Core.FlattenProperty.Models;
using _Specs_.Azure.ClientGenerator.Core.Usage.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CadlRanchProjects.Tests
{
    public class FlattenPropertyTest : CadlRanchTestBase
    {
        [Test]
        public Task Azure_ClientGenerator_Core_Flatten_Prop_PutModel() => Test(async (host) =>
        {
            var inputmodel = new FlattenModel("foo", "bar", 10);
            var response = await new FlattenPropertyClient(host, null).PutFlattenModelAsync(inputmodel);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value.Name);
            Assert.AreEqual("test", response.Value.Description);
            Assert.AreEqual(1, response.Value.Age);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Flatten_Prop_PutNestedModel() => Test(async (host) =>
        {
            var inputmodel = new NestedFlattenModel("foo", "bar", "test", 10);
            var response = await new FlattenPropertyClient(host, null).PutNestedFlattenModelAsync(inputmodel);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value.Name);
            Assert.AreEqual("test", response.Value.Summary);
            Assert.AreEqual("foo", response.Value.Description);
            Assert.AreEqual(1, response.Value.Age);
        });
    }
}
