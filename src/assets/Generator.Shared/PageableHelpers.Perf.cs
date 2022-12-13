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
        private class AsyncPageableWithScope<T> : AsyncPageable<T> where T : notnull
        {
            private readonly Func<int?, HttpMessage>? _createFirstPageRequest;
            private readonly Func<int?, string, HttpMessage>? _createNextPageMethod;
            private readonly Func<JsonElement, T> _valueFactory;
            private readonly ResponseParser _responseParser;
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;
            private readonly int? _defaultPageSize;
            private readonly CancellationToken _cancellationToken;
            private readonly ErrorOptions? _errorOptions;

            public AsyncPageableWithScope(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ResponseParser responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, int? defaultPageSize, RequestContext? requestContext)
            {
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageMethod = createNextPageMethod;
                _responseParser = responseParser;
                _valueFactory = valueFactory;
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
                    var response = await SendRequestAsync(null, nextLink, cancellationToken).ConfigureAwait(false);
                    if (response == null)
                    {
                        yield break;
                    }

                    using var document = JsonDocument.Parse(response.Content);
                    foreach (var item in _responseParser.GetItemElement(document, out nextLink).EnumerateArray())
                    {
                        yield return _valueFactory(item);
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
                    var response = await SendRequestAsync(pageSizeHint, nextLink, cancellationToken).ConfigureAwait(false);
                    if (response == null)
                    {
                        yield break;
                    }
                    yield return _responseParser.CreatePage(_valueFactory, response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            private async ValueTask<Response?> SendRequestAsync(int? pageSizeHint, string? nextLink, CancellationToken cancellationToken)
            {
                var message = string.IsNullOrEmpty(nextLink)
                    ? _createFirstPageRequest?.Invoke(pageSizeHint ?? _defaultPageSize)
                    : _createNextPageMethod?.Invoke(pageSizeHint ?? _defaultPageSize, nextLink!);

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
            private readonly Func<JsonElement, T> _valueFactory;
            private readonly ResponseParser _responseParser;
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;
            private readonly int? _defaultPageSize;
            private readonly CancellationToken _cancellationToken;
            private readonly ErrorOptions? _errorOptions;

            public PageableWithScope(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ResponseParser responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, int? defaultPageSize, RequestContext? requestContext)
            {
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageMethod = createNextPageMethod;
                _valueFactory = valueFactory;
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
                    var response = SendRequest(null, nextLink);
                    if (response == null)
                    {
                        yield break;
                    }

                    using var document = JsonDocument.Parse(response.Content);
                    foreach (var item in _responseParser.GetItemElement(document, out nextLink).EnumerateArray())
                    {
                        yield return _valueFactory(item);
                    }
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public override IEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
            {
                string? nextLink = continuationToken;
                do
                {
                    var response = SendRequest(pageSizeHint, nextLink);
                    if (response == null)
                    {
                        yield break;
                    }

                    yield return _responseParser.CreatePage(_valueFactory, response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            private Response? SendRequest(int? pageSizeHint, string? nextLink)
            {
                var message = string.IsNullOrEmpty(nextLink)
                    ? _createFirstPageRequest?.Invoke(pageSizeHint ?? _defaultPageSize)
                    : _createNextPageMethod?.Invoke(pageSizeHint ?? _defaultPageSize, nextLink!);

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

        private readonly struct ResponseParser
        {
            private static readonly byte[] DefaultItemPropertyName = Encoding.UTF8.GetBytes("value");
            private static readonly byte[] DefaultNextLinkPropertyName = Encoding.UTF8.GetBytes("nextLink");

            private readonly byte[] _itemPropertyName;
            private readonly byte[] _nextLinkPropertyName;

            public ResponseParser(string? itemPropertyName, string? nextLinkPropertyName)
            {
                _itemPropertyName = itemPropertyName != null
                    ? Encoding.UTF8.GetBytes(itemPropertyName)
                    : DefaultItemPropertyName;
                _nextLinkPropertyName = nextLinkPropertyName != null
                    ? Encoding.UTF8.GetBytes(nextLinkPropertyName)
                    : DefaultNextLinkPropertyName;
            }

            public JsonElement GetItemElement(JsonDocument document, out string? nextLink)
            {
                var root = document.RootElement;
                nextLink = root.TryGetProperty(_nextLinkPropertyName, out var nextLinkValue) ? nextLinkValue.GetString() : null;
                return root.TryGetProperty(_itemPropertyName, out var itemsValue) ? itemsValue : default;
            }

            public Page<T> CreatePage<T>(Func<JsonElement, T> valueFactory, Response response, out string? nextLink)
            {
                using var document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);
                var itemElement = GetItemElement(document, out nextLink);

                var values = new List<T>(itemElement.GetArrayLength());
                foreach (var item in itemElement.EnumerateArray())
                {
                    values.Add(valueFactory(item));
                }

                return Page<T>.FromValues(values, nextLink, response);
            }
        }
    }
}
