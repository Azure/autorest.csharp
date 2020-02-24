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
    /// <summary>
    /// Helper methods for ARM long-running operations.
    /// </summary>
    public static class ArmOperationHelpers
    {
        /// <summary>
        /// Waits for the long-running operation to complete.
        /// </summary>
        /// <typeparam name="TResult">The response type</typeparam>
        /// <param name="operation">The operation to wait upon</param>
        /// <param name="cancellationToken">A cancellation token for the operation</param>
        /// <returns></returns>
        public static Response<TResult> WaitForCompletion<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken = default) where TResult : notnull
        {
            return operation.WaitForCompletion(OperationHelpers.DefaultPollingInterval, cancellationToken);
        }

        /// <summary>
        /// Waits for the long-running operation to complete, including a specified polling internal.
        /// </summary>
        /// <typeparam name="TResult">The response type</typeparam>
        /// <param name="operation">The operation to wait upon</param>
        /// <param name="pollingInterval">The duration to wait in-between each poll</param>
        /// <param name="cancellationToken">A cancellation token for the operation</param>
        /// <returns></returns>
        public static Response<TResult> WaitForCompletion<TResult>(this Operation<TResult> operation, TimeSpan pollingInterval, CancellationToken cancellationToken = default) where TResult : notnull
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                Thread.Sleep(pollingInterval);
            }
        }

        internal static Operation<T> Create<T>(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Response originalResponse, RequestMethod requestMethod, string scopeName, FinalStateVia finalStateVia,
            Func<HttpMessage> createOriginalHttpMessage, Func<Response, CancellationToken, Response<T>> createFinalResponse, Func<Response, CancellationToken, ValueTask<Response<T>>> createFinalResponseAsync) where T : notnull
        {
            using HttpMessage originalHttpMethod = createOriginalHttpMessage();
            string originalUri = originalHttpMethod.Request.Uri.ToString();
            ScenarioInfo info = GetScenarioInfo(originalResponse, originalUri, requestMethod, finalStateVia);
            if ((requestMethod != RequestMethod.Put && (info.HeaderFrom == HeaderFrom.None || !info.HasLocation)) || finalStateVia == FinalStateVia.AzureAsyncOperation)
            {
                // Support Operation Resource: https://github.com/Azure/autorest.csharp/issues/447
                throw clientDiagnostics.CreateRequestFailedException(originalResponse);
            }

            return new ArmOperation<T>(pipeline, clientDiagnostics, originalResponse, scopeName, info, createFinalResponse, createFinalResponseAsync);
        }

        private class ArmOperation<T> : Operation<T> where T : notnull
        {
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;
            private readonly Func<Response, CancellationToken, Response<T>> _createFinalResponse;
            private readonly Func<Response, CancellationToken, ValueTask<Response<T>>> _createFinalResponseAsync;
            private readonly ScenarioInfo _info;

            private Response _rawResponse;
            private T _value = default!;
            private bool _hasValue;
            private bool _hasCompleted;
            private bool _shouldPoll;

            public ArmOperation(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Response originalResponse, string scopeName, ScenarioInfo info,
                Func<Response, CancellationToken, Response<T>> createFinalResponse, Func<Response, CancellationToken, ValueTask<Response<T>>> createFinalResponseAsync)
            {
                _rawResponse = originalResponse;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _scopeName = scopeName;
                _createFinalResponse = createFinalResponse;
                _createFinalResponseAsync = createFinalResponseAsync;
                _info = info;
                // When the original response has no headers, we do not start polling immediately.
                _shouldPoll = _info.HeaderFrom != HeaderFrom.None;
            }

            public override Response GetRawResponse() => _rawResponse;

            public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
                this.DefaultWaitForCompletionAsync(OperationHelpers.DefaultPollingInterval, cancellationToken);

            public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (_shouldPoll)
                {
                    _rawResponse = await GetResponseAsync(_info.PollUri, cancellationToken).ConfigureAwait(false);
                }
                _shouldPoll = true;
                _hasCompleted = IsTerminalState();
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (_info.FinalUri != null)
                    {
                        finalResponse = await GetResponseAsync(_info.FinalUri, cancellationToken).ConfigureAwait(false);
                    }
                    switch (finalResponse.Status)
                    {
                        case 200:
                        case 204 when !(_info.RequestMethod == RequestMethod.Put || _info.RequestMethod == RequestMethod.Patch):
                        {
                            Response<T> typedResponse =  await _createFinalResponseAsync(finalResponse, cancellationToken).ConfigureAwait(false);
                            _rawResponse = typedResponse.GetRawResponse();
                            _value = typedResponse.Value;
                            _hasValue = true;
                            break;
                        }
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(finalResponse).ConfigureAwait(false);
                    }
                }

                return GetRawResponse();
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (_shouldPoll)
                {
                    _rawResponse = GetResponse(_info.PollUri, cancellationToken);
                }
                _shouldPoll = true;
                _hasCompleted = IsTerminalState();
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (_info.FinalUri != null)
                    {
                        finalResponse = GetResponse(_info.FinalUri, cancellationToken);
                    }
                    switch (finalResponse.Status)
                    {
                        case 200:
                        case 204 when !(_info.RequestMethod == RequestMethod.Put || _info.RequestMethod == RequestMethod.Patch):
                        {
                            Response<T> typedResponse = _createFinalResponse(finalResponse, cancellationToken);
                            _rawResponse = typedResponse.GetRawResponse();
                            _value = typedResponse.Value;
                            _hasValue = true;
                            break;
                        }
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(finalResponse);
                    }
                }

                return GetRawResponse();
            }

            //TODO: This is currently unused.
            public override string Id { get; } = Guid.NewGuid().ToString();

            public override T Value
            {
                get
                {
                    if (!HasValue)
                    {
                        throw new InvalidOperationException("The operation has not completed yet.");
                    }

                    return _value;
                }
            }
            public override bool HasCompleted => _hasCompleted;
            public override bool HasValue => _hasValue;

            private HttpMessage CreateGetResponseRequest(string link)
            {
                HttpMessage message = _pipeline.CreateMessage();
                Request request = message.Request;
                request.Method = RequestMethodAdditional.Get;
                var uri = new RawRequestUriBuilder();
                uri.AppendRaw(link, false);
                request.Uri = uri;
                return message;
            }

            private async ValueTask<Response> GetResponseAsync(string link, CancellationToken cancellationToken = default)
            {
                if (link == null)
                {
                    throw new ArgumentNullException(nameof(link));
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                scope.Start();
                try
                {
                    using HttpMessage message = CreateGetResponseRequest(link);
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                    return message.Response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            private Response GetResponse(string link, CancellationToken cancellationToken = default)
            {
                if (link == null)
                {
                    throw new ArgumentNullException(nameof(link));
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                scope.Start();
                try
                {
                    using HttpMessage message = CreateGetResponseRequest(link);
                    _pipeline.Send(message, cancellationToken);
                    return message.Response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            private static readonly string[] s_terminalStates = { "succeeded", "failed", "canceled" };

            private bool IsTerminalState()
            {
                Response response = GetRawResponse();
                if (_info.HeaderFrom == HeaderFrom.Location)
                {
                    return response.Status != 202;
                }

                if (response.ContentStream?.Length > 0 && response.Status >= 200 && response.Status <= 204)
                {
                    try
                    {
                        using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                        foreach (JsonProperty property in document.RootElement.EnumerateObject())
                        {
                            if ((_info.HeaderFrom == HeaderFrom.OperationLocation ||
                                 _info.HeaderFrom == HeaderFrom.AzureAsyncOperation) &&
                                property.NameEquals("status"))
                            {
                                return s_terminalStates.Contains(property.Value.GetString().ToLowerInvariant());
                            }

                            if (_info.HeaderFrom == HeaderFrom.None && property.NameEquals("properties"))
                            {
                                foreach (JsonProperty innerProperty in property.Value.EnumerateObject())
                                {
                                    if (innerProperty.NameEquals("provisioningState"))
                                    {
                                        return s_terminalStates.Contains(innerProperty.Value.GetString().ToLowerInvariant());
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        // It is required to reset the position of the content after reading as this response may be used for deserialization.
                        response.ContentStream.Position = 0;
                    }
                }

                throw _clientDiagnostics.CreateRequestFailedException(response);
            }
        }

        private enum HeaderFrom
        {
            None,
            OperationLocation,
            AzureAsyncOperation,
            Location
        }

        private class ScenarioInfo
        {
            public ScenarioInfo(HeaderFrom headerFrom, string pollUri, string? finalUri, RequestMethod requestMethod, bool hasLocation)
            {
                HeaderFrom = headerFrom;
                PollUri = pollUri;
                FinalUri = finalUri;
                RequestMethod = requestMethod;
                HasLocation = hasLocation;
            }

            public HeaderFrom HeaderFrom { get; }
            public string PollUri { get; }
            public string? FinalUri { get; }
            public RequestMethod RequestMethod { get; }
            public bool HasLocation { get; }
        }

        private static ScenarioInfo GetScenarioInfo(Response response, string originalUri, RequestMethod requestMethod, FinalStateVia finalStateVia)
        {
            bool hasLocation = response.Headers.TryGetValue("Location", out string? location);
            string? GetFinalUri()
            {
                if (requestMethod == RequestMethod.Put || finalStateVia == FinalStateVia.OriginalUri)
                {
                    return originalUri;
                }

                if (finalStateVia == FinalStateVia.Location)
                {
                    return location;
                }

                return null;
            }

            if (response.Headers.TryGetValue("Operation-Location", out string? operationLocation))
            {
                return new ScenarioInfo(HeaderFrom.OperationLocation, operationLocation, GetFinalUri(), requestMethod, hasLocation);
            }

            if (response.Headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation))
            {
                return new ScenarioInfo(HeaderFrom.AzureAsyncOperation, azureAsyncOperation, GetFinalUri(), requestMethod, hasLocation);
            }

            if (hasLocation)
            {
                return new ScenarioInfo(HeaderFrom.Location, location!, null, requestMethod, true);
            }

            return new ScenarioInfo(HeaderFrom.None, originalUri, null, requestMethod, false);
        }
    }
}
