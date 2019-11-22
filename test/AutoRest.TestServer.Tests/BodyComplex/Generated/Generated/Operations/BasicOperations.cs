// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BodyComplex.Models.V20160229;

namespace BodyComplex.Operations.V20160229
{
    public static class BasicOperations
    {
        public static async ValueTask<Response<Basic>> GetValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/basic/valid"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Basic.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Basic complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/basic/valid"));
                request.Uri.AppendQuery("api-version", "2016-02-29".ToString()!);
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                complexBody.Serialize(writer, false);
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

        public static async ValueTask<Response<Basic>> GetInvalidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetInvalid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/basic/invalid"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Basic.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response<Basic>> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/basic/empty"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Basic.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response<Basic>> GetNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/basic/null"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Basic.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response<Basic>> GetNotProvidedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetNotProvided");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/basic/notprovided"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Basic.Deserialize(document.RootElement), response);
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
