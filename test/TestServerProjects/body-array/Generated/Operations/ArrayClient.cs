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
        private ArrayRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ArrayClient. </summary>
        internal ArrayClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new ArrayRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(cancellationToken);
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmpty(arrayBody, cancellationToken);
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanTfftAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanTfft(cancellationToken);
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBooleanTfftAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBooleanTfft(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBooleanTfft(arrayBody, cancellationToken);
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanInvalidString(cancellationToken);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntegerValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntegerValid(cancellationToken);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutIntegerValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutIntegerValid(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutIntegerValid(arrayBody, cancellationToken);
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntInvalidNull(cancellationToken);
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntInvalidString(cancellationToken);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongValid(cancellationToken);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutLongValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLongValid(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutLongValid(arrayBody, cancellationToken);
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongInvalidNull(cancellationToken);
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongInvalidString(cancellationToken);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatValid(cancellationToken);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutFloatValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloatValid(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutFloatValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatInvalidString(cancellationToken);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleValid(cancellationToken);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDoubleValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDoubleValid(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDoubleValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleInvalidString(cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutStringValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringValid(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutStringValid(arrayBody, cancellationToken);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEnumValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<FooEnum>> GetEnumValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetEnumValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEnumValid(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutEnumValid(arrayBody, cancellationToken);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringEnumValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Enum0>> GetStringEnumValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringEnumValid(cancellationToken);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringEnumValidAsync(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutStringEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringEnumValid(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutStringEnumValid(arrayBody, cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringWithNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringWithNull(cancellationToken);
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringWithInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringWithInvalid(cancellationToken);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetUuidValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetUuidValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutUuidValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUuidValid(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutUuidValid(arrayBody, cancellationToken);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetUuidInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidInvalidChars(CancellationToken cancellationToken = default)
        {
            return restClient.GetUuidInvalidChars(cancellationToken);
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateInvalidNull(cancellationToken);
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTimeValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeInvalidNull(cancellationToken);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeRfc1123ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeRfc1123Valid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeRfc1123ValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123Valid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTimeRfc1123Valid(arrayBody, cancellationToken);
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDurationValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDurationValid(cancellationToken);
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDurationValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDurationValid(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDurationValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetByteValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetByteValid(cancellationToken);
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutByteValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByteValid(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutByteValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetByteInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetByteInvalidNull(cancellationToken);
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBase64UrlAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            return restClient.GetBase64Url(cancellationToken);
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexNull(cancellationToken);
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexEmpty(cancellationToken);
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexItemNull(cancellationToken);
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexItemEmpty(cancellationToken);
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexValid(cancellationToken);
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutComplexValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexValid(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutComplexValid(arrayBody, cancellationToken);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayNull(cancellationToken);
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayEmpty(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayItemNull(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayItemEmpty(cancellationToken);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayValid(cancellationToken);
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayValidAsync(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutArrayValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutArrayValid(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutArrayValid(arrayBody, cancellationToken);
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryNull(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryEmpty(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryItemNull(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryItemEmpty(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryValid(cancellationToken);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDictionaryValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDictionaryValid(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDictionaryValid(arrayBody, cancellationToken);
        }
    }
}
