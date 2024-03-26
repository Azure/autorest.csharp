using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Assert.AreEqual(new AzureLocation("eastus"), response.Value);
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
            Assert.AreEqual(new AzureLocation("eastus"), response.Value.Location);
        });
        [Test]
        public Task Azure_Core_Scalar_AzureLocation_header() => Test(async (host) =>
        {
            var header = new AzureLocation("eastus");
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().HeaderAsync(header);
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Azure_Core_Scalar_AzureLocation_query() => Test(async (host) =>
        {
            var query = new AzureLocation("eastus");
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().QueryAsync(query);
            Assert.AreEqual(204, response.Status);
        });
    }
}
