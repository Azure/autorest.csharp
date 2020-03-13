// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using media_types.Models;

namespace media_types
{
    internal partial class ServiceRestClient
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ServiceRestClient. </summary>
        public ServiceRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateAnalyzeBodyRequest(ContentType? contentType, Stream input)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/mediatypes/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/pdf");
            request.Headers.Add("Content-Type", "image/jpeg");
            request.Headers.Add("Content-Type", "image/png");
            request.Headers.Add("Content-Type", "image/tiff");
            request.Content = RequestContent.Create(input);
            return message;
        }
        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="input"> Input parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> AnalyzeBodyAsync(ContentType? contentType, Stream input, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceClient.AnalyzeBody");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeBodyRequest(contentType, input);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString();
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
        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="input"> Input parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> AnalyzeBody(ContentType? contentType, Stream input, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceClient.AnalyzeBody");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeBodyRequest(contentType, input);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetString();
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
        internal HttpMessage CreateAnalyzeBodyRequest(SourcePath input)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/mediatypes/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="input"> Input parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> AnalyzeBodyAsync(SourcePath input, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceClient.AnalyzeBody");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeBodyRequest(input);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString();
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
        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="input"> Input parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> AnalyzeBody(SourcePath input, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceClient.AnalyzeBody");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeBodyRequest(input);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetString();
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
