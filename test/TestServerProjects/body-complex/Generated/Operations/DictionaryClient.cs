// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        private readonly ClientDiagnostics clientDiagnostics;
        private readonly HttpPipeline pipeline;
        internal DictionaryRestClient RestClient { get; }
        /// <summary> Initializes a new instance of DictionaryClient for mocking. </summary>
        protected DictionaryClient()
        {
        }
        /// <summary> Initializes a new instance of DictionaryClient. </summary>
        internal DictionaryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new DictionaryRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetValid(cancellationToken);
        }

        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutValidAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutValid(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutValid(complexBody, cancellationToken);
        }

        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEmpty(cancellationToken);
        }

        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutEmptyAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmpty(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutEmpty(complexBody, cancellationToken);
        }

        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }

        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNotProvidedAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetNotProvided(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNotProvided(cancellationToken);
        }
    }
}
