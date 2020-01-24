// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using url.Models;

namespace url
{
    internal partial class QueriesOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of QueriesOperations. </summary>
        public QueriesOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            uri.AppendPath("/queries/bool/true", false);
            uri.AppendQuery("boolQuery", true, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanTrueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanTrue");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanTrue");
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
            uri.AppendPath("/queries/bool/false", false);
            uri.AppendQuery("boolQuery", false, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanFalseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanFalse");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanFalse");
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
        internal HttpMessage CreateGetBooleanNullRequest(bool? boolQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/bool/null", false);
            if (boolQuery != null)
            {
                uri.AppendQuery("boolQuery", boolQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanNullAsync(bool? boolQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanNull");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanNullRequest(boolQuery);
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
        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanNull(bool? boolQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetBooleanNull");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanNullRequest(boolQuery);
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
            uri.AppendPath("/queries/int/1000000", false);
            uri.AppendQuery("intQuery", 1000000F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntOneMillion");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntOneMillion");
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
            uri.AppendPath("/queries/int/-1000000", false);
            uri.AppendQuery("intQuery", -1000000F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntNegativeOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntNegativeOneMillion");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntNegativeOneMillion");
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
        internal HttpMessage CreateGetIntNullRequest(int? intQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/int/null", false);
            if (intQuery != null)
            {
                uri.AppendQuery("intQuery", intQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntNullAsync(int? intQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntNull");
            scope.Start();
            try
            {
                using var message = CreateGetIntNullRequest(intQuery);
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
        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNull(int? intQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetIntNull");
            scope.Start();
            try
            {
                using var message = CreateGetIntNullRequest(intQuery);
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
            uri.AppendPath("/queries/long/10000000000", false);
            uri.AppendQuery("longQuery", 1E+10F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetTenBillion");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetTenBillion");
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
            uri.AppendPath("/queries/long/-10000000000", false);
            uri.AppendQuery("longQuery", -1E+10F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetNegativeTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetNegativeTenBillion");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetNegativeTenBillion");
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
        internal HttpMessage CreateGetLongNullRequest(long? longQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/long/null", false);
            if (longQuery != null)
            {
                uri.AppendQuery("longQuery", longQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetLongNullAsync(long? longQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetLongNull");
            scope.Start();
            try
            {
                using var message = CreateGetLongNullRequest(longQuery);
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
        /// <summary> Get &apos;null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetLongNull(long? longQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.GetLongNull");
            scope.Start();
            try
            {
                using var message = CreateGetLongNullRequest(longQuery);
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
            uri.AppendPath("/queries/float/1.034E+20", false);
            uri.AppendQuery("floatQuery", 1.034E+20F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;1.034E+20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatScientificPositive");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatScientificPositive");
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
            uri.AppendPath("/queries/float/-1.034E-20", false);
            uri.AppendQuery("floatQuery", -1.034E-20F, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-1.034E-20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatScientificNegative");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatScientificNegative");
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
        internal HttpMessage CreateFloatNullRequest(float? floatQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/float/null", false);
            if (floatQuery != null)
            {
                uri.AppendQuery("floatQuery", floatQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatNullAsync(float? floatQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatNull");
            scope.Start();
            try
            {
                using var message = CreateFloatNullRequest(floatQuery);
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
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatNull(float? floatQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.FloatNull");
            scope.Start();
            try
            {
                using var message = CreateFloatNullRequest(floatQuery);
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
            uri.AppendPath("/queries/double/9999999.999", false);
            uri.AppendQuery("doubleQuery", 9999999.999, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleDecimalPositive");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleDecimalPositive");
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
            uri.AppendPath("/queries/double/-9999999.999", false);
            uri.AppendQuery("doubleQuery", -9999999.999, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;-9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleDecimalNegative");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleDecimalNegative");
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
        internal HttpMessage CreateDoubleNullRequest(double? doubleQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/double/null", false);
            if (doubleQuery != null)
            {
                uri.AppendQuery("doubleQuery", doubleQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleNullAsync(double? doubleQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleNull");
            scope.Start();
            try
            {
                using var message = CreateDoubleNullRequest(doubleQuery);
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
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleNull(double? doubleQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DoubleNull");
            scope.Start();
            try
            {
                using var message = CreateDoubleNullRequest(doubleQuery);
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
            uri.AppendPath("/queries/string/unicode/", false);
            uri.AppendQuery("stringQuery", "啊齄丂狛狜隣郎隣兀﨩", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUnicodeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringUnicode");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringUnicode");
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
            uri.AppendPath("/queries/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend", false);
            uri.AppendQuery("stringQuery", "begin!*'();:@ &=+$,/?#[]end", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringUrlEncoded");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringUrlEncoded");
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
        internal HttpMessage CreateStringEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/string/empty", false);
            uri.AppendQuery("stringQuery", "", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringEmpty");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringEmpty");
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
        internal HttpMessage CreateStringNullRequest(string stringQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/string/null", false);
            if (stringQuery != null)
            {
                uri.AppendQuery("stringQuery", stringQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringNullAsync(string stringQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringNull");
            scope.Start();
            try
            {
                using var message = CreateStringNullRequest(stringQuery);
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
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringNull(string stringQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.StringNull");
            scope.Start();
            try
            {
                using var message = CreateStringNullRequest(stringQuery);
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
        internal HttpMessage CreateEnumValidRequest(UriColor? enumQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/enum/green%20color", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get using uri with query parameter &apos;green color&apos;. </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumValidAsync(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.EnumValid");
            scope.Start();
            try
            {
                using var message = CreateEnumValidRequest(enumQuery);
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
        /// <summary> Get using uri with query parameter &apos;green color&apos;. </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.EnumValid");
            scope.Start();
            try
            {
                using var message = CreateEnumValidRequest(enumQuery);
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
        internal HttpMessage CreateEnumNullRequest(UriColor? enumQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/enum/null", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumNullAsync(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.EnumNull");
            scope.Start();
            try
            {
                using var message = CreateEnumNullRequest(enumQuery);
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
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.EnumNull");
            scope.Start();
            try
            {
                using var message = CreateEnumNullRequest(enumQuery);
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
        internal HttpMessage CreateByteMultiByteRequest(byte[] byteQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/byte/multibyte", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteMultiByteAsync(byte[] byteQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteMultiByte");
            scope.Start();
            try
            {
                using var message = CreateByteMultiByteRequest(byteQuery);
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
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteMultiByte(byte[] byteQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteMultiByte");
            scope.Start();
            try
            {
                using var message = CreateByteMultiByteRequest(byteQuery);
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
            uri.AppendPath("/queries/byte/empty", false);
            uri.AppendQuery("byteQuery", new byte[] { }, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;&apos; as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteEmpty");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteEmpty");
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
        internal HttpMessage CreateByteNullRequest(byte[] byteQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/byte/null", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteNullAsync(byte[] byteQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteNull");
            scope.Start();
            try
            {
                using var message = CreateByteNullRequest(byteQuery);
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
        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteNull(byte[] byteQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ByteNull");
            scope.Start();
            try
            {
                using var message = CreateByteNullRequest(byteQuery);
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
        internal HttpMessage CreateDateValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/date/2012-01-01", false);
            uri.AppendQuery("dateQuery", new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;2012-01-01&apos; as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateValid");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateValid");
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
        internal HttpMessage CreateDateNullRequest(DateTimeOffset? dateQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/date/null", false);
            if (dateQuery != null)
            {
                uri.AppendQuery("dateQuery", dateQuery.Value, "D", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateNullAsync(DateTimeOffset? dateQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateNull");
            scope.Start();
            try
            {
                using var message = CreateDateNullRequest(dateQuery);
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
        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset? dateQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateNull");
            scope.Start();
            try
            {
                using var message = CreateDateNullRequest(dateQuery);
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
        internal HttpMessage CreateDateTimeValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/datetime/2012-01-01T01%3A01%3A01Z", false);
            uri.AppendQuery("dateTimeQuery", new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "S", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get &apos;2012-01-01T01:01:01Z&apos; as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateTimeValid");
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
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateTimeValid");
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
        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset? dateTimeQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/datetime/null", false);
            if (dateTimeQuery != null)
            {
                uri.AppendQuery("dateTimeQuery", dateTimeQuery.Value, "S", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeNullAsync(DateTimeOffset? dateTimeQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateTimeNull");
            scope.Start();
            try
            {
                using var message = CreateDateTimeNullRequest(dateTimeQuery);
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
        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset? dateTimeQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.DateTimeNull");
            scope.Start();
            try
            {
                using var message = CreateDateTimeNullRequest(dateTimeQuery);
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
        internal HttpMessage CreateArrayStringCsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/csv/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvValidRequest(arrayQuery);
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
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvValidRequest(arrayQuery);
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
        internal HttpMessage CreateArrayStringCsvNullRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/csv/string/null", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvNullAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvNull");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvNullRequest(arrayQuery);
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
        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvNull(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvNull");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvNullRequest(arrayQuery);
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
        internal HttpMessage CreateArrayStringCsvEmptyRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/csv/string/empty", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvEmptyAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvEmptyRequest(arrayQuery);
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
        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvEmpty(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                using var message = CreateArrayStringCsvEmptyRequest(arrayQuery);
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
        internal HttpMessage CreateArrayStringSsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/ssv/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, " ", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringSsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringSsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringSsvValidRequest(arrayQuery);
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
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringSsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringSsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringSsvValidRequest(arrayQuery);
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
        internal HttpMessage CreateArrayStringTsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/tsv/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "\t", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringTsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringTsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringTsvValidRequest(arrayQuery);
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
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringTsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringTsvValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringTsvValidRequest(arrayQuery);
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
        internal HttpMessage CreateArrayStringPipesValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/pipes/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "|", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringPipesValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringPipesValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringPipesValidRequest(arrayQuery);
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
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringPipesValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringPipesValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringPipesValidRequest(arrayQuery);
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
