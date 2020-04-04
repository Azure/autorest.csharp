// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using non_string_enum.Models;

namespace non_string_enum
{
    internal partial class IntRestClient
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;

        /// <summary> Initializes a new instance of IntRestClient. </summary>
        public IntRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        internal HttpMessage CreatePutRequest(IntEnum? input)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/nonStringEnums/int/put", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            if (input != null)
            {
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStringValue(input.Value.ToString());
                request.Content = content;
            }
            return message;
        }

        /// <summary> Put an int enum. </summary>
        /// <param name="input"> Input int enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> PutAsync(IntEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntClient.Put");
            scope.Start();
            try
            {
                using var message = CreatePutRequest(input);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            if (document.RootElement.ValueKind == JsonValueKind.Null)
                            {
                                value = null;
                            }
                            else
                            {
                                value = document.RootElement.GetString();
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an int enum. </summary>
        /// <param name="input"> Input int enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> Put(IntEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntClient.Put");
            scope.Start();
            try
            {
                using var message = CreatePutRequest(input);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            if (document.RootElement.ValueKind == JsonValueKind.Null)
                            {
                                value = null;
                            }
                            else
                            {
                                value = document.RootElement.GetString();
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/nonStringEnums/int/get", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Get an int enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IntEnum>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            IntEnum value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = new IntEnum(document.RootElement.GetInt32());
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an int enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IntEnum> Get(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            IntEnum value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = new IntEnum(document.RootElement.GetInt32());
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
