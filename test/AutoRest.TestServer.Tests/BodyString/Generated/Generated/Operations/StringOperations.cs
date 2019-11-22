// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace BodyString.Operations.V100
{
    public static class StringOperations
    {
        public static async ValueTask<Response<string>> GetNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/null"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetString(), response);
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

        public static async ValueTask<Response> PutNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/null"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteStringValue("");
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

        public static async ValueTask<Response<string>> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/empty"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetString(), response);
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

        public static async ValueTask<Response> PutEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/empty"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteStringValue("");
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

        public static async ValueTask<Response<string>> GetMbcsAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetMbcs");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/mbcs"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetString(), response);
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

        public static async ValueTask<Response> PutMbcsAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutMbcs");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/mbcs"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteStringValue("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€");
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

        public static async ValueTask<Response<string>> GetWhitespaceAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetWhitespace");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/whitespace"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetString(), response);
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

        public static async ValueTask<Response> PutWhitespaceAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutWhitespace");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/whitespace"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteStringValue("    Now is the time for all good men to come to the aid of their country    ");
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

        public static async ValueTask<Response<string>> GetNotProvidedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetNotProvided");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/notProvided"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetString(), response);
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

        public static async ValueTask<Response<byte[]>> GetBase64EncodedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetBase64Encoded");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/base64Encoding"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetBytesFromBase64(), response);
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

        public static async ValueTask<Response<byte[]>> GetBase64UrlEncodedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetBase64UrlEncoded");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/base64UrlEncoding"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetBytesFromBase64(), response);
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

        public static async ValueTask<Response> PutBase64UrlEncodedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, byte[] stringBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.PutBase64UrlEncoded");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/string/base64UrlEncoding"));
                request.Headers.SetValue("Content-Type", "application/json");
                var buffer = new ArrayBufferWriter<byte>();
                await using var writer = new Utf8JsonWriter(buffer);
                writer.WriteBase64String("stringBody", stringBody);
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

        public static async ValueTask<Response<byte[]>> GetNullBase64UrlEncodedAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyString.Operations.V100.GetNullBase64UrlEncoded");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/string/nullBase64UrlEncoding"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(document.RootElement.GetBytesFromBase64(), response);
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
