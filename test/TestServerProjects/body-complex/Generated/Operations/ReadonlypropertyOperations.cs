// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_complex.Models.V20160229;

namespace body_complex
{
    internal partial class ReadonlypropertyOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ReadonlypropertyOperations. </summary>
        public ReadonlypropertyOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/readonlyproperty/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ReadonlyObj>> GetValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ReadonlypropertyOperations.GetValid");
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
                            var value = ReadonlyObj.DeserializeReadonlyObj(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ReadonlyObj> GetValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ReadonlypropertyOperations.GetValid");
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
                            var value = ReadonlyObj.DeserializeReadonlyObj(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutValidRequest(ReadonlyObj complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/readonlyproperty/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The readonly-obj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ReadonlypropertyOperations.PutValid");
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The readonly-obj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ReadonlypropertyOperations.PutValid");
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
                        throw message.Response.CreateRequestFailedException();
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
