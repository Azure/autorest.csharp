// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    internal partial class PrimitiveOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PrimitiveOperations. </summary>
        public PrimitiveOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetIntRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/integer", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IntWrapper>> GetIntAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetInt");
            scope.Start();
            try
            {
                using var message = CreateGetIntRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = IntWrapper.DeserializeIntWrapper(document.RootElement);
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
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IntWrapper> GetInt(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetInt");
            scope.Start();
            try
            {
                using var message = CreateGetIntRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = IntWrapper.DeserializeIntWrapper(document.RootElement);
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
        internal HttpMessage CreatePutIntRequest(IntWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/integer", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntAsync(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutInt");
            scope.Start();
            try
            {
                using var message = CreatePutIntRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutInt(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutInt");
            scope.Start();
            try
            {
                using var message = CreatePutIntRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetLongRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/long", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<LongWrapper>> GetLongAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetLong");
            scope.Start();
            try
            {
                using var message = CreateGetLongRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = LongWrapper.DeserializeLongWrapper(document.RootElement);
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
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<LongWrapper> GetLong(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetLong");
            scope.Start();
            try
            {
                using var message = CreateGetLongRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = LongWrapper.DeserializeLongWrapper(document.RootElement);
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
        internal HttpMessage CreatePutLongRequest(LongWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/long", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongAsync(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutLong");
            scope.Start();
            try
            {
                using var message = CreatePutLongRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLong(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutLong");
            scope.Start();
            try
            {
                using var message = CreatePutLongRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetFloatRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/float", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<FloatWrapper>> GetFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetFloat");
            scope.Start();
            try
            {
                using var message = CreateGetFloatRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = FloatWrapper.DeserializeFloatWrapper(document.RootElement);
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
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<FloatWrapper> GetFloat(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetFloat");
            scope.Start();
            try
            {
                using var message = CreateGetFloatRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = FloatWrapper.DeserializeFloatWrapper(document.RootElement);
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
        internal HttpMessage CreatePutFloatRequest(FloatWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/float", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatAsync(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutFloat");
            scope.Start();
            try
            {
                using var message = CreatePutFloatRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloat(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutFloat");
            scope.Start();
            try
            {
                using var message = CreatePutFloatRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetDoubleRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/double", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DoubleWrapper>> GetDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDouble");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DoubleWrapper.DeserializeDoubleWrapper(document.RootElement);
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
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DoubleWrapper> GetDouble(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDouble");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = DoubleWrapper.DeserializeDoubleWrapper(document.RootElement);
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
        internal HttpMessage CreatePutDoubleRequest(DoubleWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/double", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleAsync(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDouble");
            scope.Start();
            try
            {
                using var message = CreatePutDoubleRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDouble(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDouble");
            scope.Start();
            try
            {
                using var message = CreatePutDoubleRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetBoolRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/bool", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<BooleanWrapper>> GetBoolAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetBool");
            scope.Start();
            try
            {
                using var message = CreateGetBoolRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = BooleanWrapper.DeserializeBooleanWrapper(document.RootElement);
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
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<BooleanWrapper> GetBool(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetBool");
            scope.Start();
            try
            {
                using var message = CreateGetBoolRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = BooleanWrapper.DeserializeBooleanWrapper(document.RootElement);
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
        internal HttpMessage CreatePutBoolRequest(BooleanWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/bool", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBoolAsync(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutBool");
            scope.Start();
            try
            {
                using var message = CreatePutBoolRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBool(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutBool");
            scope.Start();
            try
            {
                using var message = CreatePutBoolRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/string", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<StringWrapper>> GetStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetString");
            scope.Start();
            try
            {
                using var message = CreateGetStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = StringWrapper.DeserializeStringWrapper(document.RootElement);
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
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StringWrapper> GetString(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetString");
            scope.Start();
            try
            {
                using var message = CreateGetStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = StringWrapper.DeserializeStringWrapper(document.RootElement);
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
        internal HttpMessage CreatePutStringRequest(StringWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/string", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringAsync(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutString");
            scope.Start();
            try
            {
                using var message = CreatePutStringRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutString(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutString");
            scope.Start();
            try
            {
                using var message = CreatePutStringRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/date", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateWrapper>> GetDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDate");
            scope.Start();
            try
            {
                using var message = CreateGetDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DateWrapper.DeserializeDateWrapper(document.RootElement);
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
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateWrapper> GetDate(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDate");
            scope.Start();
            try
            {
                using var message = CreateGetDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = DateWrapper.DeserializeDateWrapper(document.RootElement);
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
        internal HttpMessage CreatePutDateRequest(DateWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/date", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateAsync(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDate");
            scope.Start();
            try
            {
                using var message = CreatePutDateRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDate(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDate");
            scope.Start();
            try
            {
                using var message = CreatePutDateRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/datetime", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DatetimeWrapper>> GetDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DatetimeWrapper.DeserializeDatetimeWrapper(document.RootElement);
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
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DatetimeWrapper> GetDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = DatetimeWrapper.DeserializeDatetimeWrapper(document.RootElement);
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
        internal HttpMessage CreatePutDateTimeRequest(DatetimeWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/datetime", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeAsync(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTime(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetDateTimeRfc1123Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/datetimerfc1123", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDateTimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRfc1123Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Datetimerfc1123Wrapper.DeserializeDatetimerfc1123Wrapper(document.RootElement);
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
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Datetimerfc1123Wrapper> GetDateTimeRfc1123(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDateTimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRfc1123Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Datetimerfc1123Wrapper.DeserializeDatetimerfc1123Wrapper(document.RootElement);
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
        internal HttpMessage CreatePutDateTimeRfc1123Request(Datetimerfc1123Wrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123Async(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDateTimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRfc1123Request(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDateTimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRfc1123Request(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetDurationRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/duration", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DurationWrapper>> GetDurationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDuration");
            scope.Start();
            try
            {
                using var message = CreateGetDurationRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DurationWrapper.DeserializeDurationWrapper(document.RootElement);
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
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DurationWrapper> GetDuration(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetDuration");
            scope.Start();
            try
            {
                using var message = CreateGetDurationRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = DurationWrapper.DeserializeDurationWrapper(document.RootElement);
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
        internal HttpMessage CreatePutDurationRequest(DurationWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/duration", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationAsync(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDuration");
            scope.Start();
            try
            {
                using var message = CreatePutDurationRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDuration(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutDuration");
            scope.Start();
            try
            {
                using var message = CreatePutDurationRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        internal HttpMessage CreateGetByteRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/byte", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ByteWrapper>> GetByteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetByte");
            scope.Start();
            try
            {
                using var message = CreateGetByteRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ByteWrapper.DeserializeByteWrapper(document.RootElement);
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
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ByteWrapper> GetByte(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.GetByte");
            scope.Start();
            try
            {
                using var message = CreateGetByteRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ByteWrapper.DeserializeByteWrapper(document.RootElement);
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
        internal HttpMessage CreatePutByteRequest(ByteWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/primitive/byte", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteAsync(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutByte");
            scope.Start();
            try
            {
                using var message = CreatePutByteRequest(complexBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByte(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("PrimitiveOperations.PutByte");
            scope.Start();
            try
            {
                using var message = CreatePutByteRequest(complexBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
