// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_array.Models.V100;

namespace body_array
{
    internal partial class ArrayOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ArrayOperations. </summary>
        public ArrayOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null array value. </summary>
        public async ValueTask<Response<ICollection<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/null", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Get invalid array [1, 2, 3. </summary>
        public async ValueTask<Response<ICollection<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetInvalid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/invalid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Get empty array value []. </summary>
        public async ValueTask<Response<ICollection<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/empty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Set array value empty []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/empty", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanTfft");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/tfft", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutBooleanTfft");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/tfft", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteBooleanValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get boolean array value [true, null, false]. </summary>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/true.null.false", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanInvalidString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/true.boolean.false", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        public async ValueTask<Response<ICollection<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntegerValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutIntegerValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteNumberValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get integer array value [1, null, 0]. </summary>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.null.zero", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntInvalidString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.integer.0", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        public async ValueTask<Response<ICollection<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.-1.3.300", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutLongValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.-1.3.300", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteNumberValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get long array value [1, null, 0]. </summary>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.null.zero", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongInvalidString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.integer.0", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        public async ValueTask<Response<ICollection<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutFloatValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteNumberValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/0.0-null-1.2e20", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatInvalidString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/1.number.0", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        public async ValueTask<Response<ICollection<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDoubleValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteNumberValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/0.0-null-1.2e20", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleInvalidString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/1.number.0", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        public async ValueTask<Response<ICollection<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutStringValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        public async ValueTask<Response<ICollection<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetEnumValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<FooEnum> value = new List<FooEnum>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString().ToFooEnum());
                            }
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
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutEnumValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item.ToSerialString());
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        public async ValueTask<Response<ICollection<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringEnumValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Enum0> value = new List<Enum0>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(new Enum0(item.GetString()));
                            }
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
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringEnumValidAsync(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutStringEnumValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item.ToString());
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        public async ValueTask<Response<ICollection<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringWithNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo.null.foo2", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        public async ValueTask<Response<ICollection<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringWithInvalid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo.123.foo2", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetUuidValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/uuid/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
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
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutUuidValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/uuid/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetUuidInvalidChars");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/uuid/invalidchars", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
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
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
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
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item, "D");
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/invalidnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
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
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateInvalidChars");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/invalidchars", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
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
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
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
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateTimeValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item, "S");
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/invalidnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
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
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/invalidchars", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
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
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("R"));
                            }
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
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item, "R");
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        public async ValueTask<Response<ICollection<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDurationValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/duration/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<TimeSpan> value = new List<TimeSpan>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetTimeSpan("P"));
                            }
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
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDurationValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/duration/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item, "P");
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetByteValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/byte/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
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
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutByteValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/byte/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteBase64StringValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetByteInvalidNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/byte/invalidnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
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
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        public async ValueTask<Response<ICollection<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetBase64Url");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/base64url/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64("U"));
                            }
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
        /// <summary> Get array of complex type null value. </summary>
        public async ValueTask<Response<ICollection<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/null", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        /// <summary> Get empty array of complex type []. </summary>
        public async ValueTask<Response<ICollection<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/empty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexItemNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/itemnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexItemEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/itemempty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        public async ValueTask<Response<ICollection<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutComplexValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteObjectValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get a null array. </summary>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/null", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an empty array []. </summary>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/empty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayItemNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/itemnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayItemEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/itemempty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayValidAsync(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutArrayValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStartArray();
                    foreach (var item0 in item)
                    {
                        content.JsonWriter.WriteStringValue(item0);
                    }
                    content.JsonWriter.WriteEndArray();
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> Get an array of Dictionaries with value null. </summary>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/null", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/empty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryItemNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/itemnull", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/itemempty", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDictionaryValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStartObject();
                    foreach (var item0 in item)
                    {
                        content.JsonWriter.WritePropertyName(item0.Key);
                        content.JsonWriter.WriteStringValue(item0.Value);
                    }
                    content.JsonWriter.WriteEndObject();
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
