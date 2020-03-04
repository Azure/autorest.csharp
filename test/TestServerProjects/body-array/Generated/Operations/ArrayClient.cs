// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_array.Models;

namespace body_array
{
    public partial class ArrayClient
    {
        internal ArrayRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ArrayClient. </summary>
        internal ArrayClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new ArrayRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetInvalid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEmpty(cancellationToken);
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutEmptyAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutEmpty(arrayBody, cancellationToken);
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanTfftAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanTfft(cancellationToken);
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutBooleanTfftAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBooleanTfft(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutBooleanTfft(arrayBody, cancellationToken);
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBooleanInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBooleanInvalidString(cancellationToken);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntegerValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntegerValid(cancellationToken);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutIntegerValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutIntegerValid(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutIntegerValid(arrayBody, cancellationToken);
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntInvalidNull(cancellationToken);
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetIntInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetIntInvalidString(cancellationToken);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLongValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLongValid(cancellationToken);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLongValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLongValid(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLongValid(arrayBody, cancellationToken);
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLongInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLongInvalidNull(cancellationToken);
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLongInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLongInvalidString(cancellationToken);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFloatValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFloatValid(cancellationToken);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutFloatValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloatValid(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutFloatValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFloatInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFloatInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFloatInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFloatInvalidString(cancellationToken);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDoubleValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDoubleValid(cancellationToken);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDoubleValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDoubleValid(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDoubleValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDoubleInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDoubleInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDoubleInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDoubleInvalidString(cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetStringValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetStringValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutStringValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringValid(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutStringValid(arrayBody, cancellationToken);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEnumValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<FooEnum>> GetEnumValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEnumValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEnumValid(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutEnumValid(arrayBody, cancellationToken);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetStringEnumValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Enum0>> GetStringEnumValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetStringEnumValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringEnumValidAsync(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutStringEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringEnumValid(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutStringEnumValid(arrayBody, cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetStringWithNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetStringWithNull(cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetStringWithInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetStringWithInvalid(cancellationToken);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUuidValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUuidValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUuidValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUuidValid(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUuidValid(arrayBody, cancellationToken);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUuidInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidInvalidChars(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUuidInvalidChars(cancellationToken);
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDateValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateInvalidNull(cancellationToken);
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTimeValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateTimeValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDateTimeValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTimeInvalidNull(cancellationToken);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTimeInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDateTimeRfc1123ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDateTimeRfc1123Valid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDateTimeRfc1123ValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123Valid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDateTimeRfc1123Valid(arrayBody, cancellationToken);
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDurationValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDurationValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDurationValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDurationValid(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDurationValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetByteValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetByteValid(cancellationToken);
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutByteValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByteValid(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutByteValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetByteInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetByteInvalidNull(cancellationToken);
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetBase64UrlAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            return RestClient.GetBase64Url(cancellationToken);
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetComplexNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetComplexNull(cancellationToken);
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetComplexEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetComplexEmpty(cancellationToken);
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetComplexItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetComplexItemNull(cancellationToken);
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetComplexItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetComplexItemEmpty(cancellationToken);
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetComplexValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetComplexValid(cancellationToken);
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutComplexValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexValid(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutComplexValid(arrayBody, cancellationToken);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArrayNull(cancellationToken);
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArrayEmpty(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArrayItemNull(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArrayItemEmpty(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArrayValid(cancellationToken);
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayValidAsync(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutArrayValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutArrayValid(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutArrayValid(arrayBody, cancellationToken);
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionaryNull(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionaryEmpty(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionaryItemNull(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionaryItemEmpty(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionaryValid(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDictionaryValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDictionaryValid(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDictionaryValid(arrayBody, cancellationToken);
        }
    }
}
