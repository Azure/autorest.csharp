// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_dictionary.Models;

namespace body_dictionary
{
    public partial class DictionaryClient
    {
        private DictionaryRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of DictionaryClient. </summary>
        internal DictionaryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new DictionaryRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, int>> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get empty dictionary value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty dictionary value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, int>> GetEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(cancellationToken);
        }
        /// <summary> Set dictionary value empty {}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value empty {}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmpty(arrayBody, cancellationToken);
        }
        /// <summary> Get Dictionary with null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetNullValueAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullValueAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get Dictionary with null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetNullValue(CancellationToken cancellationToken = default)
        {
            return restClient.GetNullValue(cancellationToken);
        }
        /// <summary> Get Dictionary with null key. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetNullKeyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullKeyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get Dictionary with null key. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetNullKey(CancellationToken cancellationToken = default)
        {
            return restClient.GetNullKey(cancellationToken);
        }
        /// <summary> Get Dictionary with key as empty string. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetEmptyStringKeyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyStringKeyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get Dictionary with key as empty string. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetEmptyStringKey(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmptyStringKey(cancellationToken);
        }
        /// <summary> Get invalid Dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid Dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: true, &quot;1&quot;: false, &quot;2&quot;: false, &quot;3&quot;: true }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanTfftAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: true, &quot;1&quot;: false, &quot;2&quot;: false, &quot;3&quot;: true }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanTfft(cancellationToken);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: true, &quot;1&quot;: false, &quot;2&quot;: false, &quot;3&quot;: true }. </summary>
        /// <param name="arrayBody"> The DictionaryOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBooleanTfftAsync(IDictionary<string, bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBooleanTfftAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: true, &quot;1&quot;: false, &quot;2&quot;: false, &quot;3&quot;: true }. </summary>
        /// <param name="arrayBody"> The DictionaryOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBooleanTfft(IDictionary<string, bool> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBooleanTfft(arrayBody, cancellationToken);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: true, &quot;1&quot;: null, &quot;2&quot;: false }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: true, &quot;1&quot;: null, &quot;2&quot;: false }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean dictionary value &apos;{&quot;0&quot;: true, &quot;1&quot;: &quot;boolean&quot;, &quot;2&quot;: false}&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBooleanInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean dictionary value &apos;{&quot;0&quot;: true, &quot;1&quot;: &quot;boolean&quot;, &quot;2&quot;: false}&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetBooleanInvalidString(cancellationToken);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntegerValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntegerValid(cancellationToken);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntegerValidAsync(IDictionary<string, int> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutIntegerValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutIntegerValid(IDictionary<string, int> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutIntegerValid(arrayBody, cancellationToken);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: null, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: null, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntInvalidNull(cancellationToken);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: &quot;integer&quot;, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetIntInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: &quot;integer&quot;, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetIntInvalidString(cancellationToken);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongValid(cancellationToken);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongValidAsync(IDictionary<string, long> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutLongValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: 1, &quot;1&quot;: -1, &quot;2&quot;: 3, &quot;3&quot;: 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLongValid(IDictionary<string, long> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutLongValid(arrayBody, cancellationToken);
        }
        /// <summary> Get long dictionary value {&quot;0&quot;: 1, &quot;1&quot;: null, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long dictionary value {&quot;0&quot;: 1, &quot;1&quot;: null, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongInvalidNull(cancellationToken);
        }
        /// <summary> Get long dictionary value {&quot;0&quot;: 1, &quot;1&quot;: &quot;integer&quot;, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetLongInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get long dictionary value {&quot;0&quot;: 1, &quot;1&quot;: &quot;integer&quot;, &quot;2&quot;: 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetLongInvalidString(cancellationToken);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatValid(cancellationToken);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatValidAsync(IDictionary<string, float> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutFloatValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloatValid(IDictionary<string, float> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutFloatValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0.0, &quot;1&quot;: null, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0.0, &quot;1&quot;: null, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: 1.0, &quot;1&quot;: &quot;number&quot;, &quot;2&quot;: 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFloatInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: 1.0, &quot;1&quot;: &quot;number&quot;, &quot;2&quot;: 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetFloatInvalidString(cancellationToken);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleValid(cancellationToken);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleValidAsync(IDictionary<string, double> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDoubleValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: 0, &quot;1&quot;: -0.01, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDoubleValid(IDictionary<string, double> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDoubleValid(arrayBody, cancellationToken);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0.0, &quot;1&quot;: null, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get float dictionary value {&quot;0&quot;: 0.0, &quot;1&quot;: null, &quot;2&quot;: 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleInvalidNull(cancellationToken);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: 1.0, &quot;1&quot;: &quot;number&quot;, &quot;2&quot;: 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDoubleInvalidStringAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get boolean dictionary value {&quot;0&quot;: 1.0, &quot;1&quot;: &quot;number&quot;, &quot;2&quot;: 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            return restClient.GetDoubleInvalidString(cancellationToken);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo1&quot;, &quot;1&quot;: &quot;foo2&quot;, &quot;2&quot;: &quot;foo3&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo1&quot;, &quot;1&quot;: &quot;foo2&quot;, &quot;2&quot;: &quot;foo3&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringValid(cancellationToken);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: &quot;foo1&quot;, &quot;1&quot;: &quot;foo2&quot;, &quot;2&quot;: &quot;foo3&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringValidAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutStringValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value {&quot;0&quot;: &quot;foo1&quot;, &quot;1&quot;: &quot;foo2&quot;, &quot;2&quot;: &quot;foo3&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringValid(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutStringValid(arrayBody, cancellationToken);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo&quot;, &quot;1&quot;: null, &quot;2&quot;: &quot;foo2&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringWithNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo&quot;, &quot;1&quot;: null, &quot;2&quot;: &quot;foo2&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringWithNull(cancellationToken);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo&quot;, &quot;1&quot;: 123, &quot;2&quot;: &quot;foo2&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetStringWithInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string dictionary value {&quot;0&quot;: &quot;foo&quot;, &quot;1&quot;: 123, &quot;2&quot;: &quot;foo2&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetStringWithInvalid(cancellationToken);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: &quot;2000-12-01&quot;, &quot;1&quot;: &quot;1980-01-02&quot;, &quot;2&quot;: &quot;1492-10-12&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get integer dictionary value {&quot;0&quot;: &quot;2000-12-01&quot;, &quot;1&quot;: &quot;1980-01-02&quot;, &quot;2&quot;: &quot;1492-10-12&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateValid(cancellationToken);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;2000-12-01&quot;, &quot;1&quot;: &quot;1980-01-02&quot;, &quot;2&quot;: &quot;1492-10-12&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;2000-12-01&quot;, &quot;1&quot;: &quot;1980-01-02&quot;, &quot;2&quot;: &quot;1492-10-12&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateValid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2012-01-01&quot;, &quot;1&quot;: null, &quot;2&quot;: &quot;1776-07-04&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2012-01-01&quot;, &quot;1&quot;: null, &quot;2&quot;: &quot;1776-07-04&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateInvalidNull(cancellationToken);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2011-03-22&quot;, &quot;1&quot;: &quot;date&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2011-03-22&quot;, &quot;1&quot;: &quot;date&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;1980-01-02T00:11:35+01:00&quot;, &quot;2&quot;: &quot;1492-10-12T10:15:01-08:00&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;1980-01-02T00:11:35+01:00&quot;, &quot;2&quot;: &quot;1492-10-12T10:15:01-08:00&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeValid(cancellationToken);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;1980-01-02T00:11:35+01:00&quot;, &quot;2&quot;: &quot;1492-10-12T10:15:01-08:00&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;1980-01-02T00:11:35+01:00&quot;, &quot;2&quot;: &quot;1492-10-12T10:15:01-08:00&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeValid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTimeValid(arrayBody, cancellationToken);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: null}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: null}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeInvalidNull(cancellationToken);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;date-time&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date dictionary value {&quot;0&quot;: &quot;2000-12-01t00:00:01z&quot;, &quot;1&quot;: &quot;date-time&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeInvalidChars(cancellationToken);
        }
        /// <summary> Get date-time-rfc1123 dictionary value {&quot;0&quot;: &quot;Fri, 01 Dec 2000 00:00:01 GMT&quot;, &quot;1&quot;: &quot;Wed, 02 Jan 1980 00:11:35 GMT&quot;, &quot;2&quot;: &quot;Wed, 12 Oct 1492 10:15:01 GMT&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDateTimeRfc1123ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get date-time-rfc1123 dictionary value {&quot;0&quot;: &quot;Fri, 01 Dec 2000 00:00:01 GMT&quot;, &quot;1&quot;: &quot;Wed, 02 Jan 1980 00:11:35 GMT&quot;, &quot;2&quot;: &quot;Wed, 12 Oct 1492 10:15:01 GMT&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDateTimeRfc1123Valid(cancellationToken);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: &quot;Fri, 01 Dec 2000 00:00:01 GMT&quot;, &quot;1&quot;: &quot;Wed, 02 Jan 1980 00:11:35 GMT&quot;, &quot;2&quot;: &quot;Wed, 12 Oct 1492 10:15:01 GMT&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDateTimeRfc1123ValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value empty {&quot;0&quot;: &quot;Fri, 01 Dec 2000 00:00:01 GMT&quot;, &quot;1&quot;: &quot;Wed, 02 Jan 1980 00:11:35 GMT&quot;, &quot;2&quot;: &quot;Wed, 12 Oct 1492 10:15:01 GMT&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123Valid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDateTimeRfc1123Valid(arrayBody, cancellationToken);
        }
        /// <summary> Get duration dictionary value {&quot;0&quot;: &quot;P123DT22H14M12.011S&quot;, &quot;1&quot;: &quot;P5DT1H0M0S&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDurationValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get duration dictionary value {&quot;0&quot;: &quot;P123DT22H14M12.011S&quot;, &quot;1&quot;: &quot;P5DT1H0M0S&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDurationValid(cancellationToken);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;P123DT22H14M12.011S&quot;, &quot;1&quot;: &quot;P5DT1H0M0S&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationValidAsync(IDictionary<string, TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDurationValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set dictionary value  {&quot;0&quot;: &quot;P123DT22H14M12.011S&quot;, &quot;1&quot;: &quot;P5DT1H0M0S&quot;}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDurationValid(IDictionary<string, TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDurationValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: hex(01 02 03), &quot;2&quot;: hex (25, 29, 43)} with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetByteValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: hex(01 02 03), &quot;2&quot;: hex (25, 29, 43)} with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetByteValid(cancellationToken);
        }
        /// <summary> Put the dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: hex(01 02 03), &quot;2&quot;: hex (25, 29, 43)} with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The DictionaryOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteValidAsync(IDictionary<string, byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutByteValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put the dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: hex(01 02 03), &quot;2&quot;: hex (25, 29, 43)} with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The DictionaryOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByteValid(IDictionary<string, byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutByteValid(arrayBody, cancellationToken);
        }
        /// <summary> Get byte dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: null} with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetByteInvalidNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get byte dictionary value {&quot;0&quot;: hex(FF FF FF FA), &quot;1&quot;: null} with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetByteInvalidNull(cancellationToken);
        }
        /// <summary> Get base64url dictionary value {&quot;0&quot;: &quot;a string that gets encoded with base64url&quot;, &quot;1&quot;: &quot;test string&quot;, &quot;2&quot;: &quot;Lorem ipsum&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBase64UrlAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get base64url dictionary value {&quot;0&quot;: &quot;a string that gets encoded with base64url&quot;, &quot;1&quot;: &quot;test string&quot;, &quot;2&quot;: &quot;Lorem ipsum&quot;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            return restClient.GetBase64Url(cancellationToken);
        }
        /// <summary> Get dictionary of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get dictionary of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, Widget>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexNull(cancellationToken);
        }
        /// <summary> Get empty dictionary of complex type {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty dictionary of complex type {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, Widget>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexEmpty(cancellationToken);
        }
        /// <summary> Get dictionary of complex type with null item {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: null, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get dictionary of complex type with null item {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: null, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, Widget>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexItemNull(cancellationToken);
        }
        /// <summary> Get dictionary of complex type with empty item {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1:&quot; {}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get dictionary of complex type with empty item {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1:&quot; {}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, Widget>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexItemEmpty(cancellationToken);
        }
        /// <summary> Get dictionary of complex type with {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: {&quot;integer&quot;: 3, &quot;string&quot;: &quot;4&quot;}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, Widget>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get dictionary of complex type with {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: {&quot;integer&quot;: 3, &quot;string&quot;: &quot;4&quot;}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, Widget>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexValid(cancellationToken);
        }
        /// <summary> Put an dictionary of complex type with values {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: {&quot;integer&quot;: 3, &quot;string&quot;: &quot;4&quot;}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfWidget to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexValidAsync(IDictionary<string, Widget> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutComplexValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put an dictionary of complex type with values {&quot;0&quot;: {&quot;integer&quot;: 1, &quot;string&quot;: &quot;2&quot;}, &quot;1&quot;: {&quot;integer&quot;: 3, &quot;string&quot;: &quot;4&quot;}, &quot;2&quot;: {&quot;integer&quot;: 5, &quot;string&quot;: &quot;6&quot;}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfWidget to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexValid(IDictionary<string, Widget> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutComplexValid(arrayBody, cancellationToken);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, ICollection<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayNull(cancellationToken);
        }
        /// <summary> Get an empty dictionary {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty dictionary {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, ICollection<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayEmpty(cancellationToken);
        }
        /// <summary> Get an dictionary of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: null, &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionary of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: null, &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, ICollection<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayItemNull(cancellationToken);
        }
        /// <summary> Get an array of array of strings [{&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings [{&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, ICollection<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayItemEmpty(cancellationToken);
        }
        /// <summary> Get an array of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [&quot;4&quot;, &quot;5&quot;, &quot;6&quot;], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [&quot;4&quot;, &quot;5&quot;, &quot;6&quot;], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, ICollection<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetArrayValid(cancellationToken);
        }
        /// <summary> Put An array of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [&quot;4&quot;, &quot;5&quot;, &quot;6&quot;], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="arrayBody"> The DictionaryOfpaths1Dxz488DictionaryArrayValidPutRequestbodyContentApplicationJsonSchemaAdditionalproperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayValidAsync(IDictionary<string, ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutArrayValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put An array of array of strings {&quot;0&quot;: [&quot;1&quot;, &quot;2&quot;, &quot;3&quot;], &quot;1&quot;: [&quot;4&quot;, &quot;5&quot;, &quot;6&quot;], &quot;2&quot;: [&quot;7&quot;, &quot;8&quot;, &quot;9&quot;]}. </summary>
        /// <param name="arrayBody"> The DictionaryOfpaths1Dxz488DictionaryArrayValidPutRequestbodyContentApplicationJsonSchemaAdditionalproperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutArrayValid(IDictionary<string, ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutArrayValid(arrayBody, cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryNull(cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryEmpty(cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: null, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryItemNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: null, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryItemNull(cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryItemEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryItemEmpty(cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {&quot;4&quot;: &quot;four&quot;, &quot;5&quot;: &quot;five&quot;, &quot;6&quot;: &quot;six&quot;}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {&quot;4&quot;: &quot;four&quot;, &quot;5&quot;: &quot;five&quot;, &quot;6&quot;: &quot;six&quot;}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionaryValid(cancellationToken);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {&quot;4&quot;: &quot;four&quot;, &quot;5&quot;: &quot;five&quot;, &quot;6&quot;: &quot;six&quot;}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfany to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryValidAsync(IDictionary<string, object> arrayBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDictionaryValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {&quot;0&quot;: {&quot;1&quot;: &quot;one&quot;, &quot;2&quot;: &quot;two&quot;, &quot;3&quot;: &quot;three&quot;}, &quot;1&quot;: {&quot;4&quot;: &quot;four&quot;, &quot;5&quot;: &quot;five&quot;, &quot;6&quot;: &quot;six&quot;}, &quot;2&quot;: {&quot;7&quot;: &quot;seven&quot;, &quot;8&quot;: &quot;eight&quot;, &quot;9&quot;: &quot;nine&quot;}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfany to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDictionaryValid(IDictionary<string, object> arrayBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutDictionaryValid(arrayBody, cancellationToken);
        }
    }
}
