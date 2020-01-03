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
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/bool/true/", false);
            request.Uri.AppendPath(true, true);
            return message;
        }
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
        internal HttpMessage CreateGetBooleanFalseRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/bool/false/", false);
            request.Uri.AppendPath(false, true);
            return message;
        }
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
        internal HttpMessage CreateGetIntOneMillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/int/1000000/", false);
            request.Uri.AppendPath(1000000F, true);
            return message;
        }
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
        internal HttpMessage CreateGetIntNegativeOneMillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/int/-1000000/", false);
            request.Uri.AppendPath(-1000000F, true);
            return message;
        }
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
        internal HttpMessage CreateGetTenBillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/long/10000000000/", false);
            request.Uri.AppendPath(1E+10F, true);
            return message;
        }
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
        internal HttpMessage CreateGetNegativeTenBillionRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/long/-10000000000/", false);
            request.Uri.AppendPath(-1E+10F, true);
            return message;
        }
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
        internal HttpMessage CreateFloatScientificPositiveRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/float/1.034E+20/", false);
            request.Uri.AppendPath(1.034E+20F, true);
            return message;
        }
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
        internal HttpMessage CreateFloatScientificNegativeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/float/-1.034E-20/", false);
            request.Uri.AppendPath(-1.034E-20F, true);
            return message;
        }
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
        internal HttpMessage CreateDoubleDecimalPositiveRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/double/9999999.999/", false);
            request.Uri.AppendPath(9999999.999, true);
            return message;
        }
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
        internal HttpMessage CreateDoubleDecimalNegativeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/double/-9999999.999/", false);
            request.Uri.AppendPath(-9999999.999, true);
            return message;
        }
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
        internal HttpMessage CreateStringUnicodeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/unicode/", false);
            request.Uri.AppendPath("啊齄丂狛狜隣郎隣兀﨩", true);
            return message;
        }
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
        internal HttpMessage CreateStringUrlEncodedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend/", false);
            request.Uri.AppendPath("begin!*'();:@ &=+$,/?#[]end", true);
            return message;
        }
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
        internal HttpMessage CreateStringEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/empty/", false);
            request.Uri.AppendPath("", true);
            return message;
        }
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
        internal HttpMessage CreateStringNullRequest(string stringPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/null/", false);
            request.Uri.AppendPath(stringPath, true);
            return message;
        }
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
        internal HttpMessage CreateEnumValidRequest(UriColor enumPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/enum/green%20color/", false);
            request.Uri.AppendPath(enumPath, true);
            return message;
        }
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
        internal HttpMessage CreateEnumNullRequest(UriColor enumPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/null/", false);
            request.Uri.AppendPath(enumPath, true);
            return message;
        }
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
        internal HttpMessage CreateByteMultiByteRequest(byte[] bytePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/byte/multibyte/", false);
            request.Uri.AppendPath(bytePath, true);
            return message;
        }
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
        internal HttpMessage CreateByteEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/byte/empty/", false);
            request.Uri.AppendPath(new byte[] { }, true);
            return message;
        }
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
        internal HttpMessage CreateByteNullRequest(byte[] bytePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/byte/null/", false);
            request.Uri.AppendPath(bytePath, true);
            return message;
        }
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
        internal HttpMessage CreateDateValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/date/2012-01-01/", false);
            request.Uri.AppendPath(new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            return message;
        }
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
        internal HttpMessage CreateDateNullRequest(DateTimeOffset datePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/date/null/", false);
            request.Uri.AppendPath(datePath, "D", true);
            return message;
        }
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
        internal HttpMessage CreateDateTimeValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/datetime/2012-01-01T01%3A01%3A01Z/", false);
            request.Uri.AppendPath(new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "S", true);
            return message;
        }
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
        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset dateTimePath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/datetime/null/", false);
            request.Uri.AppendPath(dateTimePath, "S", true);
            return message;
        }
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
        internal HttpMessage CreateBase64UrlRequest(byte[] base64UrlPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/string/bG9yZW0/", false);
            request.Uri.AppendPath(base64UrlPath, true);
            return message;
        }
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
        internal HttpMessage CreateArrayCsvInPathRequest(IEnumerable<string> arrayPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/array/ArrayPath1%2cbegin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend%2c%2c/", false);
            request.Uri.AppendPath(arrayPath, true);
            return message;
        }
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
        internal HttpMessage CreateUnixTimeUrlRequest(DateTimeOffset unixTimeUrlPath)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/paths/int/1460505600/", false);
            request.Uri.AppendPath(unixTimeUrlPath, "U", true);
            return message;
        }
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
    }
}
