using System.Threading.Tasks;
using _Specs_.Azure.Core.Scalar;
using _Specs_.Azure.Core.Scalar.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureCoreScalarTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Core_Scalar_AzureLocation_get() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().GetAzureLocationScalarAsync();
            Assert.AreEqual(AzureLocation.EastUS, response.Value);
        });
        [Test]
        public Task Azure_Core_Scalar_AzureLoction_put() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PutAsync(new AzureLocation("eastus"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Azure_Core_Scalar_AzureLoction_post() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PostAsync(new AzureLocationModel(new AzureLocation("eastus")));
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Location);
        });
        [Test]
        public Task Azure_Core_Scalar_AzureLocation_header() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().HeaderAsync(AzureLocation.EastUS);
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Azure_Core_Scalar_AzureLocation_query() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().QueryAsync(AzureLocation.EastUS);
            Assert.AreEqual(204, response.Status);
        });
    }
}
