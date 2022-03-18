// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PageableHelpersTest
    {
        [Test]
        public async Task IterateOverValuesAsync()
        {
            async IAsyncEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                yield return Page<int>.FromValues(new[]{1, 2, 3}, null, new MockResponse());
                await Task.Yield();
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            await foreach (var value in asyncPageable)
            {
                values.Add(value);
            }

            CollectionAssert.AreEqual(new[]{1,2,3,4,5,6}, values);
        }

        [Test]
        public void IterateOverValues()
        {
            IEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint)
            {
                yield return Page<int>.FromValues(new[]{1, 2, 3}, null, new MockResponse());
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var pageable = PageableHelpers.CreatePageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            foreach (var value in pageable)
            {
                values.Add(value);
            }

            CollectionAssert.AreEqual(new[]{1,2,3,4,5,6}, values);
        }

        [Test]
        public async Task IterateOverPagesAsync()
        {
            async IAsyncEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                if (nextLink == null)
                {
                    yield return Page<int>.FromValues(new[] { 1, 2, 3 }, null, new MockResponse());
                    await Task.Yield();
                }
                else
                {
                    Assert.AreEqual("ct", nextLink);
                }
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            await foreach (var page in asyncPageable.AsPages("ct"))
            {
                values.AddRange(page.Values);
            }

            CollectionAssert.AreEqual(new[]{4, 5, 6}, values);
        }

        [Test]
        public void IterateOverPagesValues()
        {
            IEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint)
            {
                if (nextLink == null)
                {
                    yield return Page<int>.FromValues(new[] {1, 2, 3}, null, new MockResponse());
                }
                else
                {
                    Assert.AreEqual("ct", nextLink);
                }
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var pageable = PageableHelpers.CreatePageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            foreach (var page in pageable.AsPages("ct"))
            {
                values.AddRange(page.Values);
            }

            CollectionAssert.AreEqual(new[]{4, 5, 6}, values);
        }

        [Test]
        public void IterateWithCancellationAsync()
        {
            async IAsyncEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                yield return Page<int>.FromValues(new[] { 1, 2, 3 }, null, new MockResponse());
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
                yield return Page<int>.FromValues(new[] { 4, 5, 6 }, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var cts = new CancellationTokenSource();

            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                await foreach (var value in asyncPageable.WithCancellation(cts.Token))
                {
                    if (value == 3)
                    {
                        cts.Cancel();
                    }
                }
            });
        }

        [Test]
        public async Task IterateWithCancellationAfterCheckAsync()
        {
            async IAsyncEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                yield return Page<int>.FromValues(new[] { 1, 2, 3 }, null, new MockResponse());
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
                yield return Page<int>.FromValues(new[] { 4, 5, 6 }, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var cts = new CancellationTokenSource();

            await foreach (var value in asyncPageable.WithCancellation(cts.Token))
            {
                if (value == 4)
                {
                    cts.Cancel();
                }
            }
        }

        [Test]
        public void SelectWithCancellationAsync()
        {
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                yield return Page<BinaryData>.FromValues(new[] { BinaryData.FromString("1"), BinaryData.FromString("2"), BinaryData.FromString("3") }, null, new MockResponse(new[] { 1, 2, 3 }));
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
                yield return Page<BinaryData>.FromValues(new[] { BinaryData.FromString("4"), BinaryData.FromString("5"), BinaryData.FromString("6") }, null, new MockResponse(new[] { 4, 5, 6 }));
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var selectPageable = PageableHelpers.Select(asyncPageable, r => ((MockResponse)r).Values);
            var cts = new CancellationTokenSource();
            var values = new List<int>();

            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                await foreach (var value in selectPageable.WithCancellation(cts.Token))
                {
                    values.Add(value);
                    if (value == 3)
                    {
                        cts.Cancel();
                    }
                }
            });

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, values);
        }

        [Test]
        public async Task SelectWithCancellationAfterCheckAsync()
        {
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                yield return Page<BinaryData>.FromValues(new[] { BinaryData.FromString("1"), BinaryData.FromString("2"), BinaryData.FromString("3") }, null, new MockResponse(new[] { 1, 2, 3 }));
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
                yield return Page<BinaryData>.FromValues(new[] { BinaryData.FromString("4"), BinaryData.FromString("5"), BinaryData.FromString("6") }, null, new MockResponse(new[] { 4, 5, 6 }));
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var selectPageable = PageableHelpers.Select(asyncPageable, r => ((MockResponse)r).Values);
            var cts = new CancellationTokenSource();
            var values = new List<int>();

            await foreach (var value in selectPageable.WithCancellation(cts.Token))
            {
                values.Add(value);
                if (value == 4)
                {
                    cts.Cancel();
                }
            }

            CollectionAssert.AreEqual(new[] { 1,2,3,4,5,6 }, values);
        }

        private class MockResponse : Response
        {
            public MockResponse() {}

            public MockResponse(IReadOnlyList<int> values)
            {
                Values = values;
            }

            public override void Dispose()
            {
                throw new System.NotImplementedException();
            }

            protected override bool TryGetHeader(string name, out string? value)
            {
                throw new System.NotImplementedException();
            }

            protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
            {
                throw new System.NotImplementedException();
            }

            protected override bool ContainsHeader(string name)
            {
                throw new System.NotImplementedException();
            }

            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                throw new System.NotImplementedException();
            }

            public override int Status { get; }
            public override string ReasonPhrase { get; }
            public override Stream? ContentStream { get; set; }
            public override string ClientRequestId { get; set; }
            public IReadOnlyList<int> Values { get; }
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}
