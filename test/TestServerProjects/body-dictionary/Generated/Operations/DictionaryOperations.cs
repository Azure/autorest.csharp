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
using body_dictionary.Models.V100;

namespace body_dictionary
{
    internal partial class DictionaryOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public DictionaryOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        public async ValueTask<Response<IDictionary<string, int>>> GetNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, int> value = new Dictionary<string, int>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt32());
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
        public async ValueTask<Response<IDictionary<string, int>>> GetEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, int> value = new Dictionary<string, int>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt32());
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
        public async ValueTask<Response> PutEmptyAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/empty", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, string>>> GetNullValueAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetNullValue");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/nullvalue", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, string>>> GetNullKeyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetNullKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/nullkey", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, string>>> GetEmptyStringKeyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetEmptyStringKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/keyemptystring", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, string>>> GetInvalidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetInvalid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/invalid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetBooleanTfft");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/boolean/tfft", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, bool> value = new Dictionary<string, bool>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBoolean());
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
        public async ValueTask<Response> PutBooleanTfftAsync(IDictionary<string, bool> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutBooleanTfft");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/boolean/tfft", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteBooleanValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/boolean/true.null.false", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, bool> value = new Dictionary<string, bool>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBoolean());
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
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetBooleanInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/boolean/true.boolean.false", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, bool> value = new Dictionary<string, bool>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBoolean());
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
        public async ValueTask<Response<IDictionary<string, int>>> GetIntegerValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetIntegerValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/integer/1.-1.3.300", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, int> value = new Dictionary<string, int>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt32());
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
        public async ValueTask<Response> PutIntegerValidAsync(IDictionary<string, int> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutIntegerValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/integer/1.-1.3.300", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteNumberValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetIntInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/integer/1.null.zero", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, int> value = new Dictionary<string, int>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt32());
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
        public async ValueTask<Response<IDictionary<string, int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetIntInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/integer/1.integer.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, int> value = new Dictionary<string, int>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt32());
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
        public async ValueTask<Response<IDictionary<string, long>>> GetLongValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetLongValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/long/1.-1.3.300", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, long> value = new Dictionary<string, long>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt64());
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
        public async ValueTask<Response> PutLongValidAsync(IDictionary<string, long> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutLongValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/long/1.-1.3.300", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteNumberValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetLongInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/long/1.null.zero", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, long> value = new Dictionary<string, long>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt64());
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
        public async ValueTask<Response<IDictionary<string, long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetLongInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/long/1.integer.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, long> value = new Dictionary<string, long>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetInt64());
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
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetFloatValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/float/0--0.01-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, float> value = new Dictionary<string, float>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetSingle());
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
        public async ValueTask<Response> PutFloatValidAsync(IDictionary<string, float> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutFloatValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/float/0--0.01-1.2e20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteNumberValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetFloatInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/float/0.0-null-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, float> value = new Dictionary<string, float>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetSingle());
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
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetFloatInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/float/1.number.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, float> value = new Dictionary<string, float>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetSingle());
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
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDoubleValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/double/0--0.01-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, double> value = new Dictionary<string, double>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDouble());
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
        public async ValueTask<Response> PutDoubleValidAsync(IDictionary<string, double> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDoubleValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/double/0--0.01-1.2e20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteNumberValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/double/0.0-null-1.2e20", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, double> value = new Dictionary<string, double>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDouble());
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
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDoubleInvalidString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/double/1.number.0", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, double> value = new Dictionary<string, double>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDouble());
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
        public async ValueTask<Response<IDictionary<string, string>>> GetStringValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetStringValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/string/foo1.foo2.foo3", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response> PutStringValidAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutStringValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/string/foo1.foo2.foo3", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, string>>> GetStringWithNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetStringWithNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/string/foo.null.foo2", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetStringWithInvalid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/string/foo.123.foo2", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, string> value = new Dictionary<string, string>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetString());
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("D"));
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
        public async ValueTask<Response> PutDateValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDateValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value, "D");
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("D"));
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateInvalidChars");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date/invalidchars", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("D"));
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateTimeValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("S"));
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
        public async ValueTask<Response> PutDateTimeValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDateTimeValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value, "S");
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("S"));
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time/invalidchars", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("S"));
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
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time-rfc1123/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, DateTimeOffset> value = new Dictionary<string, DateTimeOffset>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetDateTimeOffset("R"));
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
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/date-time-rfc1123/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value, "R");
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDurationValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/duration/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, TimeSpan> value = new Dictionary<string, TimeSpan>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetTimeSpan("P"));
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
        public async ValueTask<Response> PutDurationValidAsync(IDictionary<string, TimeSpan> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDurationValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/duration/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStringValue(item.Value, "P");
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, Byte[]>>> GetByteValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetByteValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/byte/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Byte[]> value = new Dictionary<string, Byte[]>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBytesFromBase64());
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
        public async ValueTask<Response> PutByteValidAsync(IDictionary<string, Byte[]> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutByteValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/byte/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteBase64StringValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, Byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetByteInvalidNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/byte/invalidnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Byte[]> value = new Dictionary<string, Byte[]>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBytesFromBase64());
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
        public async ValueTask<Response<IDictionary<string, Byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetBase64Url");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/prim/base64url/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Byte[]> value = new Dictionary<string, Byte[]>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetBytesFromBase64("U"));
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
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetComplexNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Widget> value = new Dictionary<string, Widget>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, Widget.DeserializeWidget(property.Value));
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
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetComplexEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Widget> value = new Dictionary<string, Widget>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, Widget.DeserializeWidget(property.Value));
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
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexItemNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetComplexItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Widget> value = new Dictionary<string, Widget>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, Widget.DeserializeWidget(property.Value));
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
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetComplexItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Widget> value = new Dictionary<string, Widget>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, Widget.DeserializeWidget(property.Value));
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
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetComplexValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, Widget> value = new Dictionary<string, Widget>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, Widget.DeserializeWidget(property.Value));
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
        public async ValueTask<Response> PutComplexValidAsync(IDictionary<string, Widget> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutComplexValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/complex/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetArrayNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, ICollection<string>> value = new Dictionary<string, ICollection<string>>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item in property.Value.EnumerateArray())
                                {
                                    value0.Add(item.GetString());
                                }
                                value.Add(property.Name, value0);
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
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetArrayEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, ICollection<string>> value = new Dictionary<string, ICollection<string>>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item in property.Value.EnumerateArray())
                                {
                                    value0.Add(item.GetString());
                                }
                                value.Add(property.Name, value0);
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
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetArrayItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, ICollection<string>> value = new Dictionary<string, ICollection<string>>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item in property.Value.EnumerateArray())
                                {
                                    value0.Add(item.GetString());
                                }
                                value.Add(property.Name, value0);
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
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetArrayItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, ICollection<string>> value = new Dictionary<string, ICollection<string>>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item in property.Value.EnumerateArray())
                                {
                                    value0.Add(item.GetString());
                                }
                                value.Add(property.Name, value0);
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
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetArrayValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, ICollection<string>> value = new Dictionary<string, ICollection<string>>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item in property.Value.EnumerateArray())
                                {
                                    value0.Add(item.GetString());
                                }
                                value.Add(property.Name, value0);
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
        public async ValueTask<Response> PutArrayValidAsync(IDictionary<string, ICollection<string>> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutArrayValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/array/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteStartArray();
                    foreach (var item0 in item.Value)
                    {
                        content.JsonWriter.WriteStringValue(item0);
                    }
                    content.JsonWriter.WriteEndArray();
                }
                content.JsonWriter.WriteEndObject();
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
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDictionaryNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/null", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
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
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDictionaryEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/empty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
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
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDictionaryItemNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/itemnull", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
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
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/itemempty", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
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
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryValidAsync(CancellationToken cancellationToken)
        {

            using var scope = clientDiagnostics.CreateScope("body_dictionary.GetDictionaryValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/valid", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
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
        public async ValueTask<Response> PutDictionaryValidAsync(IDictionary<string, object> arrayBody, CancellationToken cancellationToken)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_dictionary.PutDictionaryValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/dictionary/dictionary/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in arrayBody)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
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
