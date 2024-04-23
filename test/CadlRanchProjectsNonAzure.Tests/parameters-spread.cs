using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using Scm.Parameters.Spread;
using Scm.Parameters.Spread.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class ParametersSpreadTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Parameters_Spread_Model_spreadAsRequestBody() => Test(async (host) =>
        {
            var response = await new SpreadClient(host, null).GetModelClient().SpreadAsRequestBodyAsync(new BodyParameter("foo"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestBody() => Test(async (host) =>
        {
            var response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestBodyAsync("foo");
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestParameter() => Test(async (host) =>
        {
            var response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestParameterAsync("1", "bar", "foo");
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithMultipleParameters() => Test(async (host) =>
        {
            var response = await new SpreadClient(host, null).GetAliasClient().SpreadWithMultipleParametersAsync("1", "bar", "foo1", "foo2", "foo3", "foo4", "foo5", "foo6");
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
