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
        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DictionaryWrapper>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DictionaryWrapper> GetValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetValid(cancellationToken);
        }
        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutValid(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DictionaryWrapper>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DictionaryWrapper> GetEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(cancellationToken);
        }
        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmpty(complexBody, cancellationToken);
        }
        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DictionaryWrapper>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DictionaryWrapper> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DictionaryWrapper>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNotProvidedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DictionaryWrapper> GetNotProvided(CancellationToken cancellationToken = default)
        {
            return restClient.GetNotProvided(cancellationToken);
        }
    }
}
