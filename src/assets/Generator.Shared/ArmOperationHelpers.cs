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
        //public static Operation<T> Create<T>(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Response originalResponse, bool isPutOrPatch, string scopeName,
        //    Func<HttpMessage> createOriginalHttpMessage, Func<Response, CancellationToken, Response<T>> createFinalResponse, Func<Response, CancellationToken, ValueTask<Response<T>>> createFinalResponseAsync) where T : notnull
        //{
        //    using HttpMessage originalHttpMethod = createOriginalHttpMessage();
        //    string originalUri = originalHttpMethod.Request.Uri.ToString();
        //    ScenarioInfo originalInfo = GetScenarioInfo(originalResponse, originalUri);
        //    if (!isPutOrPatch && (originalInfo.HeaderFrom == HeaderFrom.None || originalInfo.HeaderFrom != HeaderFrom.Location))
        //    {
        //        throw clientDiagnostics.CreateRequestFailedException(originalResponse);
        //    }

        //    return OperationFactory.Create(originalResponse, (r, c) =>
        //    {
        //        ScenarioInfo info = GetScenarioInfo(r, originalUri);
        //        return GetResponse(pipeline, clientDiagnostics, scopeName, info.PollUri, c);
        //    }, r =>
        //    {
        //        ScenarioInfo info = GetScenarioInfo(r, originalUri);
        //        return IsTerminalState(r, info);
        //    }, (r, c) =>
        //    {
        //        string finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
        //        Response response = GetResponse(pipeline, clientDiagnostics, scopeName, finalUri, c);
        //        switch (response.Status)
        //        {
        //            case 200:
        //            case 204 when !isPutOrPatch:
        //            {
        //                return createFinalResponse(response, c);
        //            }
        //            default:
        //                throw clientDiagnostics.CreateRequestFailedException(response);
        //        }
        //    }, async (r, c) =>
        //    {
        //        ScenarioInfo info = GetScenarioInfo(r, originalUri);
        //        return await GetResponseAsync(pipeline, clientDiagnostics, scopeName, info.PollUri, c).ConfigureAwait(false);
        //    }, async (r, c) =>
        //    {
        //        string finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
        //        Response response = await GetResponseAsync(pipeline, clientDiagnostics, scopeName, finalUri, c).ConfigureAwait(false);
        //        switch (response.Status)
        //        {
        //            case 200:
        //            case 204 when !isPutOrPatch:
        //                {
        //                    return await createFinalResponseAsync(response, c);
        //                }
        //            default:
        //                throw await clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
        //        }
        //    });
        //}

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

        internal static Operation<T> Create<T>(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Response originalResponse, bool isPutOrPatch, string scopeName, FinalStateVia finalStateVia,
            Func<HttpMessage> createOriginalHttpMessage, Func<Response, CancellationToken, Response<T>> createFinalResponse, Func<Response, CancellationToken, ValueTask<Response<T>>> createFinalResponseAsync) where T : notnull
        {
            using HttpMessage originalHttpMethod = createOriginalHttpMessage();
            string originalUri = originalHttpMethod.Request.Uri.ToString();
            ScenarioInfo originalInfo = GetScenarioInfo(originalResponse, originalUri);
            if ((!isPutOrPatch && (originalInfo.HeaderFrom == HeaderFrom.None || originalInfo.HeaderFrom != HeaderFrom.Location)) || finalStateVia == FinalStateVia.AzureAsyncOperation)
            {
                throw clientDiagnostics.CreateRequestFailedException(originalResponse);
            }

            return new ArmOperation<T>(pipeline, clientDiagnostics, originalResponse, isPutOrPatch, scopeName, finalStateVia, createFinalResponse, createFinalResponseAsync, originalInfo);
        }

        private class ArmOperation<T> : Operation<T> where T : notnull
        {
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly bool _isPutOrPatch;
            private readonly string _scopeName;
            private readonly FinalStateVia _finalStateVia;
            private readonly Func<Response, CancellationToken, Response<T>> _createFinalResponse;
            private readonly Func<Response, CancellationToken, ValueTask<Response<T>>> _createFinalResponseAsync;
            private readonly ScenarioInfo _originalInfo;

            private Response _rawResponse;
            private T _value = default!;
            private bool _hasValue;
            private bool _hasCompleted;
            private bool _shouldPoll;

            public ArmOperation(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Response originalResponse, bool isPutOrPatch, string scopeName, FinalStateVia finalStateVia,
                Func<Response, CancellationToken, Response<T>> createFinalResponse, Func<Response, CancellationToken, ValueTask<Response<T>>> createFinalResponseAsync, ScenarioInfo originalInfo)
            {
                _rawResponse = originalResponse;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _isPutOrPatch = isPutOrPatch;
                _scopeName = scopeName;
                _finalStateVia = finalStateVia;
                _createFinalResponse = createFinalResponse;
                _createFinalResponseAsync = createFinalResponseAsync;
                _originalInfo = originalInfo;
            }

            public override Response GetRawResponse() => _rawResponse;

            public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
                this.DefaultWaitForCompletionAsync(OperationHelpers.DefaultPollingInterval, cancellationToken);

            public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

            private CompletionInfo CheckCompletion()
            {
                ScenarioInfo info = GetScenarioInfo(GetRawResponse(), _originalInfo.OriginalUri);
                return IsTerminalState(GetRawResponse(), info);
            }

            private string GetFinalUri()
            {
                if (_isPutOrPatch || _finalStateVia == FinalStateVia.OriginalUri)
                {
                    return _originalInfo.OriginalUri;
                }

                if (_finalStateVia == FinalStateVia.Location)
                {
                    return _originalInfo.OriginalLocation!;
                }

                throw _clientDiagnostics.CreateRequestFailedException(GetRawResponse());
            }

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (_shouldPoll)
                {
                    ScenarioInfo pollInfo = GetScenarioInfo(GetRawResponse(), _originalInfo.OriginalUri);
                    _rawResponse = await GetResponseAsync(_pipeline, _clientDiagnostics, _scopeName, pollInfo.PollUri, cancellationToken).ConfigureAwait(false);
                }
                _shouldPoll = true;
                CompletionInfo completionInfo = CheckCompletion();
                _hasCompleted = completionInfo.HasCompleted;
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (completionInfo.HasFinalGet)
                    {
                        finalResponse = await GetResponseAsync(_pipeline, _clientDiagnostics, _scopeName, GetFinalUri(), cancellationToken).ConfigureAwait(false);
                    }
                    switch (finalResponse.Status)
                    {
                        case 200:
                        case 204 when !_isPutOrPatch:
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
                    ScenarioInfo pollInfo = GetScenarioInfo(GetRawResponse(), _originalInfo.OriginalUri);
                    _rawResponse = GetResponse(_pipeline, _clientDiagnostics, _scopeName, pollInfo.PollUri, cancellationToken);
                }
                _shouldPoll = true;
                CompletionInfo completionInfo = CheckCompletion();
                _hasCompleted = completionInfo.HasCompleted;
                if (HasCompleted)
                {
                    Response finalResponse = GetRawResponse();
                    if (completionInfo.HasFinalGet)
                    {
                        finalResponse = GetResponse(_pipeline, _clientDiagnostics, _scopeName, GetFinalUri(), cancellationToken);
                    }
                    switch (finalResponse.Status)
                    {
                        case 200:
                        case 204 when !_isPutOrPatch:
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

            //public override Response UpdateStatus(CancellationToken cancellationToken = default)
            //{
            //    if (HasCompleted)
            //    {
            //        return GetRawResponse();
            //    }

            //    Response response = _shouldPoll ? _pollingFunc(GetRawResponse(), cancellationToken) : GetRawResponse();
            //    _rawResponse = response;
            //    _shouldPoll = true;
            //    _hasCompleted = _completionPredicate(GetRawResponse());
            //    if (HasCompleted)
            //    {
            //        Response<T> finalResponse = _finalFunc(GetRawResponse(), cancellationToken);
            //        _rawResponse = finalResponse.GetRawResponse();
            //        _value = finalResponse.Value;
            //        _hasValue = true;
            //        return GetRawResponse();
            //    }

            //    return GetRawResponse();
            //}

            //TODO: This is currently not used.
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
            public ScenarioInfo(string originalUri, HeaderFrom headerFrom, string pollUri, string? originalLocation)
            {
                OriginalUri = originalUri;
                HeaderFrom = headerFrom;
                PollUri = pollUri;
                OriginalLocation = originalLocation;
            }

            public string OriginalUri { get; }
            public HeaderFrom HeaderFrom { get; }
            public string PollUri { get; }
            public string? OriginalLocation { get; }
        }

        private static ScenarioInfo GetScenarioInfo(Response response, string originalUri)
        {
            bool hasLocation = response.Headers.TryGetValue("Location", out string? location);

            if (response.Headers.TryGetValue("Operation-Location", out string? operationLocation))
            {
                return new ScenarioInfo(originalUri, HeaderFrom.OperationLocation, operationLocation, location);
            }

            if (response.Headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation))
            {
                return new ScenarioInfo(originalUri, HeaderFrom.AzureAsyncOperation, azureAsyncOperation, location);
            }

            if (hasLocation)
            {
                return new ScenarioInfo(originalUri, HeaderFrom.Location, location!, location);
            }

            //if (response.Headers.Any(h => string.Equals(h.Name, "Azure-AsyncOperation", StringComparison.InvariantCultureIgnoreCase)))
            //{
            //    HttpHeader azureAsyncOperation = response.Headers.First(h => string.Equals(h.Name, "Azure-AsyncOperation", StringComparison.InvariantCultureIgnoreCase));
            //    return new ScenarioInfo(HeaderFrom.AzureAsyncOperation, azureAsyncOperation.Value);
            //}

            //if (response.Headers.Any(h => string.Equals(h.Name, "Location", StringComparison.InvariantCultureIgnoreCase)))
            //{
            //    HttpHeader location = response.Headers.First(h => string.Equals(h.Name, "Location", StringComparison.InvariantCultureIgnoreCase));
            //    return new ScenarioInfo(HeaderFrom.Location, location.Value);
            //}

            return new ScenarioInfo(originalUri, HeaderFrom.None, originalUri, location);
        }

        private class CompletionInfo
        {
            public bool HasCompleted { get; set; }
            public bool HasFinalGet { get; set; }
        }

        private static readonly string[] _terminalStates = { "Succeeded", "Failed", "Canceled" };

        private static CompletionInfo IsTerminalState(Response response, ScenarioInfo info)
        {
            CompletionInfo completion = new CompletionInfo();
            try
            {
                using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    if ((info.HeaderFrom == HeaderFrom.OperationLocation || info.HeaderFrom == HeaderFrom.AzureAsyncOperation) &&
                        property.NameEquals("status"))
                    {
                        completion.HasCompleted = _terminalStates.Contains(property.Value.GetString());
                        completion.HasFinalGet = true;
                        return completion;
                    }

                    if ((info.HeaderFrom == HeaderFrom.Location || info.HeaderFrom == HeaderFrom.None) &&
                        property.NameEquals("properties"))
                    {
                        foreach (var innerProperty in property.Value.EnumerateObject())
                        {
                            if (innerProperty.NameEquals("provisioningState"))
                            {
                                completion.HasCompleted = _terminalStates.Contains(innerProperty.Value.GetString());
                                return completion;
                            }
                        }
                    }
                }
            }
            catch
            {
                // Could not parse JsonDocument. Continue.
            }

            if (info.HeaderFrom == HeaderFrom.None)
            {
                completion.HasCompleted = response.Status == 200;
                return completion;
            }

            return completion;
        }
    }
}
