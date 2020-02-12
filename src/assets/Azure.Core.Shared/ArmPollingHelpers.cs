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
    internal static class ArmPollingHelpers
    {
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

        public static async ValueTask<Response> GetResponseAsync(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, string link, CancellationToken cancellationToken = default)
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

        public static Response GetResponse(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, string link, CancellationToken cancellationToken = default)
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

        public enum HeaderFrom
        {
            None,
            AzureAsyncOperation,
            Location
        }

        public class ScenarioInfo
        {
            public ScenarioInfo(HeaderFrom headerFrom, string pollUri)
            {
                HeaderFrom = headerFrom;
                PollUri = pollUri;
            }

            public HeaderFrom HeaderFrom { get; set; }
            public string PollUri { get; set; }
        }

        public static ScenarioInfo GetScenarioInfo(Response response, string originalUri)
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

        public static bool IsTerminalState(Response response, ScenarioInfo info)
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
