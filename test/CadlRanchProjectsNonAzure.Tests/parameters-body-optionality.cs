using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using Scm.Parameters.BodyOptionality;
using Scm.Parameters.BodyOptionality.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class ParametersBodyOptionalityTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Parameters_BodyOptionality_requiredExplicit() => Test(async (host) =>
        {
            var response = await new BodyOptionalityClient(host, null).RequiredExplicitAsync(new BodyModel("foo"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Parameters_BodyOptionality_OptionalExplicit() => Test(async (host) =>
        {
            var client = new BodyOptionalityClient(host, null).GetOptionalExplicitClient();
            var response = await client.SetAsync(new BodyModel("foo"));
            Assert.AreEqual(204, response.GetRawResponse().Status);

            response = await client.OmitAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Parameters_BodyOptionality_requiredImplicit() => Test(async (host) =>
        {
            var response = await new BodyOptionalityClient(host, null).RequiredImplicitAsync(new BodyModel("foo"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
