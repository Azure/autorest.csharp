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
    internal static class PetsOperations
    {
        public static async ValueTask<Response<PetAPTrue>> CreateAPTrueAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, PetAPTrue createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateAPTrue");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/true", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                PetAPTrueSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPTrueSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<CatAPTrue>> CreateCatAPTrueAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, CatAPTrue createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateCatAPTrue");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/true-subclass", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                CatAPTrueSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = CatAPTrueSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<PetAPObject>> CreateAPObjectAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, PetAPObject createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateAPObject");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/type/object", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                PetAPObjectSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPObjectSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<PetAPString>> CreateAPStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, PetAPString createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateAPString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/type/string", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                PetAPStringSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPStringSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<PetAPInProperties>> CreateAPInPropertiesAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, PetAPInProperties createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateAPInProperties");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/in/properties", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                PetAPInPropertiesSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPInPropertiesSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<PetAPInPropertiesWithAPString>> CreateAPInPropertiesWithAPStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, PetAPInPropertiesWithAPString createParameters, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (createParameters == null)
            {
                throw new ArgumentNullException(nameof(createParameters));
            }

            using var scope = clientDiagnostics.CreateScope("additionalProperties.CreateAPInPropertiesWithAPString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/additionalProperties/in/properties/with/additionalProperties/string", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                PetAPInPropertiesWithAPStringSerializer.Serialize(createParameters, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = PetAPInPropertiesWithAPStringSerializer.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
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
