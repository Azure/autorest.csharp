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
    public static class PrimitiveOperations
    {
        public static async ValueTask<Response<IntWrapper>> GetIntAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetInt");
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
                return Response.FromValue(IntWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutIntAsync(Uri uri, HttpPipeline pipeline, IntWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutInt");
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

        public static async ValueTask<Response<LongWrapper>> GetLongAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetLong");
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
                return Response.FromValue(LongWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutLongAsync(Uri uri, HttpPipeline pipeline, LongWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutLong");
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

        public static async ValueTask<Response<FloatWrapper>> GetFloatAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetFloat");
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
                return Response.FromValue(FloatWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutFloatAsync(Uri uri, HttpPipeline pipeline, FloatWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutFloat");
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

        public static async ValueTask<Response<DoubleWrapper>> GetDoubleAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetDouble");
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
                return Response.FromValue(DoubleWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutDoubleAsync(Uri uri, HttpPipeline pipeline, DoubleWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutDouble");
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

        public static async ValueTask<Response<BooleanWrapper>> GetBoolAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetBool");
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
                return Response.FromValue(BooleanWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutBoolAsync(Uri uri, HttpPipeline pipeline, BooleanWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutBool");
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

        public static async ValueTask<Response<StringWrapper>> GetStringAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetString");
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
                return Response.FromValue(StringWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutStringAsync(Uri uri, HttpPipeline pipeline, StringWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutString");
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

        public static async ValueTask<Response<DateWrapper>> GetDateAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetDate");
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
                return Response.FromValue(DateWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutDateAsync(Uri uri, HttpPipeline pipeline, DateWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutDate");
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

        public static async ValueTask<Response<DatetimeWrapper>> GetDateTimeAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetDateTime");
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
                return Response.FromValue(DatetimeWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutDateTimeAsync(Uri uri, HttpPipeline pipeline, DatetimeWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutDateTime");
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

        public static async ValueTask<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetDateTimeRfc1123");
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
                return Response.FromValue(Datetimerfc1123Wrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutDateTimeRfc1123Async(Uri uri, HttpPipeline pipeline, Datetimerfc1123Wrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutDateTimeRfc1123");
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

        public static async ValueTask<Response<DurationWrapper>> GetDurationAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetDuration");
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
                return Response.FromValue(DurationWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutDurationAsync(Uri uri, HttpPipeline pipeline, DurationWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutDuration");
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

        public static async ValueTask<Response<ByteWrapper>> GetByteAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetByte");
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
                return Response.FromValue(ByteWrapper.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }

        public static async ValueTask<Response<string>> PutByteAsync(Uri uri, HttpPipeline pipeline, ByteWrapper? complexBody = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.PutByte");
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
    }
}
