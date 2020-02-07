// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    internal partial class InheritanceOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of InheritanceOperations. </summary>
        public InheritanceOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/inheritance/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Siamese>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("InheritanceOperations.GetValid");
            scope.Start();
            try
            {
                using var message = CreateGetValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Siamese.DeserializeSiamese(document.RootElement);
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
        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Siamese> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("InheritanceOperations.GetValid");
            scope.Start();
            try
            {
                using var message = CreateGetValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Siamese.DeserializeSiamese(document.RootElement);
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
        internal HttpMessage CreatePutValidRequest(Siamese complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/inheritance/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name=&quot;Siameee&quot;, color=green, breed=persion, which hates 2 dogs, the 1st one named &quot;Potato&quot; with id=1 and food=&quot;tomato&quot;, and the 2nd one named &quot;Tomato&quot; with id=-1 and food=&quot;french fries&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("InheritanceOperations.PutValid");
            scope.Start();
            try
            {
                using var message = CreatePutValidRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name=&quot;Siameee&quot;, color=green, breed=persion, which hates 2 dogs, the 1st one named &quot;Potato&quot; with id=1 and food=&quot;tomato&quot;, and the 2nd one named &quot;Tomato&quot; with id=-1 and food=&quot;french fries&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("InheritanceOperations.PutValid");
            scope.Start();
            try
            {
                using var message = CreatePutValidRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
