// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using additionalProperties.Models;
using Azure;
using Azure.Core.Pipeline;

namespace additionalProperties
{
    public partial class PetsClient
    {
        internal PetsRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PetsClient. </summary>
        internal PetsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new PetsRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetAPTrue>> CreateAPTrueAsync(PetAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAPTrueAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetAPTrue> CreateAPTrue(PetAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateAPTrue(createParameters, cancellationToken);
        }
        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CatAPTrue>> CreateCatAPTrueAsync(CatAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateCatAPTrueAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CatAPTrue> CreateCatAPTrue(CatAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateCatAPTrue(createParameters, cancellationToken);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetAPObject>> CreateAPObjectAsync(PetAPObject createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAPObjectAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetAPObject> CreateAPObject(PetAPObject createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateAPObject(createParameters, cancellationToken);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetAPString>> CreateAPStringAsync(PetAPString createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAPStringAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetAPString> CreateAPString(PetAPString createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateAPString(createParameters, cancellationToken);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetAPInProperties>> CreateAPInPropertiesAsync(PetAPInProperties createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAPInPropertiesAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetAPInProperties> CreateAPInProperties(PetAPInProperties createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateAPInProperties(createParameters, cancellationToken);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInPropertiesWithAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<PetAPInPropertiesWithAPString>> CreateAPInPropertiesWithAPStringAsync(PetAPInPropertiesWithAPString createParameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAPInPropertiesWithAPStringAsync(createParameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInPropertiesWithAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PetAPInPropertiesWithAPString> CreateAPInPropertiesWithAPString(PetAPInPropertiesWithAPString createParameters, CancellationToken cancellationToken = default)
        {
            return RestClient.CreateAPInPropertiesWithAPString(createParameters, cancellationToken);
        }
    }
}
