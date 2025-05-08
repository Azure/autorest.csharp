// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using paging;
using paging.Models;
using CustomPagingClient = custom_baseUrl_paging.PagingClient;

namespace AutoRest.TestServer.Tests
{
    public class PagingTests : TestServerTestBase
    {
        private IEnumerable<T> GetValues<T>(object result, string propertyName = "Values")
        {
            return (IEnumerable<T>)GetProperty(GetProperty(result, "Value"), propertyName);
        }

        private string GetNextLink(object result, string propertyName = "NextLink")
        {
            return (string)GetProperty(GetProperty(result, "Value"), propertyName);
        }

        private Response GetRawResponse(object result)
            => (Response)InvokeMethod(result, "GetRawResponse");

        [Test]
        public Task PagingCustomUrlPartialNextLink() => Test(async (endpoint, pipeline) =>
        {
            var id = 1;
            var product = "Product";

            // host is not a full hostname for CustomPagingOperations; it is a partial host
            var host = endpoint.ToString().Replace("http://", String.Empty);
            var linkPart = "/paging/customurl/partialnextlink/page/";
            var result = await InvokeRestClient(GetClient<CustomPagingClient>(pipeline, host), "GetPagesPartialUrlAsync", [string.Empty]);
            var resultPage = Page.FromValues(GetValues<custom_baseUrl_paging.Models.Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<CustomPagingClient>(pipeline, host), "GetPagesPartialUrlNextPageAsync", [resultPage.ContinuationToken, string.Empty]);
                resultPage = Page.FromValues(GetValues<custom_baseUrl_paging.Models.Product>(result), GetNextLink(result), GetRawResponse(result));
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = GetClient<CustomPagingClient>(pipeline, host).GetPagesPartialUrlAsync(string.Empty);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<CustomPagingClient>(pipeline, host).GetPagesPartialUrl(string.Empty);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingCustomUrlPartialOperationNextLink() => Test(async (endpoint, pipeline) =>
        {
            var id = 1;
            var accountName = "";
            var product = "Product";
            // host is not a full hostname for CustomPagingOperations; it is a partial host
            var host = endpoint.ToString().Replace("http://", String.Empty);
            var linkPart = "partialnextlinkop/page/";
            var result = await InvokeRestClient(GetClient<CustomPagingClient>(pipeline, host), "GetPagesPartialUrlOperationAsync", [accountName]);
            var resultPage = Page.FromValues(GetValues<custom_baseUrl_paging.Models.Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<CustomPagingClient>(pipeline, host), "GetPagesPartialUrlOperationNextAsync", [accountName, resultPage.ContinuationToken]);
                resultPage = Page.FromValues(GetValues<custom_baseUrl_paging.Models.Product>(result), GetNextLink(result), GetRawResponse(result));
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = GetClient<CustomPagingClient>(pipeline, host).GetPagesPartialUrlOperationAsync(accountName);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<CustomPagingClient>(pipeline, host).GetPagesPartialUrlOperation(accountName);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingFragment() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "product";
            var tenant = "test_user";
            var linkPart = "next?page=";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesFragmentNextLinkAsync", ["1.6", tenant]);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result, "OdataNextLink"), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "NextFragmentAsync", ["1.6", tenant, resultPage.ContinuationToken]);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result, "OdataNextLink"), GetRawResponse(result));
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFragmentNextLinkAsync("1.6", tenant);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFragmentNextLink("1.6", tenant);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingMultiple_Continuation() => Test(async (host, pipeline) =>
        {
            var client = GetClient<PagingClient>(pipeline, host);
            var pages = client.GetMultiplePages().AsPages().ToArray();

            for (int i = 1; i < pages.Length; i++)
            {
                var expectedPages = pages.Skip(i).ToArray();
                var actualPages = client.GetMultiplePages().AsPages(pages[i - 1].ContinuationToken).ToArray();

                Assert.That(expectedPages, Is.EquivalentTo(actualPages).Using<Page<Product>>((p1, p2)=>
                    p1.Values.Count == p2.Values.Count && p1.ContinuationToken == p2.ContinuationToken));
            }

            for (int i = 1; i < pages.Length; i++)
            {
                var expectedPages = pages.Skip(i).ToArray();
                var actualPages = new List<Page<Product>>();
                await foreach (var page in client.GetMultiplePagesAsync().AsPages(pages[i - 1].ContinuationToken))
                {
                    actualPages.Add(page);
                }

                Assert.That(expectedPages, Is.EquivalentTo(actualPages).Using<Page<Product>>((p1, p2)=>
                    p1.Values.Count == p2.Values.Count && p1.ContinuationToken == p2.ContinuationToken));
            }
        }, ignoreScenario: true);

        [Test]
        public Task PagingMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesAsync", [default(PagingGetMultiplePagesOptions)]);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesNextPageAsync", [resultPage.ContinuationToken, default(PagingGetMultiplePagesOptions)]);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePages(null);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingMultipleWithQueryParameters() => Test(async (host, pipeline) =>
        {
            var value = 100;
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/nextOperationWithQueryParams";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetWithQueryParamsAsync", [value]);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id++, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith(linkPart, resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "NextOperationWithQueryParamsAsync", []);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetWithQueryParamsAsync(value);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetWithQueryParams(value);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingMultipleFailure() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/failure/page/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesFailureAsync", []);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));

            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
            StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
            Assert.ThrowsAsync<RequestFailedException>(async () => await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesFailureNextPageAsync", [resultPage.ContinuationToken]));
            Assert.AreEqual(2, id);

            id = 1;
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await foreach (var page in pageableAsync.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().Properties.Name);
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            });
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFailure();
            Assert.Throws<RequestFailedException>(() =>
            {
                foreach (var page in pageable.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().Properties.Name);
                    StringAssert.EndsWith($"{linkPart}{++id}", page.ContinuationToken);
                }
            });
            Assert.AreEqual(2, id);
        }, useSimplePipeline: true);

