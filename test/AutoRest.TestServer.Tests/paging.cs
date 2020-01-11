// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using paging;
using CustomPagingOperations = custom_baseUrl_paging.PagingOperations;

namespace AutoRest.TestServer.Tests
{
    [IgnoreOnTestServer(TestServerVersion.V2, "Doesn't resolve port value properly to create nextLink URLs.")]
    public class PagingTests : TestServerTestBase
    {
        public PagingTests(TestServerVersion version) : base(version, "paging") { }

        [Test]
        public Task PagingCustomUrlPartialNextLink() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            // host is not a full hostname for CustomPagingOperations; it is a partial host
            host = host.Replace("http://", String.Empty);
            var linkPart = "/paging/customurl/partialnextlink/page/";
            var result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlFirstPageAsync(string.Empty);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", result.ContinuationToken);
                result = await new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlNextPageAsync(string.Empty, result.ContinuationToken);
            }
            Assert.AreEqual(2, id);
            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);

            id = 1;
            var pageable = new CustomPagingOperations(ClientDiagnostics, pipeline, host).GetPagesPartialUrlAsync(string.Empty);
            await foreach (var page in pageable.AsPages())
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
        [Ignore("operationName is not supported: https://github.com/Azure/autorest.csharp/issues/397")]
        public Task PagingCustomUrlPartialOperationNextLink() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        [Ignore("operationName is not supported: https://github.com/Azure/autorest.csharp/issues/397")]
        public Task PagingFragment() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "product";
            var tenant = "test_user";
            var linkPart = $"/paging/multiple/fragment/{tenant}";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkFirstPageAsync("1.6", tenant);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", result.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkNextPageAsync(result.ContinuationToken);
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);

            id = 1;
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFragmentNextLinkAsync("1.6", tenant);
            await foreach (var page in pageable.AsPages())
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
        public Task PagingMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFirstPageAsync(null, null, null);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", result.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesNextPageAsync(null, null, null, result.ContinuationToken);
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesAsync(null, null, null);
            await foreach (var page in pageable.AsPages())
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
        public Task PagingMultipleFailure() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/failure/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureFirstPageAsync();

            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);
            StringAssert.EndsWith($"{linkPart}{++id}", result.ContinuationToken);
            Assert.ThrowsAsync<RequestFailedException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureNextPageAsync(result.ContinuationToken));
            Assert.AreEqual(2, id);

            id = 1;
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await foreach (var page in pageable.AsPages())
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
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureUriFirstPageAsync();

            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);
            Assert.AreEqual("*&*#&$", result.ContinuationToken);
            Assert.ThrowsAsync<UriFormatException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureNextPageAsync(result.ContinuationToken));

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFailureUriAsync();
            Assert.ThrowsAsync<UriFormatException>(async () =>
            {
                await foreach (var page in pageable.AsPages())
                {
                    Assert.AreEqual(id, page.Values.First().Properties.Id);
                    Assert.AreEqual(product, page.Values.First().Properties.Name);
                    Assert.AreEqual("*&*#&$", result.ContinuationToken);
                    id++;
                }
            });
            Assert.AreEqual(2, id);
        }, true);

        [Test]
        [Ignore("Needs long running operation logic: https://github.com/Azure/autorest.csharp/issues/399")]
        public Task PagingMultipleLRO() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultiplePath() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var pageNumber = 1;
            var product = "Product";
            var offset = 42;
            var linkPart = $"/paging/multiple/withpath/page/{offset}/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetFirstPageAsync(null, null, offset, null);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++pageNumber}", result.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetNextPageAsync(null, null, null, result.ContinuationToken);
                if (product == "Product")
                {
                    id += offset;
                    product = "product";
                }

                id++;
            }
            Assert.AreEqual(10, pageNumber);
            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);

            id = 1;
            pageNumber = 1;
            product = "Product";
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesWithOffsetAsync(null, null, offset, null);
            await foreach (var page in pageable.AsPages())
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
        public Task PagingNextLinkNameNull() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetNullNextLinkNamePagesFirstPageAsync();
            Assert.AreEqual(1, result.Values.First().Properties.Id);
            Assert.AreEqual("Product", result.Values.First().Properties.Name);
            Assert.IsNull(result.ContinuationToken);

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesAsync();
            await foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        public Task PagingNoItemName() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesFirstPageAsync();
            Assert.AreEqual(1, result.Values.First().Properties.Id);
            Assert.AreEqual("Product", result.Values.First().Properties.Name);
            Assert.IsNull(result.ContinuationToken);

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetNoItemNamePagesAsync();
            await foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        public Task PagingOdataMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var linkPart = "/paging/multiple/odata/page/";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesFirstPageAsync(null, null, null);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"{linkPart}{++id}", result.ContinuationToken);
                result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesNextPageAsync(null, null, null, result.ContinuationToken);
                product = "product";
            }
            Assert.AreEqual(10, id);
            Assert.AreEqual(id, result.Values.First().Properties.Id);
            Assert.AreEqual(product, result.Values.First().Properties.Name);

            id = 1;
            product = "Product";
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetOdataMultiplePagesAsync(null, null, null);
            await foreach (var page in pageable.AsPages())
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
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFirstPageAsync();
            Assert.AreEqual(1, result.Values.First().Properties.Id);
            Assert.AreEqual("Product", result.Values.First().Properties.Name);
            Assert.IsNull(result.ContinuationToken);

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesAsync();
            await foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        public Task PagingSingleFailure() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFailureFirstPageAsync());
            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFailureAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => { await foreach (var page in pageable.AsPages()) { } });
        }, true);

    }
}
