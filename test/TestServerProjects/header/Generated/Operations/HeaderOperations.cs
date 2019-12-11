// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using header.Models.V100;

namespace header
{
    internal static class HeaderOperations
    {
        public static async ValueTask<Response> ParamExistingKeyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string userAgent, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (userAgent == null) throw new ArgumentNullException(nameof(userAgent));

            using var scope = clientDiagnostics.CreateScope("header.ParamExistingKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/existingkey", false);
                request.Headers.Add("User-Agent", userAgent);
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
        public static async ValueTask<Response> ResponseExistingKeyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("header.ResponseExistingKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/existingkey", false);
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
        public static async ValueTask<Response> ParamProtectedKeyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string contentType, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (contentType == null) throw new ArgumentNullException(nameof(contentType));

            using var scope = clientDiagnostics.CreateScope("header.ParamProtectedKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/protectedkey", false);
                request.Headers.Add("Content-Type", contentType);
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
        public static async ValueTask<Response> ResponseProtectedKeyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("header.ResponseProtectedKey");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/protectedkey", false);
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
        public static async ValueTask<Response> ParamIntegerAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, int value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamInteger");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/integer", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseIntegerAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseInteger");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/integer", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamLongAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, long value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamLong");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/long", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseLongAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseLong");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/long", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamFloatAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, float value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamFloat");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/float", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseFloatAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseFloat");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/float", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamDoubleAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, double value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamDouble");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/double", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseDoubleAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseDouble");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/double", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamBoolAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, bool value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamBool");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/bool", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseBoolAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseBool");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/bool", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string? value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));
            if (value == null) throw new ArgumentNullException(nameof(value));

            using var scope = clientDiagnostics.CreateScope("header.ParamString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/string", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value);
                }
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
        public static async ValueTask<Response> ResponseStringAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseString");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/string", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamDateAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, DateTimeOffset value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamDate");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/date", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value, "D");
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
        public static async ValueTask<Response> ResponseDateAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseDate");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/date", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamDatetimeAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, DateTimeOffset value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamDatetime");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/datetime", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value, "S");
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
        public static async ValueTask<Response> ResponseDatetimeAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseDatetime");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/datetime", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamDatetimeRfc1123Async(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, DateTimeOffset? value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/datetimerfc1123", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value.Value, "R");
                }
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
        public static async ValueTask<Response> ResponseDatetimeRfc1123Async(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/datetimerfc1123", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamDurationAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, TimeSpan value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamDuration");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/duration", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseDurationAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseDuration");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/duration", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamByteAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, Byte[] value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));
            if (value == null) throw new ArgumentNullException(nameof(value));

            using var scope = clientDiagnostics.CreateScope("header.ParamByte");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/byte", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        public static async ValueTask<Response> ResponseByteAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseByte");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/byte", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> ParamEnumAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, GreyscaleColors? value, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ParamEnum");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/enum", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value.Value);
                }
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
        public static async ValueTask<Response> ResponseEnumAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scenario, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));

            using var scope = clientDiagnostics.CreateScope("header.ResponseEnum");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/enum", false);
                request.Headers.Add("scenario", scenario);
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
        public static async ValueTask<Response> CustomRequestIdAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("header.CustomRequestId");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
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
