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
    public static class ArmOperationHelpers
    {
        public static Response<TResult> WaitForCompletion<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken = default) where TResult : notnull
        {
            return operation.WaitForCompletion(OperationHelpers.DefaultPollingInterval, cancellationToken);
        }

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
            if ((requestMethod != RequestMethod.Put && (info.HeaderFrom == HeaderFrom.None || info.HeaderFrom != HeaderFrom.Location)) || finalStateVia == FinalStateVia.AzureAsyncOperation)
            {
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

                _rawResponse = await GetResponseAsync(_pipeline, _clientDiagnostics, _scopeName, _info.PollUri, cancellationToken).ConfigureAwait(false);
                _hasCompleted = IsTerminalState(GetRawResponse(), _info);
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (_info.FinalUri != null)
                    {
                        finalResponse = await GetResponseAsync(_pipeline, _clientDiagnostics, _scopeName, _info.FinalUri, cancellationToken).ConfigureAwait(false);
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

                _rawResponse = GetResponse(_pipeline, _clientDiagnostics, _scopeName, _info.PollUri, cancellationToken);
                _hasCompleted = IsTerminalState(GetRawResponse(), _info);
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (_info.FinalUri != null)
                    {
                        finalResponse = GetResponse(_pipeline, _clientDiagnostics, _scopeName, _info.FinalUri, cancellationToken);
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
        }

        private static HttpMessage CreateGetResponseRequest(HttpPipeline pipeline, string link)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(link, false);
            request.Uri = uri;
            return message;
        }

        private static async ValueTask<Response> GetResponseAsync(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, string link, CancellationToken cancellationToken = default)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }

            using var scope = clientDiagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                using var message = CreateGetResponseRequest(pipeline, link);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return message.Response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Response GetResponse(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, string link, CancellationToken cancellationToken = default)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }

            using var scope = clientDiagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                using var message = CreateGetResponseRequest(pipeline, link);
                pipeline.Send(message, cancellationToken);
                return message.Response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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
            public ScenarioInfo(HeaderFrom headerFrom, string pollUri, string? finalUri, RequestMethod requestMethod)
            {
                HeaderFrom = headerFrom;
                PollUri = pollUri;
                FinalUri = finalUri;
                RequestMethod = requestMethod;
            }

            public HeaderFrom HeaderFrom { get; }
            public string PollUri { get; }
            public string? FinalUri { get; }
            public RequestMethod RequestMethod { get; }
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
                return new ScenarioInfo(HeaderFrom.OperationLocation, operationLocation, GetFinalUri(), requestMethod);
            }

            if (response.Headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation))
            {
                return new ScenarioInfo(HeaderFrom.AzureAsyncOperation, azureAsyncOperation, GetFinalUri(), requestMethod);
            }

            if (hasLocation)
            {
                return new ScenarioInfo(HeaderFrom.Location, location!, null, requestMethod);
            }

            return new ScenarioInfo(HeaderFrom.None, originalUri, null, requestMethod);
        }

        private static readonly string[] _terminalStates = { "Succeeded", "Failed", "Canceled" };

        private static bool IsTerminalState(Response response, ScenarioInfo info)
        {
            if (info.HeaderFrom == HeaderFrom.Location)
            {
                return response.Status != 202;
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    if ((info.HeaderFrom == HeaderFrom.OperationLocation ||
                         info.HeaderFrom == HeaderFrom.AzureAsyncOperation) &&
                        property.NameEquals("status"))
                    {
                        return _terminalStates.Contains(property.Value.GetString());
                    }

                    if (info.HeaderFrom == HeaderFrom.None && property.NameEquals("properties"))
                    {
                        foreach (var innerProperty in property.Value.EnumerateObject())
                        {
                            if (innerProperty.NameEquals("provisioningState"))
                            {
                                return _terminalStates.Contains(innerProperty.Value.GetString());
                            }
                        }
                    }
                }
            }
            catch
            {
                // Could not parse JsonDocument. Continue.
            }
            finally
            {
                // It is required to reset the position of the content after reading as this response may be used for deserialization.
                if (response.ContentStream != null)
                {
                    response.ContentStream.Position = 0;
                }
            }

            return true;
        }
    }
}
