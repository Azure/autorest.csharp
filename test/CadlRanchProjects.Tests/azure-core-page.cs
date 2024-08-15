using System;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Page;
using _Specs_.Azure.Core.Page.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureCorePageTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Core_Page_listWithPage() => Test(async (host) =>
        {
            var responses = new PageClient(host, null).GetWithPageAsync();
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.AreEqual(1, response.Id);
                Assert.AreEqual("Madge", response.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", response.Etag.ToString());
                sum++;
            };
            Assert.AreEqual(1, sum);
        });

        [Test]
        public Task Azure_Core_Page_listWithParameters() => Test(async (host) =>
        {
            var bodyInput = new ListItemInputBody("Madge");
            var responses = new PageClient(host, null).GetWithParametersAsync(bodyInput, ListItemInputExtensibleEnum.Second);
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.AreEqual(1, response.Id);
                Assert.AreEqual("Madge", response.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", response.Etag.ToString());
                sum++;
            };
            Assert.AreEqual(1, sum);
        });

        [Test]
        public Task Azure_Core_Page_TwoModelsAsPageItem() => Test(async (host) =>
        {
            var twoModelsAsPageItemClient = new PageClient(host, null).GetTwoModelsAsPageItemClient();
            var responses_firstItem = twoModelsAsPageItemClient.GetFirstItemsAsync();
            var responses_secondItem = twoModelsAsPageItemClient.GetSecondItemsAsync();
            var sum = 0;
            await foreach (var response in responses_firstItem)
            {
                Assert.AreEqual(1, response.Id);
                sum++;
            };
            Assert.AreEqual(1, sum);
            sum = 0;
            await foreach (var response in responses_secondItem)
            {
                Assert.AreEqual("Madge", response.Name);
                sum++;
            };
            Assert.AreEqual(1, sum);
        });

        [Test]
        public Task Azure_Core_Page_listWithCustomPageModel() => Test(async (host) =>
        {
            var responses = new PageClient(host, null).GetWithCustomPageModelAsync();
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.AreEqual(1, response.Id);
                Assert.AreEqual("Madge", response.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", response.Etag.ToString());
                sum++;
            };
            Assert.AreEqual(1, sum);
        });
    }
}
