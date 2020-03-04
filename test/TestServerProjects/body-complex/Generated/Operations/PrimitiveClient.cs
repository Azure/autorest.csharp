// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    public partial class PrimitiveClient
    {
        internal PrimitiveRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PrimitiveClient. </summary>
        internal PrimitiveClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new PrimitiveRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IntWrapper>> GetIntAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IntWrapper> GetInt(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInt(cancellationToken);
        }
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntAsync(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutIntAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutInt(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutInt(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<LongWrapper>> GetLongAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLongAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<LongWrapper> GetLong(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLong(cancellationToken);
        }
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongAsync(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLongAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLong(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLong(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<FloatWrapper>> GetFloatAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFloatAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<FloatWrapper> GetFloat(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFloat(cancellationToken);
        }
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatAsync(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutFloatAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloat(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutFloat(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DoubleWrapper>> GetDoubleAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDoubleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DoubleWrapper> GetDouble(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDouble(cancellationToken);
        }
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleAsync(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDoubleAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDouble(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDouble(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<BooleanWrapper>> GetBoolAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBoolAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<BooleanWrapper> GetBool(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBool(cancellationToken);
        }
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBoolAsync(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutBoolAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBool(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutBool(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<StringWrapper>> GetStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StringWrapper> GetString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetString(cancellationToken);
        }
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringAsync(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutStringAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutString(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutString(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateWrapper>> GetDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateWrapper> GetDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDate(cancellationToken);
        }
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateAsync(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDate(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDate(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DatetimeWrapper>> GetDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DatetimeWrapper> GetDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTime(cancellationToken);
        }
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeAsync(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateTimeAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTime(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDateTime(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeRfc1123Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Datetimerfc1123Wrapper> GetDateTimeRfc1123(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTimeRfc1123(cancellationToken);
        }
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123Async(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateTimeRfc1123Async(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDateTimeRfc1123(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DurationWrapper>> GetDurationAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDurationAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DurationWrapper> GetDuration(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDuration(cancellationToken);
        }
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationAsync(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDurationAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDuration(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDuration(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ByteWrapper>> GetByteAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetByteAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ByteWrapper> GetByte(CancellationToken cancellationToken = default)
        {
            return RestClient.GetByte(cancellationToken);
        }
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteAsync(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutByteAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByte(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutByte(complexBody, cancellationToken);
        }
    }
}
