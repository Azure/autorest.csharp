// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using additionalProperties.Models.V100;
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
        internal HttpMessage CreateCreateAPTrueRequest(PetAPTrue createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/true", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<PetAPTrue>> CreateAPTrueAsync(PetAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateAPTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateAPTrueRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPTrue.DeserializePetAPTrue(document.RootElement);
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
        internal HttpMessage CreateCreateCatAPTrueRequest(CatAPTrue createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/true-subclass", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<CatAPTrue>> CreateCatAPTrueAsync(CatAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateCatAPTrue");
            scope.Start();
            try
            {
                using var message = CreateCreateCatAPTrueRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = CatAPTrue.DeserializeCatAPTrue(document.RootElement);
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
        internal HttpMessage CreateCreateAPObjectRequest(PetAPObject createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/type/object", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<PetAPObject>> CreateAPObjectAsync(PetAPObject createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateAPObject");
            scope.Start();
            try
            {
                using var message = CreateCreateAPObjectRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPObject.DeserializePetAPObject(document.RootElement);
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
        internal HttpMessage CreateCreateAPStringRequest(PetAPString createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/type/string", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<PetAPString>> CreateAPStringAsync(PetAPString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateAPString");
            scope.Start();
            try
            {
                using var message = CreateCreateAPStringRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPString.DeserializePetAPString(document.RootElement);
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
        internal HttpMessage CreateCreateAPInPropertiesRequest(PetAPInProperties createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/in/properties", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<PetAPInProperties>> CreateAPInPropertiesAsync(PetAPInProperties createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateAPInProperties");
            scope.Start();
            try
            {
                using var message = CreateCreateAPInPropertiesRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPInProperties.DeserializePetAPInProperties(document.RootElement);
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
        internal HttpMessage CreateCreateAPInPropertiesWithAPStringRequest(PetAPInPropertiesWithAPString createParameters)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/additionalProperties/in/properties/with/additionalProperties/string", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(createParameters);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response<PetAPInPropertiesWithAPString>> CreateAPInPropertiesWithAPStringAsync(PetAPInPropertiesWithAPString createParameters, CancellationToken cancellationToken = default)
        {
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("PetsOperations.CreateAPInPropertiesWithAPString");
            scope.Start();
            try
            {
                using var message = CreateCreateAPInPropertiesWithAPStringRequest(createParameters);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPInPropertiesWithAPString.DeserializePetAPInPropertiesWithAPString(document.RootElement);
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
    }
}
