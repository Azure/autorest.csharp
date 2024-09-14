using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Basic;
using _Specs_.Azure.Core.Basic.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureCoreBasicTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Core_Basic_createOrUpdate() => Test(async (host) =>
        {
            var value = new
            {
                name = "Madge"
            };
            var response = await new BasicClient(host, null).CreateOrUpdateAsync(1, RequestContent.Create(value));
            Assert.AreEqual(200, response.Status);
            JsonData responseBody = JsonData.FromBytes(response.Content.ToMemory());
            Assert.AreEqual(1, (int)responseBody["id"]);
            Assert.AreEqual("Madge", (string)responseBody["name"]);
            Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", (string)responseBody["etag"]);
        });

        [Test]
        public Task Azure_Core_Basic_createOrReplace() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).CreateOrReplaceAsync(1, new User("Madge"));
            Assert.AreEqual("Madge", response.Name);
        });

        [Test]
        public Task Azure_Core_Basic_get() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).GetUserAsync(1);
            Assert.AreEqual("Madge", response.Name);
        });

        [Test]
        public Task Azure_Core_Basic_list() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetUsersAsync(5, 10, null, new[] {"id"}, "id lt 10", new[] {"id", "orders", "etag"}, new[] {"orders"});
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.AreEqual(1, firstUser.Id);
                Assert.AreEqual("Madge", firstUser.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", firstUser.Etag.ToString());
                Assert.AreEqual(1, firstUser.Orders.First().Id);
                Assert.AreEqual(1, firstUser.Orders.First().UserId);
                Assert.AreEqual("a recorder", firstUser.Orders.First().Detail);

                User secondUser = page.Values.Last();
                Assert.AreEqual(2, secondUser.Id);
                Assert.AreEqual("John", secondUser.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b5a", secondUser.Etag.ToString());
                Assert.AreEqual(2, secondUser.Orders.First().Id);
                Assert.AreEqual(2, secondUser.Orders.First().UserId);
                Assert.AreEqual("a TV", secondUser.Orders.First().Detail);
            }
        });

        [Test]
        public Task Azure_Core_Basic_listWithPage() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetWithPageAsync();
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.AreEqual("Madge", firstUser.Name);
            }
        });

        [Test]
        public Task Azure_Core_Basic_listWithCustomPageModel() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetWithCustomPageModelAsync();
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.AreEqual("Madge", firstUser.Name);
            }
        });

        [Test]
        public Task Azure_Core_Basic_delete() => Test(async (host) =>
        {
            var response = await new BasicClient(host, null).DeleteAsync(1);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Azure_Core_Basic_export() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).ExportAsync(1, "json");
            Assert.AreEqual("Madge", response.Name);
        });

        [Test]
        public Task Azure_Core_Basic_listWithParameters() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetWithParametersAsync(new ListItemInputBody("Madge"), ListItemInputExtensibleEnum.Second);
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.AreEqual(1, firstUser.Id);
                Assert.AreEqual("Madge", firstUser.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", firstUser.Etag.ToString());
            }
        });

        [Test]
        public Task Azure_Core_basic_TwoModelsAsPageItem() => Test(async (host) =>
        {
            var first = new BasicClient(host, null).GetTwoModelsAsPageItemClient().GetFirstItemsAsync();
            var second = new BasicClient(host, null).GetTwoModelsAsPageItemClient().GetSecondItemsAsync();
            await foreach (Page<FirstItem> page in first.AsPages())
            {
                FirstItem firstItem = page.Values.First();
                Assert.AreEqual(1, firstItem.Id);
            }
            await foreach (Page<SecondItem> page in second.AsPages())
            {
                SecondItem firstItem = page.Values.First();
                Assert.AreEqual("Madge", firstItem.Name);
            }
        });

        [Test]
        public void Azure_Core_basic_RenameGetMethod()
        {
            var getUserMethod = typeof(BasicClient).GetMethod("GetUserAsync", new[] { typeof(int), typeof(CancellationToken) });
            var getMethod  = typeof(BasicClient).GetMethod("Get", new[] { typeof(int), typeof(CancellationToken) });
            Assert.IsNull(getMethod);
            Assert.IsNotNull(getUserMethod);
        }

        [Test]
        public void Azure_Core_basic_RenameListMethod()
        {
            var getUsersMethod = typeof(BasicClient).GetMethod("GetUsersAsync", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            var listMethod = typeof(BasicClient).GetMethod("List", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            Assert.IsNull(listMethod);
            Assert.IsNotNull(getUsersMethod);
        }
    }
}
