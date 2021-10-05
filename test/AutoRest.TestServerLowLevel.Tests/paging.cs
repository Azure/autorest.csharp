// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using paging_LowLevel;
using CustomPagingRestClient = custom_baseUrl_paging_LowLevel.PagingRestClient;

namespace AutoRest.TestServer.Tests
{
    public class PagingTests : TestServerLowLevelTestBase
    {
        [Test]
        public Task PagingCustomUrlPartialNextLink() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "Product";

            // host is not a full hostname for CustomPagingOperations; it is a partial host
            var host = endpoint.ToString().Replace("http://", String.Empty);
            var linkPart = "/paging/customurl/partialnextlink/page/";

            var pageableAsync = new CustomPagingRestClient(Key, host).GetPagesPartialUrlAsync(string.Empty);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            }
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new CustomPagingRestClient(Key, host).GetPagesPartialUrl(string.Empty);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            }
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingCustomUrlPartialOperationNextLink() => Test(async (endpoint) =>
        {
            var id = 1;
            var accountName = "";
            var product = "Product";
            // host is not a full hostname for CustomPagingOperations; it is a partial host
            var host = endpoint.ToString().Replace("http://", String.Empty);
            var linkPart = "partialnextlinkop/page/";

            var pageableAsync = new CustomPagingRestClient(Key, host).GetPagesPartialUrlOperationAsync(accountName);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            }
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new CustomPagingRestClient(Key, host).GetPagesPartialUrlOperation(accountName);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            }
            Assert.AreEqual(2, id);
        });


        [Test]
        public Task PagingFragment() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "product";
            var tenant = "test_user";
            var linkPart = "next?page=";

            id = 1;
            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesFragmentNextLinkAsync("1.6", tenant);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);

            id = 1;
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesFragmentNextLink("1.6", tenant);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        });

        [Test]
        public Task PagingMultiple_Continuation() => Test(async (endpoint) =>
        {
            var client = new PagingRestClient(Key, endpoint);
            var pages = client.GetMultiplePages().AsPages().ToArray();

            for (int i = 1; i < pages.Length; i++)
            {
                var expectedPages = pages.Skip(i).ToArray();
                var actualPages = client.GetMultiplePages().AsPages(pages[i - 1].ContinuationToken).ToArray();

                Assert.That(expectedPages, Is.EquivalentTo(actualPages).Using<Page<BinaryData>>((p1, p2)=>
                    p1.Values.Count == p2.Values.Count && p1.ContinuationToken == p2.ContinuationToken));
            }

            for (int i = 1; i < pages.Length; i++)
            {
                var expectedPages = pages.Skip(i).ToArray();
                var actualPages = new List<Page<BinaryData>>();
                await foreach (var page in client.GetMultiplePagesAsync().AsPages(pages[i - 1].ContinuationToken))
                {
                    actualPages.Add(page);
                }

                Assert.That(expectedPages, Is.EquivalentTo(actualPages).Using<Page<BinaryData>>((p1, p2)=>
                    p1.Values.Count == p2.Values.Count && p1.ContinuationToken == p2.ContinuationToken));
            }
        }, ignoreScenario: true);

        [Test]
        public Task PagingMultiple() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesAsync(null, null);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);

            id = 1;
            product = "Product";
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePages(null, null);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        });

        [Test]
        public Task PagingMultipleWithQueryParameters() => Test(async (endpoint) =>
        {
            var value = 100;
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/nextOperationWithQueryParams";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetWithQueryParamsAsync(value);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith(linkPart, page.ContinuationToken);
                    id++;
                }
            }
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new PagingRestClient(Key, endpoint).GetWithQueryParams(value);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith(linkPart, page.ContinuationToken);
                    id++;
                }
            }
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingMultipleFailure() => Test((endpoint) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/failure/page/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await foreach (var page in pageableAsync.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            });
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesFailure();
            Assert.Throws<RequestFailedException>(() =>
            {
                foreach (var page in pageable.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            });
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingMultipleFailureUri() => Test((endpoint) =>
        {
            var id = 1;
            var product = "Product";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesFailureUriAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await foreach (var page in pageableAsync.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                    Assert.AreEqual("*&*#&$", page.ContinuationToken);
                    id++;
                }
            });
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesFailureUri();
            Assert.Throws<RequestFailedException>(() =>
            {
                foreach (var page in pageable.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                    Assert.AreEqual("*&*#&$", page.ContinuationToken);
                    id++;
                }
            });
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingMultipleLRO() => Test(async (endpoint) =>
        {
            var lro = await new PagingRestClient(Key, endpoint).GetMultiplePagesLROAsync("id");

            AsyncPageable<BinaryData> pageable = await lro.WaitForCompletionAsync();

            var product = "Product";
            int id = 1;
            await foreach (var item in pageable)
            {
                Assert.AreEqual(id, item.ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, item.ToObjectFromJson<Product>().Properties.Name);

                if (product == "Product")
                {
                    product = "product";
                }
                id += 1;
            }
        });

        [Test]
        public Task PagingMultiplePath() => Test(async (endpoint) =>
        {
            var id = 1;
            var pageNumber = 1;
            var product = "Product";
            var offset = 100;
            var linkPart = $"/paging/multiple/withpath/page/{offset}/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesWithOffsetAsync(offset);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (pageNumber == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++pageNumber}", page.ContinuationToken);
                }
                if (product == "Product")
                {
                    id += offset;
                    product = "product";
                }

                id++;
            }
            Assert.AreEqual(10, pageNumber);

            id = 1;
            pageNumber = 1;
            product = "Product";
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesWithOffset(offset);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (pageNumber == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++pageNumber}", page.ContinuationToken);
                }
                if (product == "Product")
                {
                    id += offset;
                    product = "product";
                }

                id++;
            }
            Assert.AreEqual(10, pageNumber);
        });

        [Test]
        public Task PagingMultipleRetryFirst() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesRetryFirstAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);

            id = 1;
            product = "Product";
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesRetryFirst();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        });

        [Test]
        public Task PagingMultipleRetrySecond() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/retrysecond/page/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetMultiplePagesRetrySecondAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                var tempId = id == 2 ? 1 : id;
                Assert.AreEqual(tempId, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                var tempProduct = id == 2 ? "Product" : product;
                Assert.AreEqual(tempProduct, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);

            id = 1;
            product = "Product";
            var pageable = new PagingRestClient(Key, endpoint).GetMultiplePagesRetrySecond();
            foreach (var page in pageable.AsPages())
            {
                var tempId = id == 2 ? 1 : id;
                Assert.AreEqual(tempId, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                var tempProduct = id == 2 ? "Product" : product;
                Assert.AreEqual(tempProduct, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        });

        [Test]
        public Task PagingNextLinkNameNull() => Test(async (endpoint) =>
        {
            var pageableAsync = new PagingRestClient(Key, endpoint).GetNullNextLinkNamePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingRestClient(Key, endpoint).GetNullNextLinkNamePages();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingNoItemName() => Test(async (endpoint) =>
        {
            var pageableAsync = new PagingRestClient(Key, endpoint).GetNoItemNamePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingRestClient(Key, endpoint).GetNoItemNamePages();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingReturnModelWithXMSClientName() => Test(async (endpoint) =>
        {
            var pageableAsync = new PagingRestClient(Key, endpoint).GetPagingModelWithItemNameWithXMSClientNameAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingRestClient(Key, endpoint).GetPagingModelWithItemNameWithXMSClientName();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingOdataMultiple() => Test(async (endpoint) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/odata/page/";

            var pageableAsync = new PagingRestClient(Key, endpoint).GetOdataMultiplePagesAsync(null, null);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);

            id = 1;
            product = "Product";
            var pageable = new PagingRestClient(Key, endpoint).GetOdataMultiplePages(null, null);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual(product, page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                if (id == 10)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        });

        [Test]
        public Task PagingSingle() => Test(async (endpoint) =>
        {
            var pageableAsync = new PagingRestClient(Key, endpoint).GetSinglePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingRestClient(Key, endpoint).GetSinglePages();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().ToObjectFromJson<Product>().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingSingleFailure() => Test((endpoint) =>
        {
            var pageableAsync = new PagingRestClient(Key, endpoint).GetSinglePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => { await foreach (var page in pageableAsync.AsPages()) { } });

            var pageable = new PagingRestClient(Key, endpoint).GetSinglePagesFailure();
            Assert.Throws<RequestFailedException>(() => { foreach (var page in pageable.AsPages()) { } });
        });

        [Test]
        public Task PagingFirstResponseEmpty() => Test(async (endpoint) =>
        {
            var result = new PagingRestClient(Key, endpoint).FirstResponseEmptyAsync();
            int count = 0;
            await foreach (var product in result)
            {
                count++;
                Assert.AreEqual(1, product.ToObjectFromJson<Product>().Properties.Id);
                Assert.AreEqual("Product", product.ToObjectFromJson<Product>().Properties.Name);
            }
            Assert.AreEqual(1, count);
        });

        [Test]
        public void RestClientDroppedMethods()
        {
            var client = typeof(PagingRestClient);
            Assert.IsNull(client.GetMethod ("CreateNextFragmentNextPageRequest", BindingFlags.Instance | BindingFlags.NonPublic), "CreateNextFragmentNextPageRequest should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPageAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPageAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPage", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPage should not be generated");
        }

        [Test]
        public void ClientDroppedMethods()
        {
            var client = typeof(PagingRestClient);
            Assert.IsNull(client.GetMethod ("NextFragmentAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragment", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragment should not be generated");
        }

        internal class Product
        {
            [JsonPropertyName("properties")]
            public ProductProperties Properties { get; set; }
        }

        internal class ProductProperties
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }
    }
}
