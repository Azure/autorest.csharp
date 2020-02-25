// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using paging;
using CustomPagingOperations = custom_baseUrl_paging.PagingOperations;

namespace AutoRest.TestServer.Tests
{
    public class PagingTests : TestServerTestBase
    {
        public PagingTests(TestServerVersion version) : base(version, "paging") { }

        [Test]
        [Ignore("Partial nextLink support: https://github.com/Azure/autorest.csharp/issues/403")]
        public Task PagingCustomUrlPartialNextLink() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            // host is not a full hostname for CustomPagingOperations; it is a partial host
            host = host.Replace("http://", String.Empty);
            var linkPart = "/paging/customurl/partialnextlink/page/";
            var result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlAsync(string.Empty);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlNextPageAsync(resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlPageableAsync(string.Empty);
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
            var pageable = new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlPageable(string.Empty);
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
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task PagingCustomUrlPartialOperationNextLink() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var accountName = "";
            var product = "Product";
            // host is not a full hostname for CustomPagingOperations; it is a partial host
            host = host.Replace("http://", String.Empty);
            var linkPart = "partialnextlinkop/page/";
            var result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlOperationAsync(accountName);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlOperationNextAsync(accountName, resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlOperationPageableAsync(accountName);
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
            var pageable = new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlOperationPageable(accountName);
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
        }, true);

        [Test]
        [Ignore("Change path appending strategy: https://github.com/Azure/autorest.csharp/issues/411")]
        public Task PagingFragment() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "product";
            var tenant = "test_user";
            var linkPart = "next?page=";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkAsync("1.6", tenant);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.OdataNextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).NextFragmentAsync("1.6", tenant, resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.OdataNextLink, result.GetRawResponse());
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkPageableAsync("1.6", tenant);
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkPageable("1.6", tenant);
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
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Refused connection.")]
        public Task PagingMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesAsync(null, null, null);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesNextPageAsync(null, null, null, resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesPageableAsync(null, null, null);
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesPageable(null, null, null);
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
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Failure after 4 retries")]
        public Task PagingMultipleFailure() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/failure/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureAsync();
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());

            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
            StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
            Assert.ThrowsAsync<RequestFailedException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureNextPageAsync(resultPage.ContinuationToken));
            Assert.AreEqual(2, id);

            id = 1;
            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailurePageableAsync();
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailurePageable();
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
        }, true);

        [Test]
        public Task PagingMultipleFailureUri() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureUriAsync();
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());

            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
            Assert.AreEqual("*&*#&$", resultPage.ContinuationToken);
            Assert.ThrowsAsync<UriFormatException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureNextPageAsync(resultPage.ContinuationToken));

            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureUriPageableAsync();
            Assert.ThrowsAsync<UriFormatException>(async () =>
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureUriPageable();
            Assert.Throws<UriFormatException>(() =>
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
        }, true);

        [Test]
        [Ignore("Needs long running operation logic: https://github.com/Azure/autorest.csharp/issues/399")]
        public Task PagingMultipleLRO() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Refused connection.")]
        public Task PagingMultiplePath() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var pageNumber = 1;
            var product = "Product";
            var offset = 100;
            var linkPart = $"/paging/multiple/withpath/page/{offset}/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetAsync(null, null, offset, null);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++pageNumber}", resultPage.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetNextPageAsync(null, null, null, resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
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
            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetPageableAsync(null, null, offset, null);
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetPageable(null, null, offset, null);
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
        }, true);

        [Test]
        [Ignore("Needs retry logic: https://github.com/Azure/autorest.csharp/issues/398")]
        public Task PagingMultipleRetryFirst() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        [Ignore("Needs retry logic: https://github.com/Azure/autorest.csharp/issues/398")]
        public Task PagingMultipleRetrySecond() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task PagingNextLinkNameNull() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetNullNextLinkNamePagesAsync();
            var resultPage = Page.FromValues(result.Value.Values, null, result.GetRawResponse());
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesPageableAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesPageable();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task PagingNoItemName() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesAsync();
            var resultPage = Page.FromValues(result.Value.Value, result.Value.NextLink, result.GetRawResponse());
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesPageableAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesPageable();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Refused connection.")]
        public Task PagingOdataMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/odata/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesAsync(null, null, null);
            var resultPage = Page.FromValues(result.Value.Values, result.Value.OdataNextLink, result.GetRawResponse());
            while (resultPage.ContinuationToken != null)
            {
                Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
                Assert.AreEqual(product, resultPage.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", resultPage.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesNextPageAsync(null, null, null, resultPage.ContinuationToken);
                resultPage = Page.FromValues(result.Value.Values, result.Value.OdataNextLink, result.GetRawResponse());
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, resultPage.Values.First().Properties.Id);
            Assert.AreEqual(product, resultPage.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesPageableAsync(null, null, null);
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
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesPageable(null, null, null);
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
        }, true);

        [Test]
        public Task PagingSingle() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesAsync();
            var resultPage = Page.FromValues(result.Value.Values, result.Value.NextLink, result.GetRawResponse());
            Assert.AreEqual(1, resultPage.Values.First().Properties.Id);
            Assert.AreEqual("Product", resultPage.Values.First().Properties.Name);
            Assert.IsNull(resultPage.ContinuationToken);

            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesPageableAsync();
            await foreach (var page in pageableAsync.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesPageable();
            foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        public Task PagingSingleFailure() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFailureAsync());

            var pageableAsync = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFailurePageableAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => { await foreach (var page in pageableAsync.AsPages()) { } });

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFailurePageable();
            Assert.Throws<RequestFailedException>(() => { foreach (var page in pageable.AsPages()) { } });
        }, true);

    }
}
