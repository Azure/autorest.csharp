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
    internal static class ArmOperationHelpers
    {
        public static async ValueTask<Operation<T>> CreateAsync<T>(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics,
            Response originalResponse, bool isPutOrPatch, string scopeName, Func<HttpMessage> createOriginalHttpMethod, Func<Response, ValueTask<Response<T>>> createFinalResponse) where T : notnull
        {
            using HttpMessage originalHttpMethod = createOriginalHttpMethod();
            string originalUri = originalHttpMethod.Request.Uri.ToString();
            ScenarioInfo originalInfo = GetScenarioInfo(originalResponse, originalUri);
            if (!isPutOrPatch && (originalInfo.HeaderFrom == HeaderFrom.None || originalInfo.HeaderFrom != HeaderFrom.Location))
            {
                throw await clientDiagnostics.CreateRequestFailedExceptionAsync(originalResponse).ConfigureAwait(false);
            }

            return OperationFactory.CreateAsync(originalResponse, async (r, c) =>
            {
                ScenarioInfo info = GetScenarioInfo(r, originalUri);
                return await GetResponseAsync(pipeline, clientDiagnostics, scopeName, info.PollUri, c).ConfigureAwait(false);
            }, r =>
            {
                ScenarioInfo info = GetScenarioInfo(r, originalUri);
                return new ValueTask<bool>(IsTerminalState(r, info));
            }, async (r, c) =>
            {
                string finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
                Response response = await GetResponseAsync(pipeline, clientDiagnostics, scopeName, finalUri, c).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                    case 204 when !isPutOrPatch:
                    {
                        return await createFinalResponse(response);
                    }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            });
        }

        public static Operation<T> Create<T>(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics,
            Response originalResponse, bool isPutOrPatch, string scopeName, Func<HttpMessage> createOriginalHttpMethod, Func<Response, Response<T>> createFinalResponse) where T : notnull
        {
            using HttpMessage originalHttpMethod = createOriginalHttpMethod();
            string originalUri = originalHttpMethod.Request.Uri.ToString();
            ScenarioInfo originalInfo = GetScenarioInfo(originalResponse, originalUri);
            if (!isPutOrPatch && (originalInfo.HeaderFrom == HeaderFrom.None || originalInfo.HeaderFrom != HeaderFrom.Location))
            {
                throw clientDiagnostics.CreateRequestFailedException(originalResponse);
            }

            return OperationFactory.Create(originalResponse, (r, c) =>
            {
                ScenarioInfo info = GetScenarioInfo(r, originalUri);
                return GetResponse(pipeline, clientDiagnostics, scopeName, info.PollUri, c);
            }, r =>
            {
                ScenarioInfo info = GetScenarioInfo(r, originalUri);
                return IsTerminalState(r, info);
            }, (r, c) =>
            {
                string finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
                Response response = GetResponse(pipeline, clientDiagnostics, scopeName, finalUri, c);
                switch (response.Status)
                {
                    case 200:
                    case 204 when !isPutOrPatch:
                        {
                            return createFinalResponse(response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(response);
                }
            });
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
            AzureAsyncOperation,
            Location
        }

        private class ScenarioInfo
        {
            public ScenarioInfo(HeaderFrom headerFrom, string pollUri)
            {
                HeaderFrom = headerFrom;
                PollUri = pollUri;
            }

            public HeaderFrom HeaderFrom { get; }
            public string PollUri { get; }
        }

        private static ScenarioInfo GetScenarioInfo(Response response, string originalUri)
        {
            if (response.Headers.Any(h => string.Equals(h.Name, "Azure-AsyncOperation", StringComparison.InvariantCultureIgnoreCase)))
            {
                HttpHeader azureAsyncOperation = response.Headers.First(h => string.Equals(h.Name, "Azure-AsyncOperation", StringComparison.InvariantCultureIgnoreCase));
                return new ScenarioInfo(HeaderFrom.AzureAsyncOperation, azureAsyncOperation.Value);
            }

            if (response.Headers.Any(h => string.Equals(h.Name, "Location", StringComparison.InvariantCultureIgnoreCase)))
            {
                HttpHeader location = response.Headers.First(h => string.Equals(h.Name, "Location", StringComparison.InvariantCultureIgnoreCase));
                return new ScenarioInfo(HeaderFrom.Location, location.Value);
            }

            return new ScenarioInfo(HeaderFrom.None, originalUri);
        }

        private static readonly string[] TerminalStates = { "Succeeded", "Failed", "Canceled" };

        private static bool IsTerminalState(Response response, ScenarioInfo info)
        {
            try
            {
                using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    if (info.HeaderFrom == HeaderFrom.AzureAsyncOperation && property.NameEquals("status"))
                    {
                        return TerminalStates.Contains(property.Value.GetString());
                    }

                    if ((info.HeaderFrom == HeaderFrom.Location || info.HeaderFrom == HeaderFrom.None) &&
                        property.NameEquals("properties"))
                    {
                        foreach (var innerProperty in property.Value.EnumerateObject())
                        {
                            if (innerProperty.NameEquals("provisioningState"))
                            {
                                return TerminalStates.Contains(innerProperty.Value.GetString());
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
                return response.Status == 200;
            }

            return false;
        }
    }
}
