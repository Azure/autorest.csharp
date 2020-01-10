// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using paging;
using paging.Models.V100;

namespace AutoRest.TestServer.Tests
{
    [IgnoreOnTestServer(TestServerVersion.V2, "Doesn't resolve port value properly to create nextLink URLs.")]
    public class PagingTests : TestServerTestBase
    {
        public PagingTests(TestServerVersion version) : base(version, "paging") { }

        [Test]
        public Task PagingCustomUrlPartialNextLink() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingCustomUrlPartialOperationNextLink() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingFragment() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultiple() => Test(async (host, pipeline) =>
        {
            var id = 1;
            var product = "Product";
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetMultiplePagesFirstPageAsync(null, null, null);
            while (result.ContinuationToken != null)
            {
                Assert.AreEqual(id, result.Values.First().Properties.Id);
                Assert.AreEqual(product, result.Values.First().Properties.Name);
                StringAssert.EndsWith($"paging/multiple/page/{++id}", result.ContinuationToken);
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
                    StringAssert.EndsWith($"paging/multiple/page/{++id}", page.ContinuationToken);
                }
                product = "product";
            }
            Assert.AreEqual(10, id);
        }, true);

        [Test]
        public Task PagingMultipleFailure() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultipleFailureUri() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultipleLRO() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultiplePath() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultipleRetryFirst() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingMultipleRetrySecond() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingNextLinkNameNull() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingNoItemName() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingOdataMultiple() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PagingSingle() => Test(async (host, pipeline) =>
        {
            var result = await new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesFirstPageAsync();
            Assert.AreEqual(1, result.Values.First().Properties.Id);
            Assert.AreEqual("Product", result.Values.First().Properties.Name);

            var pageable = new PagingOperations(ClientDiagnostics, pipeline, host).GetSinglePagesAsync();
            await foreach (var page in pageable.AsPages())
            {
                Assert.AreEqual(1, page.Values.First().Properties.Id);
                Assert.AreEqual("Product", page.Values.First().Properties.Name);
                Assert.IsNull(page.ContinuationToken);
            }
        }, true);

        [Test]
        public Task PagingSingleFailure() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

    }
}
