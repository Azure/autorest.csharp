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
    internal static class EnumOperations
    {
        public static async ValueTask<Response<Colors>> GetNotExpandableAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.GetNotExpandable");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/notExpandable", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString().ToColors();
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
        public static async ValueTask<Response> PutNotExpandableAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Colors stringBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.PutNotExpandable");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/notExpandable", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                writer.WriteStringValue(stringBody.ToSerialString());
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return response;
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
        public static async ValueTask<Response<Colors>> GetReferencedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.GetReferenced");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/Referenced", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetString().ToColors();
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
        public static async ValueTask<Response> PutReferencedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Colors enumStringBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.PutReferenced");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/Referenced", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                writer.WriteStringValue(enumStringBody.ToSerialString());
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return response;
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
        public static async ValueTask<Response<RefColorConstant>> GetReferencedConstantAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.GetReferencedConstant");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/ReferencedConstant", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = RefColorConstantSerializer.Deserialize(document.RootElement);
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
        public static async ValueTask<Response> PutReferencedConstantAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, RefColorConstant enumStringBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (enumStringBody == null)
            {
                throw new ArgumentNullException(nameof(enumStringBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_string.PutReferencedConstant");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/string/enum/ReferencedConstant", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                RefColorConstantSerializer.Serialize(enumStringBody, writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return response;
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
