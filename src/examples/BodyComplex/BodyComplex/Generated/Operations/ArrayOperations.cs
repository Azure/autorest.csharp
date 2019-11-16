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

namespace BodyComplex.Operations
{
    public static class ArrayOperations
    {
        public static async ValueTask<Response<ArrayWrapper>> GetValidAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetValid");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(uri);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(ArrayWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutValidAsync(Uri uri, HttpPipeline pipeline, ArrayWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutValid");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(uri);
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                complexBody?.Serialize(writer);
                writer.Flush();
                request.Content = RequestContent.Create(buffer.WrittenMemory);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return Response.FromValue(string.Empty, response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<ArrayWrapper>> GetEmptyAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetEmpty");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(uri);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(ArrayWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutEmptyAsync(Uri uri, HttpPipeline pipeline, ArrayWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutEmpty");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(uri);
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                complexBody?.Serialize(writer);
                writer.Flush();
                request.Content = RequestContent.Create(buffer.WrittenMemory);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return Response.FromValue(string.Empty, response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<ArrayWrapper>> GetNotProvidedAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetNotProvided");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(uri);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(ArrayWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }
    }
}
