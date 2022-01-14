// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class NextLinkOperationImplementation : IOperation
    {
        private static readonly string[] FailureStates = { "failed", "canceled" };
        private static readonly string[] SuccessStates = { "succeeded" };

        private readonly HeaderSource _headerSource;
        private readonly bool _originalResponseHasLocation;
        private readonly Uri _startRequestUri;
        private readonly OperationFinalStateVia _finalStateVia;
        private readonly RequestMethod _requestMethod;
        private readonly HttpPipeline _pipeline;

        private string? _lastKnownLocation;
        private string _nextRequestUri;

        public static IOperation Create(HttpPipeline pipeline, RequestMethod requestMethod, Uri startRequestUri, Response response, OperationFinalStateVia finalStateVia)
        {
            var headerSource = GetHeaderSource(requestMethod, startRequestUri, response, out var nextRequestUri);
            if (headerSource == HeaderSource.None && IsFinalState(response, headerSource, out var failureState))
            {
                return new CompletedOperation(failureState ?? GetOperationStateFromFinalResponse(requestMethod, response));
            }

            var (originalResponseHasLocation, lastKnownLocation) = headerSource == HeaderSource.Location
                ? (true, nextRequestUri)
                : response.Headers.TryGetValue("Location", out var locationUri)
                    ? (true, locationUri)
                    : (false, null);

            return new NextLinkOperationImplementation(pipeline, requestMethod, startRequestUri, nextRequestUri, headerSource, originalResponseHasLocation, lastKnownLocation, finalStateVia);
        }

        private NextLinkOperationImplementation(HttpPipeline pipeline, RequestMethod requestMethod, Uri startRequestUri, string nextRequestUri, HeaderSource headerSource, bool originalResponseHasLocation, string? lastKnownLocation, OperationFinalStateVia finalStateVia)
        {
            _requestMethod = requestMethod;
            _headerSource = headerSource;
            _startRequestUri = startRequestUri;
            _nextRequestUri = nextRequestUri;
            _originalResponseHasLocation = originalResponseHasLocation;
            _lastKnownLocation = lastKnownLocation;
            _finalStateVia = finalStateVia;
            _pipeline = pipeline;
        }

        public async ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = await GetResponseAsync(async, _nextRequestUri, cancellationToken).ConfigureAwait(false);

            var hasCompleted = IsFinalState(response, _headerSource, out var failureState);
            if (failureState != null)
            {
                return failureState.Value;
            }

            if (hasCompleted)
            {
                string? finalUri = GetFinalUri();
                var finalResponse = finalUri != null
                    ? await GetResponseAsync(async, finalUri, cancellationToken).ConfigureAwait(false)
                    : response;

                return GetOperationStateFromFinalResponse(_requestMethod, finalResponse);
            }

            UpdateNextRequestUri(response.Headers);
            return OperationState.Pending(response);
        }

        private static OperationState GetOperationStateFromFinalResponse(RequestMethod requestMethod, Response response)
        {
            switch (response.Status)
            {
                case 200:
                case 201 when requestMethod == RequestMethod.Put:
                case 204 when requestMethod != RequestMethod.Put && requestMethod != RequestMethod.Patch:
                    return OperationState.Success(response);
                default:
                    return OperationState.Failure(response);
            }
        }

        private void UpdateNextRequestUri(ResponseHeaders headers)
        {
            var hasLocation = headers.TryGetValue("Location", out string? location);
            if (hasLocation)
            {
                _lastKnownLocation = location;
            }

            switch (_headerSource)
            {
                case HeaderSource.OperationLocation when headers.TryGetValue("Operation-Location", out string? operationLocation):
                    _nextRequestUri = operationLocation;
                    return;
                case HeaderSource.AzureAsyncOperation when headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation):
                    _nextRequestUri = azureAsyncOperation;
                    return;
                case HeaderSource.Location when hasLocation:
                    _nextRequestUri = location!;
                    return;
            }
        }

        /// <summary>
        /// This function is used to get the final request uri after the lro has completed.
        /// </summary>
        private string? GetFinalUri()
        {
            // Set final uri as null if the response header doesn't contain "Operation-Location" or "Azure-AsyncOperation".
            if (_headerSource is not (HeaderSource.OperationLocation or HeaderSource.AzureAsyncOperation))
            {
                return null;
            }

            // Set final uri as null if original request is a delete method.
            if (_requestMethod == RequestMethod.Delete)
            {
                return null;
            }

            // Set final uri as original request's uri if one of these requirements are met:
            // 1.Original request is a put method;
            // 2.Original request is a management plane patch method. For data plane patch method, the final uri will be determinned by the original response header and "_finalStateVia";
            // 3.Original response header contains "Location" and FinalStateVia is configured to OriginalUri.
            if (_requestMethod == RequestMethod.Put || _requestMethod == RequestMethod.Patch && _startRequestUri.Scheme == "https" && _startRequestUri.Host == "management.azure.com" || _originalResponseHasLocation && _finalStateVia == OperationFinalStateVia.OriginalUri)
            {
                return _startRequestUri.AbsoluteUri;
            }

            // Set final uri as last known location header if original response header contains "Location" and FinalStateVia is configured to Location.
            if (_originalResponseHasLocation && _finalStateVia == OperationFinalStateVia.Location)
            {
                return _lastKnownLocation;
            }
            return null;
        }

        private async ValueTask<Response> GetResponseAsync(bool async, string uri, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateRequest(uri);
            if (async)
            {
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message, cancellationToken);
            }
            return message.Response;
        }

        private HttpMessage CreateRequest(string uri)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;

            if (Uri.TryCreate(uri, UriKind.Absolute, out var nextLink) && nextLink.Scheme != "file")
            {
                request.Uri.Reset(nextLink);
            }
            else
            {
                request.Uri.Reset(new Uri(_startRequestUri, uri));
            }

            return message;
        }

        private static bool IsFinalState(Response response, HeaderSource headerSource, out OperationState? failureState)
        {
            failureState = null;
            if (headerSource == HeaderSource.Location)
            {
                return response.Status != 202;
            }

            if (response.Status is >= 200 and <= 204)
            {
                if (response.ContentStream?.Length > 0)
                {
                    try
                    {
                        using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                        var root = document.RootElement;
                        switch (headerSource)
                        {
                            case HeaderSource.None when root.TryGetProperty("properties", out var properties) && properties.TryGetProperty("provisioningState", out JsonElement property):
                            case HeaderSource.OperationLocation when root.TryGetProperty("status", out property):
                            case HeaderSource.AzureAsyncOperation when root.TryGetProperty("status", out property):
                                var state = property.GetRequiredString().ToLowerInvariant();
                                if (FailureStates.Contains(state))
                                {
                                    failureState = OperationState.Failure(response);
                                    return true;
                                }
                                else
                                {
                                    return SuccessStates.Contains(state);
                                }
                        }
                    }
                    finally
                    {
                        // It is required to reset the position of the content after reading as this response may be used for deserialization.
                        response.ContentStream.Position = 0;
                    }
                }

                // If provisioningState was not found, it defaults to Succeeded.
                if (headerSource == HeaderSource.None)
                {
                    return true;
                }
            }

            failureState = OperationState.Failure(response);
            return true;
        }

        private static bool ShouldIgnoreHeader(RequestMethod method, Response response)
            => method.Method == RequestMethod.Patch.Method && response.Status == 200;

        private static HeaderSource GetHeaderSource(RequestMethod requestMethod, Uri requestUri, Response response, out string nextRequestUri)
        {
            if (ShouldIgnoreHeader(requestMethod, response))
            {
                nextRequestUri = requestUri.AbsoluteUri;
                return HeaderSource.None;
            }

            var headers = response.Headers;
            if (headers.TryGetValue("Operation-Location", out var operationLocationUri))
            {
                nextRequestUri = operationLocationUri;
                return HeaderSource.OperationLocation;
            }

            if (headers.TryGetValue("Azure-AsyncOperation", out var azureAsyncOperationUri))
            {
                nextRequestUri = azureAsyncOperationUri;
                return HeaderSource.AzureAsyncOperation;
            }

            if (headers.TryGetValue("Location", out var locationUri))
            {
                nextRequestUri = locationUri;
                return HeaderSource.Location;
            }

            nextRequestUri = requestUri.AbsoluteUri;
            return HeaderSource.None;
        }

        private enum HeaderSource
        {
            None,
            OperationLocation,
            AzureAsyncOperation,
            Location
        }

        private class CompletedOperation : IOperation
        {
            private readonly OperationState _operationState;

            public CompletedOperation(OperationState operationState)
            {
                _operationState = operationState;
            }

            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(_operationState);
        }
    }
}
