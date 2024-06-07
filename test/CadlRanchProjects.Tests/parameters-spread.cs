using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Parameters.Spread;
using Parameters.Spread.Models;

namespace CadlRanchProjects.Tests
{
    public class ParametersSpreadTests : CadlRanchTestBase
    {
        [Test]
        public Task Parameters_Spread_Model_spreadAsRequestBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadAsRequestBodyAsync(new BodyParameter("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestBodyAsync("foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestParameter() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestParameterAsync("1", "bar", "foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithMultipleParameters() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadWithMultipleParametersAsync("1", "bar", "foo1", "foo2", "foo3", "foo4", "foo5", "foo6");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithModel() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAliasWithModelAsync("1", "bar", new ModelParameter("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithoutOptionalProps() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAliasWithOptionalPropsAsync("1", "bar", "dog", new[] { 1,2,3});
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithOptionalProps() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAliasWithOptionalPropsAsync("2", "bar", "dog", new[] { 1, 2, 3, 4 }, "red", 3, new[] { "a", "b" } );
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_Spread_Alias_With_RequiredAndOptionalCollections() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAliasWithOptionalCollectionsAsync(new[] { "a", "b" }, new[] { "c", "d" });
            Assert.AreEqual(204, response.Status);
        });
    }
}
