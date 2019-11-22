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
    public static class PrimitiveOperations
    {
        public static async ValueTask<Response<IntWrapper>> GetIntAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetInt");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/integer"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(IntWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutIntAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IntWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutInt");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/integer"));
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

        public static async ValueTask<Response<LongWrapper>> GetLongAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetLong");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/long"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(LongWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutLongAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, LongWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutLong");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/long"));
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

        public static async ValueTask<Response<FloatWrapper>> GetFloatAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetFloat");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/float"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(FloatWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutFloatAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, FloatWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutFloat");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/float"));
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

        public static async ValueTask<Response<DoubleWrapper>> GetDoubleAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetDouble");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/double"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(DoubleWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutDoubleAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, DoubleWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutDouble");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/double"));
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

        public static async ValueTask<Response<BooleanWrapper>> GetBoolAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetBool");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/bool"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(BooleanWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutBoolAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, BooleanWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutBool");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/bool"));
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

        public static async ValueTask<Response<StringWrapper>> GetStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/string"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(StringWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, StringWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/string"));
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

        public static async ValueTask<Response<DateWrapper>> GetDateAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetDate");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/date"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(DateWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutDateAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, DateWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutDate");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/date"));
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

        public static async ValueTask<Response<DatetimeWrapper>> GetDateTimeAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetDateTime");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/datetime"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(DatetimeWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutDateTimeAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, DatetimeWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutDateTime");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/datetime"));
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

        public static async ValueTask<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetDateTimeRfc1123");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/datetimerfc1123"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(Datetimerfc1123Wrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutDateTimeRfc1123Async(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Datetimerfc1123Wrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutDateTimeRfc1123");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/datetimerfc1123"));
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

        public static async ValueTask<Response<DurationWrapper>> GetDurationAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetDuration");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/duration"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(DurationWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutDurationAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, DurationWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutDuration");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/duration"));
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

        public static async ValueTask<Response<ByteWrapper>> GetByteAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.GetByte");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/byte"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return Response.FromValue(ByteWrapper.Deserialize(document.RootElement), response);
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

        public static async ValueTask<Response> PutByteAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, ByteWrapper complexBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BodyComplex.Operations.V20160229.PutByte");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}/complex/primitive/byte"));
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
    }
}
