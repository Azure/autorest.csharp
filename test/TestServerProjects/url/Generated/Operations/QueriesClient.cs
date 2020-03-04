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
    public partial class QueriesClient
    {
        internal QueriesRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of QueriesClient. </summary>
        internal QueriesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new QueriesRestClient(clientDiagnostics, pipeline, host);
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
        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetBooleanNullAsync(bool? boolQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanNullAsync(boolQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanNull(bool? boolQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanNull(boolQuery, cancellationToken);
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
        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetIntNullAsync(int? intQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntNullAsync(intQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNull(int? intQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntNull(intQuery, cancellationToken);
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
        /// <summary> Get &apos;null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetLongNullAsync(long? longQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLongNullAsync(longQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetLongNull(long? longQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.GetLongNull(longQuery, cancellationToken);
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
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> FloatNullAsync(float? floatQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.FloatNullAsync(floatQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatNull(float? floatQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.FloatNull(floatQuery, cancellationToken);
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
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DoubleNullAsync(double? doubleQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.DoubleNullAsync(doubleQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleNull(double? doubleQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.DoubleNull(doubleQuery, cancellationToken);
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
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> StringNullAsync(string stringQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.StringNullAsync(stringQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringNull(string stringQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.StringNull(stringQuery, cancellationToken);
        }
        /// <summary> Get using uri with query parameter &apos;green color&apos;. </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumValidAsync(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.EnumValidAsync(enumQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get using uri with query parameter &apos;green color&apos;. </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.EnumValid(enumQuery, cancellationToken);
        }
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> EnumNullAsync(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.EnumNullAsync(enumQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> &apos;green color&apos; enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor? enumQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.EnumNull(enumQuery, cancellationToken);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteMultiByteAsync(byte[] byteQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ByteMultiByteAsync(byteQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteMultiByte(byte[] byteQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ByteMultiByte(byteQuery, cancellationToken);
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
        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ByteNullAsync(byte[] byteQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ByteNullAsync(byteQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> &apos;啊齄丂狛狜隣郎隣兀﨩&apos; multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteNull(byte[] byteQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ByteNull(byteQuery, cancellationToken);
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
        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateNullAsync(DateTimeOffset? dateQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.DateNullAsync(dateQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset? dateQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.DateNull(dateQuery, cancellationToken);
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
        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DateTimeNullAsync(DateTimeOffset? dateTimeQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.DateTimeNullAsync(dateTimeQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset? dateTimeQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.DateTimeNull(dateTimeQuery, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringCsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringCsvValid(arrayQuery, cancellationToken);
        }
        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvNullAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringCsvNullAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvNull(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringCsvNull(arrayQuery, cancellationToken);
        }
        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringCsvEmptyAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringCsvEmptyAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvEmpty(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringCsvEmpty(arrayQuery, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringSsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringSsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringSsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringSsvValid(arrayQuery, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringTsvValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringTsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringTsvValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringTsvValid(arrayQuery, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringPipesValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await RestClient.ArrayStringPipesValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringPipesValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return RestClient.ArrayStringPipesValid(arrayQuery, cancellationToken);
        }
    }
}