        [Test]
        public Task PagingMultipleFailureUri() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesFailureUriAsync", []);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));

            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
            Assert.AreEqual("*&*#&$", resultPage.ContinuationToken);
            Assert.ThrowsAsync<RequestFailedException>(async () => await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesFailureNextPageAsync", [resultPage.ContinuationToken]));

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFailureUriAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await foreach (var page in pageableAsync.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().Properties.Name);
                    Assert.AreEqual("*&*#&$", page.ContinuationToken);
                    id++;
                }
            });
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesFailureUri();
            Assert.Throws<RequestFailedException>(() =>
            {
                foreach (var page in pageable.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().Properties.Name);
                    Assert.AreEqual("*&*#&$", page.ContinuationToken);
                    id++;
                }
            });
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingMultipleLRO() => Test(async (host, pipeline) =>
        {
            var lro = await GetClient<PagingClient>(pipeline, host).StartGetMultiplePagesLROAsync(new PagingGetMultiplePagesLroOptions());

            AsyncPageable<Product> pageable = await lro.WaitForCompletionAsync();

            var product = "Product";
            int id = 1;
            await foreach (var item in pageable)
            {
                Assert.AreEqual(id, item.Properties.Id);
                Assert.AreEqual(product, item.Properties.Name);

                if (product == "Product")
                {
                    product = "product";
                }
                id += 1;
            }
        });

        [Test]
        public Task PagingMultiplePath() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var pageNumber = 1;
            var product = "Product";
            var offset = 100;
            var linkPart = $"/paging/multiple/withpath/page/{offset}/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesWithOffsetAsync", new PagingGetMultiplePagesWithOffsetOptions(offset));
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++pageNumber}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesWithOffsetNextPageAsync", resultPage.ContinuationToken, new PagingGetMultiplePagesWithOffsetOptions(offset));
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
                if (product == "Product")
                {
                    id += offset;
                    product = "product";
                }

                id++;
            }
            Assert.AreEqual(10, pageNumber);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            pageNumber = 1;
            product = "Product";
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesWithOffsetAsync(new PagingGetMultiplePagesWithOffsetOptions(offset));
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesWithOffset(new PagingGetMultiplePagesWithOffsetOptions(offset));
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingMultipleRetryFirst() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesRetryFirstAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesRetryFirstNextPageAsync", resultPage.ContinuationToken);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesRetryFirstAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesRetryFirst();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingMultipleRetrySecond() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/retrysecond/page/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesRetrySecondAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                var tempId = id == 2 ? 1 : id;
                Assert.AreEqual(tempId, resultPage.Values.First().Properties.Id);
                var tempProduct = id == 2 ? "Product" : product;
                Assert.AreEqual(tempProduct, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetMultiplePagesRetrySecondNextPageAsync", resultPage.ContinuationToken);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetMultiplePagesRetrySecondAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                var tempId = id == 2 ? 1 : id;
                Assert.AreEqual(tempId, page.Values.First().Properties.Id);
                var tempProduct = id == 2 ? "Product" : product;
                Assert.AreEqual(tempProduct, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetMultiplePagesRetrySecond();
            foreach (var page in pageable.AsPages())
            {
                var tempId = id == 2 ? 1 : id;
                Assert.AreEqual(tempId, page.Values.First().Properties.Id);
                var tempProduct = id == 2 ? "Product" : product;
                Assert.AreEqual(tempProduct, page.Values.First().Properties.Name);
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
        public Task PagingNextLinkNameNull() => Test(async (host, pipeline) =>
        {
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetNullNextLinkNamePagesAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result), null, GetRawResponse(result));
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetNullNextLinkNamePagesAsync();
            var pagesCount = 0;
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                pagesCount++;
            }
            Assert.AreEqual(1, pagesCount);

            var pageable = GetClient<PagingClient>(pipeline, host).GetNullNextLinkNamePages();
            pagesCount = 0;
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                pagesCount++;
            }
            Assert.AreEqual(1, pagesCount);
        });

        [Test]
        public Task PagingNoItemName() => Test(async (host, pipeline) =>
        {
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetNoItemNamePagesAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result, "Value"), GetNextLink(result), GetRawResponse(result));
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetNoItemNamePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = GetClient<PagingClient>(pipeline, host).GetNoItemNamePages();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingReturnModelWithXMSClientName() => Test(async (host, pipeline) =>
        {
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetPagingModelWithItemNameWithXMSClientNameAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result, "Indexes"), GetNextLink(result), GetRawResponse(result));
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetPagingModelWithItemNameWithXMSClientNameAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = GetClient<PagingClient>(pipeline, host).GetPagingModelWithItemNameWithXMSClientName();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingOdataMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/odata/page/";
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetOdataMultiplePagesAsync", [null]);
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result, "OdataNextLink"), GetRawResponse(result));
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetOdataMultiplePagesNextPageAsync", resultPage.ContinuationToken, null);
                resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result, "OdataNextLink"), GetRawResponse(result));
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetOdataMultiplePagesAsync(null);
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
            var pageable = GetClient<PagingClient>(pipeline, host).GetOdataMultiplePages(null);
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(id, page.Values.First().Properties.Id);
                Assert.AreEqual(product, page.Values.First().Properties.Name);
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
        public Task PagingSingle() => Test(async (host, pipeline) =>
        {
            var result = await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetSinglePagesAsync");
            var resultPage = Page.FromValues(GetValues<Product>(result), GetNextLink(result), GetRawResponse(result));
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetSinglePagesAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = GetClient<PagingClient>(pipeline, host).GetSinglePages();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        });

        [Test]
        public Task PagingSingleFailure() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await InvokeRestClient(GetClient<PagingClient>(pipeline, host), "GetSinglePagesFailureAsync"));

            var pageableAsync = GetClient<PagingClient>(pipeline, host).GetSinglePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => { await foreach (var page in pageableAsync.AsPages()) { } });

            var pageable = GetClient<PagingClient>(pipeline, host).GetSinglePagesFailure();
            Assert.Throws<RequestFailedException>(() => { foreach (var page in pageable.AsPages()) { } });
        });

        [Test]
        public Task PagingDuplicateParameters() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/duplicateParams/2?%24filter=serviceReturned&%24skiptoken=bar";

            var pageableAsync = GetClient<PagingClient>(pipeline, host).DuplicateParamsAsync("foo");
            await foreach (var page in pageableAsync.AsPages())
            {
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    Assert.AreEqual(id, page.Values.Single().Properties.Id);
                    Assert.AreEqual(product, page.Values.Single().Properties.Name);
                    StringAssert.EndsWith(linkPart, page.ContinuationToken);
                    id++;
                }
            }
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = GetClient<PagingClient>(pipeline, host).DuplicateParams("foo");
            foreach (var page in pageable.AsPages())
            {
                if (id == 2)
                {
                    Assert.IsNull(page.ContinuationToken);
                }
                else
                {
                    Assert.AreEqual(id, page.Values.Single().Properties.Id);
                    Assert.AreEqual(product, page.Values.Single().Properties.Name);
                    StringAssert.EndsWith(linkPart, page.ContinuationToken);
                    id++;
                }
            }
            Assert.AreEqual(2, id);
        });

        [Test]
        public Task PagingFirstResponseEmpty() => Test(async (host, pipeline) =>
        {
            var result = GetClient<PagingClient>(pipeline, host).FirstResponseEmptyAsync();
            int count = 0;
            await foreach (var product in result)
            {
                count++;
                Assert.AreEqual(1, product.Properties.Id);
                Assert.AreEqual("Product", product.Properties.Name);
            }
            Assert.AreEqual(1, count);
        });

        [Test]
        public void PagingModelsAreHidden()
        {
            Assert.IsFalse(FindType(typeof(PagingClient).Assembly, "ProductResult").IsPublic);
        }

        [Test]
        public void RestClientDroppedMethods()
        {
            var client = FindType(typeof(PagingClient).Assembly, "PagingRestClient");
            Assert.IsNull(client.GetMethod ("CreateNextFragmentNextPageRequest", BindingFlags.Instance | BindingFlags.NonPublic), "CreateNextFragmentNextPageRequest should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPageAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPageAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPage", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPage should not be generated");
        }

        [Test]
        public void ClientDroppedMethods()
        {
            var client = typeof(PagingClient);
            Assert.IsNull(client.GetMethod ("NextFragmentAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragment", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragment should not be generated");
        }
    }
}
