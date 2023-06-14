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
    /// <summary> The Queries service client. </summary>
    public partial class QueriesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal QueriesRestClient RestClient { get; }

        /// <summary> Initializes a new instance of QueriesClient for mocking. </summary>
        protected QueriesClient()
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal QueriesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new QueriesRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetBooleanTrueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanTrue");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanTrueAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetBooleanTrue(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanTrue");
            scope.Start();
            try
            {
                return RestClient.GetBooleanTrue(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetBooleanFalseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanFalse");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanFalseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetBooleanFalse(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanFalse");
            scope.Start();
            try
            {
                return RestClient.GetBooleanFalse(cancellationToken);
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
        public virtual async Task<Response> GetBooleanNullAsync(bool? boolQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanNull");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanNullAsync(boolQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response GetBooleanNull(bool? boolQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetBooleanNull");
            scope.Start();
            try
            {
                return RestClient.GetBooleanNull(boolQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetIntOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntOneMillion");
            scope.Start();
            try
            {
                return await RestClient.GetIntOneMillionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetIntOneMillion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntOneMillion");
            scope.Start();
            try
            {
                return RestClient.GetIntOneMillion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetIntNegativeOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                return await RestClient.GetIntNegativeOneMillionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetIntNegativeOneMillion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                return RestClient.GetIntNegativeOneMillion(cancellationToken);
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
        public virtual async Task<Response> GetIntNullAsync(int? intQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntNull");
            scope.Start();
            try
            {
                return await RestClient.GetIntNullAsync(intQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response GetIntNull(int? intQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetIntNull");
            scope.Start();
            try
            {
                return RestClient.GetIntNull(intQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetTenBillion");
            scope.Start();
            try
            {
                return await RestClient.GetTenBillionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetTenBillion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetTenBillion");
            scope.Start();
            try
            {
                return RestClient.GetTenBillion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetNegativeTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetNegativeTenBillion");
            scope.Start();
            try
            {
                return await RestClient.GetNegativeTenBillionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetNegativeTenBillion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetNegativeTenBillion");
            scope.Start();
            try
            {
                return RestClient.GetNegativeTenBillion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 'null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetLongNullAsync(long? longQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetLongNull");
            scope.Start();
            try
            {
                return await RestClient.GetLongNullAsync(longQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 'null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetLongNull(long? longQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.GetLongNull");
            scope.Start();
            try
            {
                return RestClient.GetLongNull(longQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '1.034E+20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> FloatScientificPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatScientificPositive");
            scope.Start();
            try
            {
                return await RestClient.FloatScientificPositiveAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '1.034E+20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response FloatScientificPositive(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatScientificPositive");
            scope.Start();
            try
            {
                return RestClient.FloatScientificPositive(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-1.034E-20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> FloatScientificNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatScientificNegative");
            scope.Start();
            try
            {
                return await RestClient.FloatScientificNegativeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-1.034E-20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response FloatScientificNegative(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatScientificNegative");
            scope.Start();
            try
            {
                return RestClient.FloatScientificNegative(cancellationToken);
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
        public virtual async Task<Response> FloatNullAsync(float? floatQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatNull");
            scope.Start();
            try
            {
                return await RestClient.FloatNullAsync(floatQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response FloatNull(float? floatQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.FloatNull");
            scope.Start();
            try
            {
                return RestClient.FloatNull(floatQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DoubleDecimalPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleDecimalPositive");
            scope.Start();
            try
            {
                return await RestClient.DoubleDecimalPositiveAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DoubleDecimalPositive(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleDecimalPositive");
            scope.Start();
            try
            {
                return RestClient.DoubleDecimalPositive(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DoubleDecimalNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleDecimalNegative");
            scope.Start();
            try
            {
                return await RestClient.DoubleDecimalNegativeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '-9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DoubleDecimalNegative(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleDecimalNegative");
            scope.Start();
            try
            {
                return RestClient.DoubleDecimalNegative(cancellationToken);
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
        public virtual async Task<Response> DoubleNullAsync(double? doubleQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleNull");
            scope.Start();
            try
            {
                return await RestClient.DoubleNullAsync(doubleQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response DoubleNull(double? doubleQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DoubleNull");
            scope.Start();
            try
            {
                return RestClient.DoubleNull(doubleQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> StringUnicodeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringUnicode");
            scope.Start();
            try
            {
                return await RestClient.StringUnicodeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response StringUnicode(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringUnicode");
            scope.Start();
            try
            {
                return RestClient.StringUnicode(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 'begin!*'();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> StringUrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringUrlEncoded");
            scope.Start();
            try
            {
                return await RestClient.StringUrlEncodedAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 'begin!*'();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response StringUrlEncoded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringUrlEncoded");
            scope.Start();
            try
            {
                return RestClient.StringUrlEncoded(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> StringEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringEmpty");
            scope.Start();
            try
            {
                return await RestClient.StringEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response StringEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringEmpty");
            scope.Start();
            try
            {
                return RestClient.StringEmpty(cancellationToken);
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
        public virtual async Task<Response> StringNullAsync(string stringQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringNull");
            scope.Start();
            try
            {
                return await RestClient.StringNullAsync(stringQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response StringNull(string stringQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.StringNull");
            scope.Start();
            try
            {
                return RestClient.StringNull(stringQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get using uri with query parameter 'green color'. </summary>
        /// <param name="enumQuery"> 'green color' enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> EnumValidAsync(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.EnumValid");
            scope.Start();
            try
            {
                return await RestClient.EnumValidAsync(enumQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get using uri with query parameter 'green color'. </summary>
        /// <param name="enumQuery"> 'green color' enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response EnumValid(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.EnumValid");
            scope.Start();
            try
            {
                return RestClient.EnumValid(enumQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> EnumNullAsync(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.EnumNull");
            scope.Start();
            try
            {
                return await RestClient.EnumNullAsync(enumQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response EnumNull(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.EnumNull");
            scope.Start();
            try
            {
                return RestClient.EnumNull(enumQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ByteMultiByteAsync(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteMultiByte");
            scope.Start();
            try
            {
                return await RestClient.ByteMultiByteAsync(byteQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ByteMultiByte(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteMultiByte");
            scope.Start();
            try
            {
                return RestClient.ByteMultiByte(byteQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '' as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ByteEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteEmpty");
            scope.Start();
            try
            {
                return await RestClient.ByteEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '' as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ByteEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteEmpty");
            scope.Start();
            try
            {
                return RestClient.ByteEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ByteNullAsync(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteNull");
            scope.Start();
            try
            {
                return await RestClient.ByteNullAsync(byteQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ByteNull(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ByteNull");
            scope.Start();
            try
            {
                return RestClient.ByteNull(byteQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '2012-01-01' as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DateValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateValid");
            scope.Start();
            try
            {
                return await RestClient.DateValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '2012-01-01' as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DateValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateValid");
            scope.Start();
            try
            {
                return RestClient.DateValid(cancellationToken);
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
        public virtual async Task<Response> DateNullAsync(DateTimeOffset? dateQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateNull");
            scope.Start();
            try
            {
                return await RestClient.DateNullAsync(dateQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response DateNull(DateTimeOffset? dateQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateNull");
            scope.Start();
            try
            {
                return RestClient.DateNull(dateQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '2012-01-01T01:01:01Z' as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateTimeValid");
            scope.Start();
            try
            {
                return await RestClient.DateTimeValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get '2012-01-01T01:01:01Z' as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DateTimeValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateTimeValid");
            scope.Start();
            try
            {
                return RestClient.DateTimeValid(cancellationToken);
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
        public virtual async Task<Response> DateTimeNullAsync(DateTimeOffset? dateTimeQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateTimeNull");
            scope.Start();
            try
            {
                return await RestClient.DateTimeNullAsync(dateTimeQuery, cancellationToken).ConfigureAwait(false);
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
        public virtual Response DateTimeNull(DateTimeOffset? dateTimeQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.DateTimeNull");
            scope.Start();
            try
            {
                return RestClient.DateTimeNull(dateTimeQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringCsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvValid");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringCsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringCsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvValid");
            scope.Start();
            try
            {
                return RestClient.ArrayStringCsvValid(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringCsvNullAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvNull");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringCsvNullAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringCsvNull(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvNull");
            scope.Start();
            try
            {
                return RestClient.ArrayStringCsvNull(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringCsvEmptyAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringCsvEmptyAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringCsvEmpty(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                return RestClient.ArrayStringCsvEmpty(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service. </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringNoCollectionFormatEmptyAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringNoCollectionFormatEmpty");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringNoCollectionFormatEmptyAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service. </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringNoCollectionFormatEmpty(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringNoCollectionFormatEmpty");
            scope.Start();
            try
            {
                return RestClient.ArrayStringNoCollectionFormatEmpty(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringSsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringSsvValid");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringSsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringSsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringSsvValid");
            scope.Start();
            try
            {
                return RestClient.ArrayStringSsvValid(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringTsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringTsvValid");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringTsvValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringTsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringTsvValid");
            scope.Start();
            try
            {
                return RestClient.ArrayStringTsvValid(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ArrayStringPipesValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringPipesValid");
            scope.Start();
            try
            {
                return await RestClient.ArrayStringPipesValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ArrayStringPipesValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringPipesValid");
            scope.Start();
            try
            {
                return RestClient.ArrayStringPipesValid(arrayQuery, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
