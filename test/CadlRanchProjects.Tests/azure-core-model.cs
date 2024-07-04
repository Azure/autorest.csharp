using System;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Model;
using _Specs_.Azure.Core.Model.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureCoreModelTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_get() => Test(async (host) =>
        {
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().GetAzureCoreEmbeddingVectorAsync();
            var result = response.Value.ToArray();
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, result);
        });

        [Test]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_put() => Test(async (host) =>
        {
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PutAsync(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_post() => Test(async (host) =>
        {
            var body = new AzureEmbeddingModel(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PostAsync(body);
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 8, 9 }, response.Value.Embedding.ToArray());
        });
    }
}
