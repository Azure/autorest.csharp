// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static partial class PageableHelpers
    {
        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<string?, int?, CancellationToken, IAsyncEnumerable<Page<T>>> enumerableFactory, ClientDiagnostics clientDiagnostics, string scopeName) where T : notnull
            => new AsyncPageableWrapper<T>((ct, ph) => new AsyncEnumerableWithScope<T>(enumerableFactory(ct, ph, default), clientDiagnostics, scopeName));

        public static Pageable<T> CreatePageable<T>(Func<string?, int?, IEnumerable<Page<T>>> enumerableFactory, ClientDiagnostics clientDiagnostics, string scopeName) where T : notnull
            => new PageableWrapper<T>((ct, ph) => new EnumerableWithScope<T>(enumerableFactory(ct, ph), clientDiagnostics, scopeName));

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(Func<int?, Task<Page<T>>> firstPageFunc, Func<string?, int?, Task<Page<T>>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            AsyncPageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            AsyncPageFunc<T>? next = nextPageFunc != null ? new AsyncPageFunc<T>(nextPageFunc) : null;
            return new FuncAsyncPageable<T>(first, next, pageSize);
        }

        public static Pageable<T> CreateEnumerable<T>(Func<int?, Page<T>> firstPageFunc, Func<string?, int?, Page<T>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            PageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            PageFunc<T>? next = nextPageFunc != null ? new PageFunc<T>(nextPageFunc) : null;
            return new FuncPageable<T>(first, next, pageSize);
        }

        public static AsyncPageable<T> CreatePageableAsync<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            return new AsyncPageableWithScope<T>(null, createFirstPageRequest, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext);
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            return new PageableWithScope<T>(null, createFirstPageRequest, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext);
        }

        public static async ValueTask<Operation<AsyncPageable<T>>> CreatePageableAsync<T>(WaitUntil waitUntil, HttpMessage message, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, OperationFinalStateVia finalStateVia, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new ProtocolOperation<AsyncPageable<T>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => new AsyncPageableWithScope<T>(r, null, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<Pageable<T>> CreatePageable<T>(WaitUntil waitUntil, HttpMessage message, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, OperationFinalStateVia finalStateVia, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new ProtocolOperation<Pageable<T>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => new PageableWithScope<T>(r, null, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        internal delegate Task<Page<T>> AsyncPageFunc<T>(string? continuationToken = default, int? pageSizeHint = default);
        internal delegate Page<T> PageFunc<T>(string? continuationToken = default, int? pageSizeHint = default);

        private class PageableWrapper<T> : Pageable<T> where T : notnull
        {
            private readonly Func<string?, int?, IEnumerable<Page<T>>> _enumerableFactory;
            public PageableWrapper(Func<string?, int?, IEnumerable<Page<T>>> enumerableFactory) => _enumerableFactory = enumerableFactory;
            public override IEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _enumerableFactory(continuationToken, pageSizeHint);
        }

        private class AsyncPageableWrapper<T> : AsyncPageable<T> where T : notnull
        {
            private readonly Func<string?, int?, IAsyncEnumerable<Page<T>>>  _enumerableFactory;
            public AsyncPageableWrapper(Func<string?, int?, IAsyncEnumerable<Page<T>>> enumerableFactory) => _enumerableFactory = enumerableFactory;
            public override IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _enumerableFactory(continuationToken, pageSizeHint);
        }

        private class EnumerableWithScope<T> : IEnumerable<Page<T>>
        {
            private readonly IEnumerable<Page<T>> _enumerable;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;

            public EnumerableWithScope(IEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName)
                => (_enumerable, _clientDiagnostics, _scopeName) = (enumerable, clientDiagnostics, scopeName);

            public IEnumerator<Page<T>> GetEnumerator()
                => new Enumerator(_enumerable.GetEnumerator(), _clientDiagnostics, _scopeName);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private class Enumerator : IEnumerator<Page<T>>
            {
                private readonly IEnumerator<Page<T>> _enumerator;
                private readonly ClientDiagnostics _clientDiagnostics;
                private readonly string _scopeName;

                public Enumerator(IEnumerator<Page<T>> enumerator, ClientDiagnostics clientDiagnostics, string scopeName)
                    => (_enumerator, _clientDiagnostics, _scopeName) = (enumerator, clientDiagnostics, scopeName);

                public Page<T> Current => _enumerator.Current;
                object IEnumerator.Current => _enumerator.Current;

                public bool MoveNext()
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        return _enumerator.MoveNext();
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }

                public void Reset() => _enumerator.Reset();
                public void Dispose() => _enumerator.Dispose();
            }
        }

        private class AsyncEnumerableWithScope<T> : IAsyncEnumerable<Page<T>>
        {
            private readonly IAsyncEnumerable<Page<T>> _enumerable;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;

            public AsyncEnumerableWithScope(IAsyncEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName)
                => (_enumerable, _clientDiagnostics, _scopeName) = (enumerable, clientDiagnostics, scopeName);

            public IAsyncEnumerator<Page<T>> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
                => new Enumerator(_enumerable.GetAsyncEnumerator(cancellationToken), _clientDiagnostics, _scopeName);

            private class Enumerator : IAsyncEnumerator<Page<T>>
            {
                private readonly IAsyncEnumerator<Page<T>> _enumerator;
                private readonly ClientDiagnostics _clientDiagnostics;
                private readonly string _scopeName;

                public Enumerator(IAsyncEnumerator<Page<T>> enumerator, ClientDiagnostics clientDiagnostics, string scopeName)
                    => (_enumerator, _clientDiagnostics, _scopeName) = (enumerator, clientDiagnostics, scopeName);

                public ValueTask DisposeAsync() => _enumerator.DisposeAsync();

                public async ValueTask<bool> MoveNextAsync()
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        return await _enumerator.MoveNextAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }

                public Page<T> Current => _enumerator.Current;
            }
        }

        internal class FuncAsyncPageable<T> : AsyncPageable<T> where T : notnull
        {
            private readonly AsyncPageFunc<T> _firstPageFunc;
            private readonly AsyncPageFunc<T>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncAsyncPageable(AsyncPageFunc<T> firstPageFunc, AsyncPageFunc<T>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                AsyncPageFunc<T>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = await pageFunc(continuationToken, pageSize).ConfigureAwait(false);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }

        internal class FuncPageable<T> : Pageable<T> where T : notnull
        {
            private readonly PageFunc<T> _firstPageFunc;
            private readonly PageFunc<T>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncPageable(PageFunc<T> firstPageFunc, PageFunc<T>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override IEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                PageFunc<T>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = pageFunc(continuationToken, pageSize);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }
    }
}
