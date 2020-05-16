// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using additionalProperties.Models;
using Azure;
using Azure.Core.Pipeline;

namespace additionalProperties
{
    /// <summary> The Pets service client. </summary>
    public partial class PetsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PetsRestClient RestClient { get; }
        /// <summary> Initializes a new instance of PetsClient for mocking. </summary>
        protected PetsClient()
        {
        }
        /// <summary> Initializes a new instance of PetsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal PetsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new PetsRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PetAPTrue>> CreateAPTrueAsync(PetAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPTrue");
            scope.Start();
            try
            {
                return await RestClient.CreateAPTrueAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PetAPTrue> CreateAPTrue(PetAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPTrue");
            scope.Start();
            try
            {
                return RestClient.CreateAPTrue(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CatAPTrue>> CreateCatAPTrueAsync(CatAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateCatAPTrue");
            scope.Start();
            try
            {
                return await RestClient.CreateCatAPTrueAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a CatAPTrue which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The CatAPTrue to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CatAPTrue> CreateCatAPTrue(CatAPTrue createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateCatAPTrue");
            scope.Start();
            try
            {
                return RestClient.CreateCatAPTrue(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PetAPObject>> CreateAPObjectAsync(PetAPObject createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPObject");
            scope.Start();
            try
            {
                return await RestClient.CreateAPObjectAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPObject to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PetAPObject> CreateAPObject(PetAPObject createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPObject");
            scope.Start();
            try
            {
                return RestClient.CreateAPObject(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PetAPString>> CreateAPStringAsync(PetAPString createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPString");
            scope.Start();
            try
            {
                return await RestClient.CreateAPStringAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PetAPString> CreateAPString(PetAPString createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPString");
            scope.Start();
            try
            {
                return RestClient.CreateAPString(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PetAPInProperties>> CreateAPInPropertiesAsync(PetAPInProperties createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPInProperties");
            scope.Start();
            try
            {
                return await RestClient.CreateAPInPropertiesAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PetAPInProperties> CreateAPInProperties(PetAPInProperties createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPInProperties");
            scope.Start();
            try
            {
                return RestClient.CreateAPInProperties(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInPropertiesWithAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PetAPInPropertiesWithAPString>> CreateAPInPropertiesWithAPStringAsync(PetAPInPropertiesWithAPString createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPInPropertiesWithAPString");
            scope.Start();
            try
            {
                return await RestClient.CreateAPInPropertiesWithAPStringAsync(createParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a Pet which contains more properties than what is defined. </summary>
        /// <param name="createParameters"> The PetAPInPropertiesWithAPString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PetAPInPropertiesWithAPString> CreateAPInPropertiesWithAPString(PetAPInPropertiesWithAPString createParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetsClient.CreateAPInPropertiesWithAPString");
            scope.Start();
            try
            {
                return RestClient.CreateAPInPropertiesWithAPString(createParameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
