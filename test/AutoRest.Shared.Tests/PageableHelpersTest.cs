// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

            async IAsyncEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                Assert.AreEqual(1, scopes.Count);
                Assert.IsFalse(scopes[0].IsCompleted);
                yield return Page<int>.FromValues(new[]{1, 2, 3}, null, new MockResponse());
                await Task.Yield();
                Assert.AreEqual(2, scopes.Count);
                Assert.IsFalse(scopes[1].IsCompleted);
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            CollectionAssert.IsEmpty(scopes);

            var values = new List<int>();
            await foreach (var value in asyncPageable)
            {
                Assert.IsTrue(diagnosticListener.Scopes.TrueForAll(s => s.IsCompleted));
                values.Add(value);
            }

            CollectionAssert.AreEqual(new[]{1,2,3,4,5,6}, values);
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.TrueForAll(s => !s.IsFailed));
        }

        [Test]
        public void IterateOverValues()
        {
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

            IEnumerable<Page<int>> CreateEnumerable(string? nextLink, int? pageSizeHint)
            {
                Assert.AreEqual(1, scopes.Count);
                Assert.IsFalse(scopes[0].IsCompleted);
                yield return Page<int>.FromValues(new[]{1, 2, 3}, null, new MockResponse());
                Assert.AreEqual(2, scopes.Count);
                Assert.IsFalse(scopes[1].IsCompleted);
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var pageable = PageableHelpers.CreatePageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            CollectionAssert.IsEmpty(scopes);

            var values = new List<int>();
            foreach (var value in pageable)
            {
                Assert.IsTrue(diagnosticListener.Scopes.TrueForAll(s => s.IsCompleted));
                values.Add(value);
            }

            CollectionAssert.AreEqual(new[]{1,2,3,4,5,6}, values);
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.TrueForAll(s => !s.IsFailed));
        }

        [Test]
        public async Task IterateOverPagesAsync()
        {
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

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
                Assert.AreEqual(1, scopes.Count);
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var asyncPageable = PageableHelpers.CreateAsyncPageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            await foreach (var page in asyncPageable.AsPages("ct"))
            {
                Assert.IsTrue(diagnosticListener.Scopes.TrueForAll(s => s.IsCompleted));
                values.AddRange(page.Values);
            }

            CollectionAssert.AreEqual(new[]{4, 5, 6}, values);
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.TrueForAll(s => !s.IsFailed));
        }

        [Test]
        public void IterateOverPagesValues()
        {
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

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
                Assert.AreEqual(1, scopes.Count);
                yield return Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse());
            }

            var pageable = PageableHelpers.CreatePageable(CreateEnumerable, new ClientDiagnostics(new MockClientOptions()), "IterateOverValues");
            var values = new List<int>();
            foreach (var page in pageable.AsPages("ct"))
            {
                values.AddRange(page.Values);
            }

            CollectionAssert.AreEqual(new[]{4, 5, 6}, values);
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.TrueForAll(s => !s.IsFailed));
        }

        [Test]
        public void IterateWithCancellationAsync()
        {
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

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
                    Assert.AreEqual(1, scopes.Count);
                    Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
                    Assert.IsTrue(scopes.All(s => !s.IsFailed));

                    if (value == 3)
                    {
                        cts.Cancel();
                    }
                }
            });
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.Take(scopes.Count - 1).All(s => !s.IsFailed));
            Assert.IsTrue(scopes.Last().IsFailed);
        }

        [Test]
        public async Task IterateWithCancellationAfterCheckAsync()
        {
            using var diagnosticListener = new ClientDiagnosticListener("Azure.Core.Tests", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;

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
                Assert.AreEqual(1 + (value - 1) / 3, scopes.Count);
                Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
                Assert.IsTrue(scopes.All(s => !s.IsFailed));

                if (value == 4)
                {
                    cts.Cancel();
                }
            }
            Assert.IsTrue(scopes.TrueForAll(s => s.IsCompleted));
            Assert.IsTrue(scopes.All(s => !s.IsFailed));
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
