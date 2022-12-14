// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static partial class PageableHelpers
    {
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

        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            return new AsyncPageableWithScope<T>(null, createFirstPageRequest, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext);
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            var responseParser = new ResponseParser<T>(itemPropertyName, nextLinkPropertyName, valueFactory);
            return new PageableWithScope<T>(null, createFirstPageRequest, createNextPageMethod, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext);
        }

        public static async ValueTask<Operation<AsyncPageable<T>>> CreateAsyncPageable<T>(WaitUntil waitUntil, HttpMessage message, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, OperationFinalStateVia finalStateVia, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
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

        private class AsyncPageableWithScope<T> : AsyncPageable<T> where T : notnull
        {
            private readonly Func<int?, HttpMessage>? _createFirstPageRequest;
            private readonly Func<int?, string, HttpMessage>? _createNextPageMethod;
            private readonly Response? _initialResponse;
            private readonly ResponseParser<T> _responseParser;
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;
            private readonly int? _defaultPageSize;
            private readonly CancellationToken _cancellationToken;
            private readonly ErrorOptions? _errorOptions;

            public AsyncPageableWithScope(Response? initialResponse, Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, ResponseParser<T> responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, int? defaultPageSize, RequestContext? requestContext)
            {
                _initialResponse = initialResponse;
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageMethod = createNextPageMethod;
                _responseParser = responseParser;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _scopeName = scopeName;
                _defaultPageSize = defaultPageSize;
                _cancellationToken = requestContext?.CancellationToken ?? default;
                _errorOptions = requestContext?.ErrorOptions ?? ErrorOptions.Default;
            }

            public override async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                string? nextLink = null;
                do
                {
                    var response = await GetNextResponseAsync(null, nextLink, cancellationToken).ConfigureAwait(false);
                    if (response == null)
                    {
                        yield break;
                    }

                    using var enumerable = _responseParser.CreateEnumerator(response, out nextLink);
                    foreach (var item in enumerable)
                    {
                        yield return item;
                    }
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public override IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
                => AsPages(continuationToken, pageSizeHint, default);

            private async IAsyncEnumerable<Page<T>> AsPages(string? continuationToken, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                string? nextLink = continuationToken;
                do
                {
                    var response = await GetNextResponseAsync(pageSizeHint, nextLink, cancellationToken).ConfigureAwait(false);
                    if (response == null)
                    {
                        yield break;
                    }
                    yield return _responseParser.CreatePage(response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            private async ValueTask<Response?> GetNextResponseAsync(int? pageSizeHint, string? nextLink, CancellationToken cancellationToken)
            {
                HttpMessage? message;
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (_createFirstPageRequest == null)
                    {
                        return _initialResponse;
                    }

                    message = _createFirstPageRequest(pageSizeHint ?? _defaultPageSize);
                }
                else
                {
                    message = _createNextPageMethod?.Invoke(pageSizeHint ?? _defaultPageSize, nextLink!);
                }

                if (message == null)
                {
                    return null;
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                scope.Start();
                try
                {
                    if (cancellationToken.CanBeCanceled && _cancellationToken.CanBeCanceled)
                    {
                        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cancellationToken);
                        await _pipeline.SendAsync(message, cts.Token).ConfigureAwait(false);
                    }
                    else
                    {
                        var ct = cancellationToken.CanBeCanceled ? cancellationToken : _cancellationToken;
                        await _pipeline.SendAsync(message, ct).ConfigureAwait(false);
                    }

                    if (message.Response.IsError && _errorOptions != ErrorOptions.NoThrow)
                    {
                        throw new RequestFailedException(message.Response);
                    }

                    return message.Response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
        }

        private class PageableWithScope<T> : Pageable<T> where T : notnull
        {
            private readonly Func<int?, HttpMessage>? _createFirstPageRequest;
            private readonly Func<int?, string, HttpMessage>? _createNextPageMethod;
            private readonly Response? _initialResponse;
            private readonly ResponseParser<T> _responseParser;
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;
            private readonly int? _defaultPageSize;
            private readonly CancellationToken _cancellationToken;
            private readonly ErrorOptions? _errorOptions;

            public PageableWithScope(Response? initialResponse, Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, ResponseParser<T> responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, int? defaultPageSize, RequestContext? requestContext)
            {
                _initialResponse = initialResponse;
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageMethod = createNextPageMethod;
                _responseParser = responseParser;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _scopeName = scopeName;
                _defaultPageSize = defaultPageSize;
                _cancellationToken = requestContext?.CancellationToken ?? default;
                _errorOptions = requestContext?.ErrorOptions ?? ErrorOptions.Default;
            }

            public override IEnumerator<T> GetEnumerator()
            {
                string? nextLink = null;
                do
                {
                    var response = GetNextResponse(null, nextLink);
                    if (response == null)
                    {
                        yield break;
                    }

                    using var enumerable = _responseParser.CreateEnumerator(response, out nextLink);
                    foreach (var item in enumerable)
                    {
                        yield return item;
                    }
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public override IEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
            {
                string? nextLink = continuationToken;
                do
                {
                    var response = GetNextResponse(pageSizeHint, nextLink);
                    if (response == null)
                    {
                        yield break;
                    }

                    yield return _responseParser.CreatePage(response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            private Response? GetNextResponse(int? pageSizeHint, string? nextLink)
            {
                HttpMessage? message;
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (_createFirstPageRequest == null)
                    {
                        return _initialResponse;
                    }

                    message = _createFirstPageRequest(pageSizeHint ?? _defaultPageSize);
                }
                else
                {
                    message = _createNextPageMethod?.Invoke(pageSizeHint ?? _defaultPageSize, nextLink!);
                }

                if (message == null)
                {
                    return null;
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                scope.Start();
                try
                {
                    _pipeline.Send(message, _cancellationToken);

                    if (message.Response.IsError && _errorOptions != ErrorOptions.NoThrow)
                    {
                        throw new RequestFailedException(message.Response);
                    }

                    return message.Response;

                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
        }

        private readonly struct ResponseParser<T>
        {
            private static readonly byte[] DefaultItemPropertyName = Encoding.UTF8.GetBytes("value");
            private static readonly byte[] DefaultNextLinkPropertyName = Encoding.UTF8.GetBytes("nextLink");

            private readonly byte[] _itemPropertyName;
            private readonly byte[] _nextLinkPropertyName;
            private readonly Func<JsonElement, T> _valueFactory;

            public ResponseParser(string? itemPropertyName, string? nextLinkPropertyName, Func<JsonElement, T> valueFactory)
            {
                _itemPropertyName = itemPropertyName != null
                    ? Encoding.UTF8.GetBytes(itemPropertyName)
                    : DefaultItemPropertyName;
                _nextLinkPropertyName = nextLinkPropertyName != null
                    ? Encoding.UTF8.GetBytes(nextLinkPropertyName)
                    : DefaultNextLinkPropertyName;
                _valueFactory = valueFactory;
            }

            public Page<T> CreatePage(Response response, out string? nextLink)
            {
                using var enumerator = CreateEnumerator(response, out nextLink);
                if (enumerator.Count > 0)
                {
                    var values = new List<T>(enumerator.Count);
                    foreach (var item in enumerator)
                    {
                        values.Add(item);
                    }
                    return Page<T>.FromValues(values, nextLink, response);
                }

                return Page<T>.FromValues(Array.Empty<T>(), nextLink, response);
            }

            public ResponseEnumerator<T> CreateEnumerator(Response response, out string? nextLink)
            {
                if (typeof(T) == typeof(BinaryData))
                {
                    return CreateEnumeratorForBinaryData(response, out nextLink);
                }

                var document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);
                nextLink = document.RootElement.TryGetProperty(_nextLinkPropertyName, out var nextLinkValue) ? nextLinkValue.GetString() : null;
                if (!document.RootElement.TryGetProperty(_itemPropertyName, out var itemsValue))
                {
                    return new ResponseEnumerator<T>(document, default, 0, _valueFactory);
                }

                var count = itemsValue.GetArrayLength();
                var jsonArrayEnumerator = itemsValue.EnumerateArray();
                return new ResponseEnumerator<T>(document, jsonArrayEnumerator, count, _valueFactory);
            }

            // This method is used to avoid calling _valueFactory for BinaryData cause it requires instantiation of strings.
            // Remove it when `JsonElement` provides access to its UTF8 buffer.
            // See also PageableMethodsWriterExtensions.GetValueFactory
            private ResponseEnumerator<T> CreateEnumeratorForBinaryData(Response response, out string? nextLink)
            {
                var content = response.Content.ToMemory();
                var r = new Utf8JsonReader(content.Span);

                List<T>? items = null;
                nextLink = null;

                if (!r.Read() || r.TokenType != JsonTokenType.StartObject)
                {
                    throw new InvalidOperationException("Expected response to be JSON object");
                }

                while (r.Read())
                {
                    switch (r.TokenType)
                    {
                        case JsonTokenType.PropertyName:
                            if (r.ValueTextEquals(_nextLinkPropertyName))
                            {
                                r.Read();
                                nextLink = r.GetString();
                            }
                            else if (r.ValueTextEquals(_itemPropertyName))
                            {
                                if (!r.Read() || r.TokenType != JsonTokenType.StartArray)
                                {
                                    throw new InvalidOperationException($"Expected {Encoding.UTF8.GetString(_itemPropertyName)} to be an array");
                                }

                                while (r.Read() && r.TokenType != JsonTokenType.EndArray)
                                {
                                    var element = ReadBinaryData(ref r, content);
                                    items ??= new List<T>();
                                    items.Add((T)element);
                                }
                            }
                            else
                            {
                                r.Skip();
                            }
                            break;
                        case JsonTokenType.EndObject:
                            break;

                        default:
                            throw new Exception("Unexpected token");
                    }
                }

                return items != null
                    ? new ResponseEnumerator<T>(items.GetEnumerator(), items.Count)
                    : new ResponseEnumerator<T>(default, 0);

                static object ReadBinaryData(ref Utf8JsonReader r, in ReadOnlyMemory<byte> content)
                {
                    switch (r.TokenType)
                    {
                        case JsonTokenType.StartObject or JsonTokenType.StartArray:
                            int elementStart = (int)r.TokenStartIndex;
                            r.Skip();
                            int elementEnd = (int)r.TokenStartIndex;
                            int length = elementEnd - elementStart + 1;
                            return new BinaryData(content.Slice(elementStart, length));
                        case JsonTokenType.String:
                            return new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length + 2 /* open and closing quotes are not captured in the value span */));
                        default:
                            return new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length));
                    }
                }
            }
        }

        private struct ResponseEnumerator<T> : IDisposable
        {
            private readonly JsonDocument? _document;
            private readonly Func<JsonElement, T>? _valueFactory;

            private JsonElement.ArrayEnumerator _jsonArrayEnumerator;
            private List<T>.Enumerator _listEnumerator;
            private T? _current;

            public T Current => _current!;
            public int Count { get; }

            public ResponseEnumerator(JsonDocument document, JsonElement.ArrayEnumerator jsonArrayEnumerator, int count, Func<JsonElement, T> valueFactory)
            {
                Count = count;
                _document = document;
                _jsonArrayEnumerator = jsonArrayEnumerator;
                _listEnumerator = default;
                _valueFactory = valueFactory;
                _current = default;
            }

            public ResponseEnumerator(List<T>.Enumerator listEnumerator, int count)
            {
                Count = count;
                _document = default;
                _jsonArrayEnumerator = default;
                _listEnumerator = listEnumerator;
                _valueFactory = default;
                _current = default;
            }

            public bool MoveNext()
            {
                if (Count == 0)
                {
                    return false;
                }

                if (_valueFactory == null)
                {
                    var result = _listEnumerator.MoveNext();
                    _current = _listEnumerator.Current;
                    return result;
                }
                else
                {
                    var result = _jsonArrayEnumerator.MoveNext();
                    _current = result ? _valueFactory(_jsonArrayEnumerator.Current) : default;
                    return result;
                }
            }

            public void Dispose()
            {
                _jsonArrayEnumerator.Dispose();
                _listEnumerator.Dispose();
                _document?.Dispose();
            }

            public ResponseEnumerator<T> GetEnumerator() => this;
        }
    }
}
