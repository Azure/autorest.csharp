// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_string.Models.V100;

namespace body_string
{
    internal partial class EnumOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of EnumOperations. </summary>
        public EnumOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetNotExpandableRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Colors>> GetNotExpandableAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetNotExpandable");
            scope.Start();
            try
            {
                using var message = CreateGetNotExpandableRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString().ToColors();
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
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetNotExpandable(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetNotExpandable");
            scope.Start();
            try
            {
                using var message = CreateGetNotExpandableRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetString().ToColors();
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
        internal HttpMessage CreatePutNotExpandableRequest(Colors stringBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(stringBody.ToSerialString());
            request.Content = content;
            return message;
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="stringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutNotExpandableAsync(Colors stringBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutNotExpandable");
            scope.Start();
            try
            {
                using var message = CreatePutNotExpandableRequest(stringBody);
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
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="stringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNotExpandable(Colors stringBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutNotExpandable");
            scope.Start();
            try
            {
                using var message = CreatePutNotExpandableRequest(stringBody);
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
        internal HttpMessage CreateGetReferencedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Colors>> GetReferencedAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetReferenced");
            scope.Start();
            try
            {
                using var message = CreateGetReferencedRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString().ToColors();
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
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetReferenced(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetReferenced");
            scope.Start();
            try
            {
                using var message = CreateGetReferencedRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetString().ToColors();
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
        internal HttpMessage CreatePutReferencedRequest(Colors enumStringBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(enumStringBody.ToSerialString());
            request.Content = content;
            return message;
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="enumStringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutReferencedAsync(Colors enumStringBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutReferenced");
            scope.Start();
            try
            {
                using var message = CreatePutReferencedRequest(enumStringBody);
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
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="enumStringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutReferenced(Colors enumStringBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutReferenced");
            scope.Start();
            try
            {
                using var message = CreatePutReferencedRequest(enumStringBody);
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
        internal HttpMessage CreateGetReferencedConstantRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RefColorConstant>> GetReferencedConstantAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetReferencedConstant");
            scope.Start();
            try
            {
                using var message = CreateGetReferencedConstantRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = RefColorConstant.DeserializeRefColorConstant(document.RootElement);
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
        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RefColorConstant> GetReferencedConstant(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("EnumOperations.GetReferencedConstant");
            scope.Start();
            try
            {
                using var message = CreateGetReferencedConstantRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = RefColorConstant.DeserializeRefColorConstant(document.RootElement);
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
        internal HttpMessage CreatePutReferencedConstantRequest(RefColorConstant enumStringBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(enumStringBody);
            request.Content = content;
            return message;
        }
        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="enumStringBody"> The RefColorConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutReferencedConstantAsync(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            if (enumStringBody == null)
            {
                throw new ArgumentNullException(nameof(enumStringBody));
            }

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutReferencedConstant");
            scope.Start();
            try
            {
                using var message = CreatePutReferencedConstantRequest(enumStringBody);
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
        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="enumStringBody"> The RefColorConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutReferencedConstant(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            if (enumStringBody == null)
            {
                throw new ArgumentNullException(nameof(enumStringBody));
            }

            using var scope = clientDiagnostics.CreateScope("EnumOperations.PutReferencedConstant");
            scope.Start();
            try
            {
                using var message = CreatePutReferencedConstantRequest(enumStringBody);
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
