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
    internal static class ArrayOperations
    {
        public static async ValueTask<Response<ICollection<int>>> GetNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response<ICollection<int>>> GetInvalidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetInvalid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/invalid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response<ICollection<int>>> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response> PutEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<bool>>> GetBooleanTfftAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanTfft");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/tfft", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        public static async ValueTask<Response> PutBooleanTfftAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<bool> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutBooleanTfft");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/true.null.false", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        public static async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetBooleanInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/boolean/true.boolean.false", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
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
        public static async ValueTask<Response<ICollection<int>>> GetIntegerValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntegerValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response> PutIntegerValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<int> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutIntegerValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<int>>> GetIntInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.null.zero", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response<ICollection<int>>> GetIntInvalidStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetIntInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/integer/1.integer.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
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
        public static async ValueTask<Response<ICollection<long>>> GetLongValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.-1.3.300", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        public static async ValueTask<Response> PutLongValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<long> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutLongValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<long>>> GetLongInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.null.zero", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        public static async ValueTask<Response<ICollection<long>>> GetLongInvalidStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetLongInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/long/1.integer.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
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
        public static async ValueTask<Response<ICollection<float>>> GetFloatValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        public static async ValueTask<Response> PutFloatValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<float> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutFloatValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<float>>> GetFloatInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/0.0-null-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        public static async ValueTask<Response<ICollection<float>>> GetFloatInvalidStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetFloatInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/float/1.number.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
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
        public static async ValueTask<Response<ICollection<double>>> GetDoubleValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        public static async ValueTask<Response> PutDoubleValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<double> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDoubleValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<double>>> GetDoubleInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/0.0-null-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        public static async ValueTask<Response<ICollection<double>>> GetDoubleInvalidStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDoubleInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/double/1.number.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
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
        public static async ValueTask<Response<ICollection<string>>> GetStringValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        public static async ValueTask<Response> PutStringValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutStringValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<FooEnum>>> GetEnumValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetEnumValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<FooEnum> value = new List<FooEnum>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString().ToFooEnum());
                            }
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
        public static async ValueTask<Response> PutEnumValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<FooEnum> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutEnumValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<Enum0>>> GetStringEnumValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringEnumValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Enum0> value = new List<Enum0>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(new Enum0(item.GetString()));
                            }
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
        public static async ValueTask<Response> PutStringEnumValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<Enum0> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutStringEnumValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<string>>> GetStringWithNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringWithNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo.null.foo2", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        public static async ValueTask<Response<ICollection<string>>> GetStringWithInvalidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetStringWithInvalid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/string/foo.123.foo2", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        public static async ValueTask<Response<ICollection<string>>> GetUuidValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetUuidValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/uuid/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        public static async ValueTask<Response> PutUuidValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutUuidValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<string>>> GetUuidInvalidCharsAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetUuidInvalidChars");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/uuid/invalidchars", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response> PutDateValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<DateTimeOffset> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidCharsAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateInvalidChars");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date/invalidchars", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response> PutDateTimeValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<DateTimeOffset> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateTimeValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time/invalidchars", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset());
                            }
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
        public static async ValueTask<Response> PutDateTimeRfc1123ValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<DateTimeOffset> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
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
        public static async ValueTask<Response<ICollection<TimeSpan>>> GetDurationValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDurationValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/duration/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<TimeSpan> value = new List<TimeSpan>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetTimeSpan());
                            }
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
        public static async ValueTask<Response> PutDurationValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<TimeSpan> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDurationValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/duration/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
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
        public static async ValueTask<Response<ICollection<Byte[]>>> GetByteValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetByteValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/byte/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Byte[]> value = new List<Byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
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
        public static async ValueTask<Response> PutByteValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<Byte[]> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutByteValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<Byte[]>>> GetByteInvalidNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetByteInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/byte/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Byte[]> value = new List<Byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
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
        public static async ValueTask<Response<ICollection<Byte[]>>> GetBase64UrlAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetBase64Url");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/prim/base64url/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Byte[]> value = new List<Byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
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
        public static async ValueTask<Response<ICollection<Product>>> GetComplexNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        public static async ValueTask<Response<ICollection<Product>>> GetComplexEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        public static async ValueTask<Response<ICollection<Product>>> GetComplexItemNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        public static async ValueTask<Response<ICollection<Product>>> GetComplexItemEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        public static async ValueTask<Response<ICollection<Product>>> GetComplexValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetComplexValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/complex/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
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
        public static async ValueTask<Response> PutComplexValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<Product> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutComplexValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public static async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public static async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public static async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public static async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetArrayValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/array/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public static async ValueTask<Response> PutArrayValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<ICollection<string>> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutArrayValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
        public static async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var item0 in item.EnumerateObject())
                                {
                                    value0.Add(item0.Name, item0.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        public static async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var item0 in item.EnumerateObject())
                                {
                                    value0.Add(item0.Name, item0.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        public static async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var item0 in item.EnumerateObject())
                                {
                                    value0.Add(item0.Name, item0.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        public static async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var item0 in item.EnumerateObject())
                                {
                                    value0.Add(item0.Name, item0.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        public static async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.GetDictionaryValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/array/dictionary/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var item0 in item.EnumerateObject())
                                {
                                    value0.Add(item0.Name, item0.Value.GetString());
                                }
                                value.Add(value0);
                            }
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
        public static async ValueTask<Response> PutDictionaryValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<IDictionary<string, string>> arrayBody, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_array.PutDictionaryValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
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
