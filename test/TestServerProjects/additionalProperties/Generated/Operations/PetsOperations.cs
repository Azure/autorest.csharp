// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using additionalProperties.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace additionalProperties
{
    internal partial class PetsOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PetsOperations. </summary>
        public PetsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateCreateApTrueRequest(PetApTrue createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/true", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetApTrue>> CreateApTrueAsync(PetApTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateApTrueRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetApTrue.DeserializePetApTrue(document.RootElement);
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
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetApTrue> CreateApTrue(PetApTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateApTrueRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = PetApTrue.DeserializePetApTrue(document.RootElement);
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
        internal HttpMessage CreateCreateCatApTrueRequest(CatApTrue createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/true-subclass", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatApTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CatApTrue>> CreateCatApTrueAsync(CatApTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateCatApTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateCatApTrueRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = CatApTrue.DeserializeCatApTrue(document.RootElement);
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
        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatApTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CatApTrue> CreateCatApTrue(CatApTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateCatApTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateCatApTrueRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = CatApTrue.DeserializeCatApTrue(document.RootElement);
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
        internal HttpMessage CreateCreateApObjectRequest(PetApObject createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/type/object", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetApObject>> CreateApObjectAsync(PetApObject createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApObject");
            scope.Start();
            try
            {
                using var message = CreateCreateApObjectRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetApObject.DeserializePetApObject(document.RootElement);
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
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetApObject> CreateApObject(PetApObject createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApObject");
            scope.Start();
            try
            {
                using var message = CreateCreateApObjectRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = PetApObject.DeserializePetApObject(document.RootElement);
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
        internal HttpMessage CreateCreateApStringRequest(PetApString createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/type/string", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetApString>> CreateApStringAsync(PetApString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApString");
            scope.Start();
            try
            {
                using var message = CreateCreateApStringRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetApString.DeserializePetApString(document.RootElement);
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
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetApString> CreateApString(PetApString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApString");
            scope.Start();
            try
            {
                using var message = CreateCreateApStringRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = PetApString.DeserializePetApString(document.RootElement);
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
        internal HttpMessage CreateCreateApInPropertiesRequest(PetApInProperties createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/in/properties", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetApInProperties>> CreateApInPropertiesAsync(PetApInProperties createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApInProperties");
            scope.Start();
            try
            {
                using var message = CreateCreateApInPropertiesRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetApInProperties.DeserializePetApInProperties(document.RootElement);
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
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetApInProperties> CreateApInProperties(PetApInProperties createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApInProperties");
            scope.Start();
            try
            {
                using var message = CreateCreateApInPropertiesRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = PetApInProperties.DeserializePetApInProperties(document.RootElement);
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
        internal HttpMessage CreateCreateApInPropertiesWithApStringRequest(PetApInPropertiesWithApString createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/additionalProperties/in/properties/with/additionalProperties/string", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApInPropertiesWithApString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetApInPropertiesWithApString>> CreateApInPropertiesWithApStringAsync(PetApInPropertiesWithApString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApInPropertiesWithApString");
            scope.Start();
            try
            {
                using var message = CreateCreateApInPropertiesWithApStringRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetApInPropertiesWithApString.DeserializePetApInPropertiesWithApString(document.RootElement);
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
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetApInPropertiesWithApString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetApInPropertiesWithApString> CreateApInPropertiesWithApString(PetApInPropertiesWithApString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateApInPropertiesWithApString");
            scope.Start();
            try
            {
                using var message = CreateCreateApInPropertiesWithApStringRequest(createParameters);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = PetApInPropertiesWithApString.DeserializePetApInPropertiesWithApString(document.RootElement);
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
