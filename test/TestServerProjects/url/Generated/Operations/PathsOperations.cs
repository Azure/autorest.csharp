// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using url.Models.V100;

namespace url
{
    internal partial class PathsOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PathsOperations. </summary>
        public PathsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetBooleanTrueRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/bool/true/", false);
            uri.AppendPath(true, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanTrueAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetBooleanTrue");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanTrueRequest();
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
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanTrue(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetBooleanTrue");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanTrueRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBooleanFalseRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/bool/false/", false);
            uri.AppendPath(false, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanFalseAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetBooleanFalse");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanFalseRequest();
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
        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanFalse(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetBooleanFalse");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanFalseRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetIntOneMillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/int/1000000/", false);
            uri.AppendPath(1000000F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntOneMillionAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetIntOneMillion");
            scope.Start();
            try
            {
                using var message = CreateGetIntOneMillionRequest();
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
        /// <summary> Get &apos;1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntOneMillion(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetIntOneMillion");
            scope.Start();
            try
            {
                using var message = CreateGetIntOneMillionRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetIntNegativeOneMillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/int/-1000000/", false);
            uri.AppendPath(-1000000F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntNegativeOneMillionAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                using var message = CreateGetIntNegativeOneMillionRequest();
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
        /// <summary> Get &apos;-1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNegativeOneMillion(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                using var message = CreateGetIntNegativeOneMillionRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetTenBillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/long/10000000000/", false);
            uri.AppendPath(1E+10F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetTenBillionAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetTenBillion");
            scope.Start();
            try
            {
                using var message = CreateGetTenBillionRequest();
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
        /// <summary> Get &apos;10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetTenBillion(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetTenBillion");
            scope.Start();
            try
            {
                using var message = CreateGetTenBillionRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetNegativeTenBillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/long/-10000000000/", false);
            uri.AppendPath(-1E+10F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetNegativeTenBillionAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetNegativeTenBillion");
            scope.Start();
            try
            {
                using var message = CreateGetNegativeTenBillionRequest();
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
        /// <summary> Get &apos;-10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetNegativeTenBillion(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetNegativeTenBillion");
            scope.Start();
            try
            {
                using var message = CreateGetNegativeTenBillionRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateFloatScientificPositiveRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/float/1.034E+20/", false);
            uri.AppendPath(1.034E+20F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;1.034E+20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificPositiveAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.FloatScientificPositive");
            scope.Start();
            try
            {
                using var message = CreateFloatScientificPositiveRequest();
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
        /// <summary> Get &apos;1.034E+20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificPositive(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.FloatScientificPositive");
            scope.Start();
            try
            {
                using var message = CreateFloatScientificPositiveRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateFloatScientificNegativeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/float/-1.034E-20/", false);
            uri.AppendPath(-1.034E-20F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-1.034E-20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificNegativeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.FloatScientificNegative");
            scope.Start();
            try
            {
                using var message = CreateFloatScientificNegativeRequest();
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
        /// <summary> Get &apos;-1.034E-20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificNegative(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.FloatScientificNegative");
            scope.Start();
            try
            {
                using var message = CreateFloatScientificNegativeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDoubleDecimalPositiveRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/double/9999999.999/", false);
            uri.AppendPath(9999999.999, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalPositiveAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DoubleDecimalPositive");
            scope.Start();
            try
            {
                using var message = CreateDoubleDecimalPositiveRequest();
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
        /// <summary> Get &apos;9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalPositive(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DoubleDecimalPositive");
            scope.Start();
            try
            {
                using var message = CreateDoubleDecimalPositiveRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDoubleDecimalNegativeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/double/-9999999.999/", false);
            uri.AppendPath(-9999999.999, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalNegativeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DoubleDecimalNegative");
            scope.Start();
            try
            {
                using var message = CreateDoubleDecimalNegativeRequest();
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
        /// <summary> Get &apos;-9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalNegative(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DoubleDecimalNegative");
            scope.Start();
            try
            {
                using var message = CreateDoubleDecimalNegativeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateStringUnicodeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/unicode/", false);
            uri.AppendPath("啊齄丂狛狜隣郎隣兀﨩", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUnicodeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUnicode");
            scope.Start();
            try
            {
                using var message = CreateStringUnicodeRequest();
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
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUnicode(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUnicode");
            scope.Start();
            try
            {
                using var message = CreateStringUnicodeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateStringUrlEncodedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend/", false);
            uri.AppendPath("begin!*'();:@ &=+$,/?#[]end", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUrlEncodedAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUrlEncoded");
            scope.Start();
            try
            {
                using var message = CreateStringUrlEncodedRequest();
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
        /// <summary> Get &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUrlEncoded(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUrlEncoded");
            scope.Start();
            try
            {
                using var message = CreateStringUrlEncodedRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateStringUrlNonEncodedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/begin!*'();:@&=+$,end/", false);
            uri.AppendPath("begin!*'();:@&=+$,end", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;begin!*&apos;();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUrlNonEncodedAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUrlNonEncoded");
            scope.Start();
            try
            {
                using var message = CreateStringUrlNonEncodedRequest();
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
        /// <summary> Get &apos;begin!*&apos;();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUrlNonEncoded(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringUrlNonEncoded");
            scope.Start();
            try
            {
                using var message = CreateStringUrlNonEncodedRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateStringEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/empty/", false);
            uri.AppendPath("", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringEmpty");
            scope.Start();
            try
            {
                using var message = CreateStringEmptyRequest();
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
        /// <summary> Get &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringEmpty");
            scope.Start();
            try
            {
                using var message = CreateStringEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateStringNullRequest(string stringPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(stringPath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringNullAsync(string stringPath, CancellationToken cancellationToken = default)
        {
            if (stringPath == null)
            {
                throw new ArgumentNullException(nameof(stringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringNull");
            scope.Start();
            try
            {
                using var message = CreateStringNullRequest(stringPath);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 400:
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
        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringNull(string stringPath, CancellationToken cancellationToken = default)
        {
            if (stringPath == null)
            {
                throw new ArgumentNullException(nameof(stringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.StringNull");
            scope.Start();
            try
            {
                using var message = CreateStringNullRequest(stringPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 400:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateEnumValidRequest(UriColor enumPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/enum/green%20color/", false);
            uri.AppendPath(enumPath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get using uri with &apos;green color&apos; in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumValidAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.EnumValid");
            scope.Start();
            try
            {
                using var message = CreateEnumValidRequest(enumPath);
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
        /// <summary> Get using uri with &apos;green color&apos; in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor enumPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.EnumValid");
            scope.Start();
            try
            {
                using var message = CreateEnumValidRequest(enumPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateEnumNullRequest(UriColor enumPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(enumPath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumNullAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.EnumNull");
            scope.Start();
            try
            {
                using var message = CreateEnumNullRequest(enumPath);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 400:
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
        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor enumPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.EnumNull");
            scope.Start();
            try
            {
                using var message = CreateEnumNullRequest(enumPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 400:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateByteMultiByteRequest(byte[] bytePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/byte/multibyte/", false);
            uri.AppendPath(bytePath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteMultiByteAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteMultiByte");
            scope.Start();
            try
            {
                using var message = CreateByteMultiByteRequest(bytePath);
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
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteMultiByte(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteMultiByte");
            scope.Start();
            try
            {
                using var message = CreateByteMultiByteRequest(bytePath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateByteEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/byte/empty/", false);
            uri.AppendPath(new byte[] { }, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;&apos; as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteEmpty");
            scope.Start();
            try
            {
                using var message = CreateByteEmptyRequest();
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
        /// <summary> Get &apos;&apos; as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteEmpty");
            scope.Start();
            try
            {
                using var message = CreateByteEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateByteNullRequest(byte[] bytePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/byte/null/", false);
            uri.AppendPath(bytePath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteNullAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteNull");
            scope.Start();
            try
            {
                using var message = CreateByteNullRequest(bytePath);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 400:
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
        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteNull(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ByteNull");
            scope.Start();
            try
            {
                using var message = CreateByteNullRequest(bytePath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 400:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDateValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/date/2012-01-01/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;2012-01-01&apos; as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateValid");
            scope.Start();
            try
            {
                using var message = CreateDateValidRequest();
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
        /// <summary> Get &apos;2012-01-01&apos; as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateValid");
            scope.Start();
            try
            {
                using var message = CreateDateValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDateNullRequest(DateTimeOffset datePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/date/null/", false);
            uri.AppendPath(datePath, "D", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateNullAsync(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateNull");
            scope.Start();
            try
            {
                using var message = CreateDateNullRequest(datePath);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 400:
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
        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateNull");
            scope.Start();
            try
            {
                using var message = CreateDateNullRequest(datePath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 400:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDateTimeValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/datetime/2012-01-01T01%3A01%3A01Z/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "S", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;2012-01-01T01:01:01Z&apos; as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateTimeValid");
            scope.Start();
            try
            {
                using var message = CreateDateTimeValidRequest();
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
        /// <summary> Get &apos;2012-01-01T01:01:01Z&apos; as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateTimeValid");
            scope.Start();
            try
            {
                using var message = CreateDateTimeValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset dateTimePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/datetime/null/", false);
            uri.AppendPath(dateTimePath, "S", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeNullAsync(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateTimeNull");
            scope.Start();
            try
            {
                using var message = CreateDateTimeNullRequest(dateTimePath);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 400:
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
        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.DateTimeNull");
            scope.Start();
            try
            {
                using var message = CreateDateTimeNullRequest(dateTimePath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 400:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateBase64UrlRequest(byte[] base64UrlPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/string/bG9yZW0/", false);
            uri.AppendPath(base64UrlPath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;lorem&apos; encoded value as &apos;bG9yZW0&apos; (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Base64UrlAsync(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            if (base64UrlPath == null)
            {
                throw new ArgumentNullException(nameof(base64UrlPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.Base64Url");
            scope.Start();
            try
            {
                using var message = CreateBase64UrlRequest(base64UrlPath);
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
        /// <summary> Get &apos;lorem&apos; encoded value as &apos;bG9yZW0&apos; (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Base64Url(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            if (base64UrlPath == null)
            {
                throw new ArgumentNullException(nameof(base64UrlPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.Base64Url");
            scope.Start();
            try
            {
                using var message = CreateBase64UrlRequest(base64UrlPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateArrayCsvInPathRequest(IEnumerable<string> arrayPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/array/ArrayPath1%2cbegin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend%2c%2c/", false);
            uri.AppendPath(arrayPath, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayCsvInPathAsync(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            if (arrayPath == null)
            {
                throw new ArgumentNullException(nameof(arrayPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ArrayCsvInPath");
            scope.Start();
            try
            {
                using var message = CreateArrayCsvInPathRequest(arrayPath);
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
        /// <summary> Get an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayCsvInPath(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            if (arrayPath == null)
            {
                throw new ArgumentNullException(nameof(arrayPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathsOperations.ArrayCsvInPath");
            scope.Start();
            try
            {
                using var message = CreateArrayCsvInPathRequest(arrayPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateUnixTimeUrlRequest(DateTimeOffset unixTimeUrlPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paths/int/1460505600/", false);
            uri.AppendPath(unixTimeUrlPath, "U", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get the date 2016-04-13 encoded value as &apos;1460505600&apos; (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> UnixTimeUrlAsync(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.UnixTimeUrl");
            scope.Start();
            try
            {
                using var message = CreateUnixTimeUrlRequest(unixTimeUrlPath);
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
        /// <summary> Get the date 2016-04-13 encoded value as &apos;1460505600&apos; (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response UnixTimeUrl(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PathsOperations.UnixTimeUrl");
            scope.Start();
            try
            {
                using var message = CreateUnixTimeUrlRequest(unixTimeUrlPath);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
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
