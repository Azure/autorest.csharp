// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using url.Models;

namespace url
{
    public partial class PathsClient
    {
        internal PathsRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PathsClient. </summary>
        internal PathsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new PathsRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanTrueAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanTrueAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanTrue(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanTrue(cancellationToken);
        }
        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanFalseAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanFalseAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanFalse(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanFalse(cancellationToken);
        }
        /// <summary> Get &apos;1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntOneMillionAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntOneMillionAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntOneMillion(CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntOneMillion(cancellationToken);
        }
        /// <summary> Get &apos;-1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntNegativeOneMillionAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntNegativeOneMillionAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;-1000000&apos; integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNegativeOneMillion(CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntNegativeOneMillion(cancellationToken);
        }
        /// <summary> Get &apos;10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetTenBillionAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetTenBillionAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetTenBillion(CancellationToken cancellationToken = default)
        {
            return RestClient.GetTenBillion(cancellationToken);
        }
        /// <summary> Get &apos;-10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetNegativeTenBillionAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNegativeTenBillionAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;-10000000000&apos; 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetNegativeTenBillion(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNegativeTenBillion(cancellationToken);
        }
        /// <summary> Get &apos;1.034E+20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificPositiveAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.FloatScientificPositiveAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;1.034E+20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificPositive(CancellationToken cancellationToken = default)
        {
            return RestClient.FloatScientificPositive(cancellationToken);
        }
        /// <summary> Get &apos;-1.034E-20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatScientificNegativeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.FloatScientificNegativeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;-1.034E-20&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificNegative(CancellationToken cancellationToken = default)
        {
            return RestClient.FloatScientificNegative(cancellationToken);
        }
        /// <summary> Get &apos;9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalPositiveAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.DoubleDecimalPositiveAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalPositive(CancellationToken cancellationToken = default)
        {
            return RestClient.DoubleDecimalPositive(cancellationToken);
        }
        /// <summary> Get &apos;-9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleDecimalNegativeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.DoubleDecimalNegativeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;-9999999.999&apos; numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalNegative(CancellationToken cancellationToken = default)
        {
            return RestClient.DoubleDecimalNegative(cancellationToken);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUnicodeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.StringUnicodeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUnicode(CancellationToken cancellationToken = default)
        {
            return RestClient.StringUnicode(cancellationToken);
        }
        /// <summary> Get &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.StringUrlEncodedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUrlEncoded(CancellationToken cancellationToken = default)
        {
            return RestClient.StringUrlEncoded(cancellationToken);
        }
        /// <summary> Get &apos;begin!*&apos;();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringUrlNonEncodedAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.StringUrlNonEncodedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;begin!*&apos;();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUrlNonEncoded(CancellationToken cancellationToken = default)
        {
            return RestClient.StringUrlNonEncoded(cancellationToken);
        }
        /// <summary> Get &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.StringEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.StringEmpty(cancellationToken);
        }
        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringNullAsync(string stringPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.StringNullAsync(stringPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringNull(string stringPath, CancellationToken cancellationToken = default)
        {
            return RestClient.StringNull(stringPath, cancellationToken);
        }
        /// <summary> Get using uri with &apos;green color&apos; in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumValidAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.EnumValidAsync(enumPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get using uri with &apos;green color&apos; in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            return RestClient.EnumValid(enumPath, cancellationToken);
        }
        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumNullAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.EnumNullAsync(enumPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            return RestClient.EnumNull(enumPath, cancellationToken);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteMultiByteAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            return await RestClient.ByteMultiByteAsync(bytePath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteMultiByte(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            return RestClient.ByteMultiByte(bytePath, cancellationToken);
        }
        /// <summary> Get &apos;&apos; as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.ByteEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;&apos; as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.ByteEmpty(cancellationToken);
        }
        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteNullAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            return await RestClient.ByteNullAsync(bytePath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteNull(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            return RestClient.ByteNull(bytePath, cancellationToken);
        }
        /// <summary> Get &apos;2012-01-01&apos; as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.DateValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;2012-01-01&apos; as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateValid(CancellationToken cancellationToken = default)
        {
            return RestClient.DateValid(cancellationToken);
        }
        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateNullAsync(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {
            return await RestClient.DateNullAsync(datePath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {
            return RestClient.DateNull(datePath, cancellationToken);
        }
        /// <summary> Get &apos;2012-01-01T01:01:01Z&apos; as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.DateTimeValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;2012-01-01T01:01:01Z&apos; as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeValid(CancellationToken cancellationToken = default)
        {
            return RestClient.DateTimeValid(cancellationToken);
        }
        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeNullAsync(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {
            return await RestClient.DateTimeNullAsync(dateTimePath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {
            return RestClient.DateTimeNull(dateTimePath, cancellationToken);
        }
        /// <summary> Get &apos;lorem&apos; encoded value as &apos;bG9yZW0&apos; (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Base64UrlAsync(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.Base64UrlAsync(base64UrlPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;lorem&apos; encoded value as &apos;bG9yZW0&apos; (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Base64Url(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            return RestClient.Base64Url(base64UrlPath, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayCsvInPathAsync(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayCsvInPathAsync(arrayPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string [&apos;ArrayPath1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayCsvInPath(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayCsvInPath(arrayPath, cancellationToken);
        }
        /// <summary> Get the date 2016-04-13 encoded value as &apos;1460505600&apos; (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> UnixTimeUrlAsync(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {
            return await RestClient.UnixTimeUrlAsync(unixTimeUrlPath, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get the date 2016-04-13 encoded value as &apos;1460505600&apos; (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response UnixTimeUrl(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {
            return RestClient.UnixTimeUrl(unixTimeUrlPath, cancellationToken);
        }
    }
}
