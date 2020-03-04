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
        private PrimitiveRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PrimitiveClient. </summary>
        internal PrimitiveClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new PrimitiveRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IntWrapper>> GetIntAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with integer properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IntWrapper> GetInt(CancellationToken cancellationToken = default)
        {
            return restClient.GetInt(cancellationToken);
        }
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntAsync(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutIntAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with integer properties. </summary>
        /// <param name="complexBody"> Please put -1 and 2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutInt(IntWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutInt(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<LongWrapper>> GetLongAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with long properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<LongWrapper> GetLong(CancellationToken cancellationToken = default)
        {
            return restClient.GetLong(cancellationToken);
        }
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongAsync(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutLongAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with long properties. </summary>
        /// <param name="complexBody"> Please put 1099511627775 and -999511627788. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLong(LongWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutLong(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<FloatWrapper>> GetFloatAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with float properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<FloatWrapper> GetFloat(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloat(cancellationToken);
        }
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatAsync(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutFloatAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with float properties. </summary>
        /// <param name="complexBody"> Please put 1.05 and -0.003. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloat(FloatWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutFloat(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DoubleWrapper>> GetDoubleAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with double properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DoubleWrapper> GetDouble(CancellationToken cancellationToken = default)
        {
            return restClient.GetDouble(cancellationToken);
        }
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleAsync(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDoubleAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with double properties. </summary>
        /// <param name="complexBody"> Please put 3e-100 and -0.000000000000000000000000000000000000000000000000000000005. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDouble(DoubleWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDouble(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<BooleanWrapper>> GetBoolAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBoolAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with bool properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<BooleanWrapper> GetBool(CancellationToken cancellationToken = default)
        {
            return restClient.GetBool(cancellationToken);
        }
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBoolAsync(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBoolAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with bool properties. </summary>
        /// <param name="complexBody"> Please put true and false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBool(BooleanWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBool(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<StringWrapper>> GetStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with string properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StringWrapper> GetString(CancellationToken cancellationToken = default)
        {
            return restClient.GetString(cancellationToken);
        }
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringAsync(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutStringAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with string properties. </summary>
        /// <param name="complexBody"> Please put &apos;goodrequest&apos;, &apos;&apos;, and null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutString(StringWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutString(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateWrapper>> GetDateAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with date properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateWrapper> GetDate(CancellationToken cancellationToken = default)
        {
            return restClient.GetDate(cancellationToken);
        }
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateAsync(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with date properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01&apos; and &apos;2016-02-29&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDate(DateWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDate(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DatetimeWrapper>> GetDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with datetime properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DatetimeWrapper> GetDateTime(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTime(cancellationToken);
        }
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeAsync(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with datetime properties. </summary>
        /// <param name="complexBody"> Please put &apos;0001-01-01T12:00:00-04:00&apos; and &apos;2015-05-18T11:38:00-08:00&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTime(DatetimeWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTime(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Datetimerfc1123Wrapper>> GetDateTimeRfc1123Async(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeRfc1123Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with datetimeRfc1123 properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Datetimerfc1123Wrapper> GetDateTimeRfc1123(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeRfc1123(cancellationToken);
        }
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123Async(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeRfc1123Async(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with datetimeRfc1123 properties. </summary>
        /// <param name="complexBody"> Please put &apos;Mon, 01 Jan 0001 12:00:00 GMT&apos; and &apos;Mon, 18 May 2015 11:38:00 GMT&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123(Datetimerfc1123Wrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTimeRfc1123(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DurationWrapper>> GetDurationAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDurationAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with duration properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DurationWrapper> GetDuration(CancellationToken cancellationToken = default)
        {
            return restClient.GetDuration(cancellationToken);
        }
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationAsync(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDurationAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with duration properties. </summary>
        /// <param name="complexBody"> Please put &apos;P123DT22H14M12.011S&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDuration(DurationWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDuration(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ByteWrapper>> GetByteAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetByteAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with byte properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ByteWrapper> GetByte(CancellationToken cancellationToken = default)
        {
            return restClient.GetByte(cancellationToken);
        }
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteAsync(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutByteAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with byte properties. </summary>
        /// <param name="complexBody"> Please put non-ascii byte string hex(FF FE FD FC 00 FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByte(ByteWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutByte(complexBody, cancellationToken);
        }
    }
}
