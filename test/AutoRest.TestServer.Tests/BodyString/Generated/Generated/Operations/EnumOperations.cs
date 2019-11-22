// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BodyString.Models.V100;

namespace BodyString.Operations.V100
{
    public static class EnumOperations
    {
        public static async ValueTask<Response<Colors>> GetNotExpandableAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetNotExpandable");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/enum/notExpandable"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(new Colors(document.RootElement.GetString()), response);
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
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutNotExpandable");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/enum/notExpandable"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteString("stringBody", stringBody.ToString());
                writer.Flush();
                request.Content = RequestContent.Create(buffer.WrittenMemory);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<Colors>> GetReferencedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetReferenced");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/enum/Referenced"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(new Colors(document.RootElement.GetString()), response);
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
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutReferenced");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/enum/Referenced"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteString("enumStringBody", enumStringBody.ToString());
                writer.Flush();
                request.Content = RequestContent.Create(buffer.WrittenMemory);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<RefColorConstant>> GetReferencedConstantAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetReferencedConstant");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/enum/ReferencedConstant"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(RefColorConstant.Deserialize(document.RootElement), response);
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
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutReferencedConstant");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/enum/ReferencedConstant"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                enumStringBody.Serialize(writer, false);
                writer.Flush();
                request.Content = RequestContent.Create(buffer.WrittenMemory);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
