// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    /// <summary> The Primitive service client. </summary>
    public partial class PrimitiveClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PrimitiveRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PrimitiveClient for mocking. </summary>
        protected PrimitiveClient()
        {
        }

        /// <summary> Initializes a new instance of PrimitiveClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal PrimitiveClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new PrimitiveRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IntWrapper>> GetIntAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetInt");
            scope.Start();
            try
            {
                return await RestClient.GetIntAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IntWrapper> GetInt(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetInt");
            scope.Start();
            try
            {
                return RestClient.GetInt(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutIntAsync(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutInt");
            scope.Start();
            try
            {
                return await RestClient.PutIntAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutInt(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutInt");
            scope.Start();
            try
            {
                return RestClient.PutInt(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LongWrapper>> GetLongAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetLong");
            scope.Start();
            try
            {
                return await RestClient.GetLongAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LongWrapper> GetLong(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetLong");
            scope.Start();
            try
            {
                return RestClient.GetLong(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLongAsync(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutLong");
            scope.Start();
            try
            {
                return await RestClient.PutLongAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLong(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutLong");
            scope.Start();
            try
            {
                return RestClient.PutLong(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FloatWrapper>> GetFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetFloat");
            scope.Start();
            try
            {
                return await RestClient.GetFloatAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FloatWrapper> GetFloat(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetFloat");
            scope.Start();
            try
            {
                return RestClient.GetFloat(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutFloatAsync(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutFloat");
            scope.Start();
            try
            {
                return await RestClient.PutFloatAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutFloat(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutFloat");
            scope.Start();
            try
            {
                return RestClient.PutFloat(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DoubleWrapper>> GetDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDouble");
            scope.Start();
            try
            {
                return await RestClient.GetDoubleAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DoubleWrapper> GetDouble(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDouble");
            scope.Start();
            try
            {
                return RestClient.GetDouble(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDoubleAsync(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDouble");
            scope.Start();
            try
            {
                return await RestClient.PutDoubleAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDouble(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDouble");
            scope.Start();
            try
            {
                return RestClient.PutDouble(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BooleanWrapper>> GetBoolAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetBool");
            scope.Start();
            try
            {
                return await RestClient.GetBoolAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BooleanWrapper> GetBool(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetBool");
            scope.Start();
            try
            {
                return RestClient.GetBool(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBoolAsync(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutBool");
            scope.Start();
            try
            {
                return await RestClient.PutBoolAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBool(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutBool");
            scope.Start();
            try
            {
                return RestClient.PutBool(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StringWrapper>> GetStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetString");
            scope.Start();
            try
            {
                return await RestClient.GetStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StringWrapper> GetString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetString");
            scope.Start();
            try
            {
                return RestClient.GetString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put 'goodrequest', '', and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutStringAsync(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutString");
            scope.Start();
            try
            {
                return await RestClient.PutStringAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put 'goodrequest', '', and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutString(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutString");
            scope.Start();
            try
            {
                return RestClient.PutString(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateWrapper>> GetDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDate");
            scope.Start();
            try
            {
                return await RestClient.GetDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateWrapper> GetDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDate");
            scope.Start();
            try
            {
                return RestClient.GetDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put '0001-01-01' and '2016-02-29'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateAsync(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDate");
            scope.Start();
            try
            {
                return await RestClient.PutDateAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put '0001-01-01' and '2016-02-29'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDate(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDate");
            scope.Start();
            try
            {
                return RestClient.PutDate(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DatetimeWrapper>> GetDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DatetimeWrapper> GetDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDateTime");
            scope.Start();
            try
            {
                return RestClient.GetDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put '0001-01-01T12:00:00-04:00' and '2015-05-18T11:38:00-08:00'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeAsync(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutDateTimeAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put '0001-01-01T12:00:00-04:00' and '2015-05-18T11:38:00-08:00'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTime(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDateTime");
            scope.Start();
            try
            {
                return RestClient.PutDateTime(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDateTimeRfc1123");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeRfc1123Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Datetimerfc1123Wrapper> GetDateTimeRfc1123(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDateTimeRfc1123");
            scope.Start();
            try
            {
                return RestClient.GetDateTimeRfc1123(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put 'Mon, 01 Jan 0001 12:00:00 GMT' and 'Mon, 18 May 2015 11:38:00 GMT'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeRfc1123Async(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDateTimeRfc1123");
            scope.Start();
            try
            {
                return await RestClient.PutDateTimeRfc1123Async(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put 'Mon, 01 Jan 0001 12:00:00 GMT' and 'Mon, 18 May 2015 11:38:00 GMT'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTimeRfc1123(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDateTimeRfc1123");
            scope.Start();
            try
            {
                return RestClient.PutDateTimeRfc1123(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DurationWrapper>> GetDurationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDuration");
            scope.Start();
            try
            {
                return await RestClient.GetDurationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DurationWrapper> GetDuration(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetDuration");
            scope.Start();
            try
            {
                return RestClient.GetDuration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put 'P123DT22H14M12.011S'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDurationAsync(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDuration");
            scope.Start();
            try
            {
                return await RestClient.PutDurationAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put 'P123DT22H14M12.011S'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDuration(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutDuration");
            scope.Start();
            try
            {
                return RestClient.PutDuration(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ByteWrapper>> GetByteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetByte");
            scope.Start();
            try
            {
                return await RestClient.GetByteAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ByteWrapper> GetByte(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.GetByte");
            scope.Start();
            try
            {
                return RestClient.GetByte(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutByteAsync(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutByte");
            scope.Start();
            try
            {
                return await RestClient.PutByteAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutByte(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PrimitiveClient.PutByte");
            scope.Start();
            try
            {
                return RestClient.PutByte(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
