// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using extensible_enums_swagger.Models;

namespace extensible_enums_swagger
{
    /// <summary> The Pet service client. </summary>
    public partial class PetClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PetRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PetClient for mocking. </summary>
        protected PetClient()
        {
        }

        /// <summary> Initializes a new instance of PetClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal PetClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new PetRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> get pet by id. </summary>
        /// <param name="petId"> Pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> GetByPetIdAsync(string petId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetClient.GetByPetId");
            scope.Start();
            try
            {
                return await RestClient.GetByPetIdAsync(petId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> get pet by id. </summary>
        /// <param name="petId"> Pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> GetByPetId(string petId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetClient.GetByPetId");
            scope.Start();
            try
            {
                return RestClient.GetByPetId(petId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> add pet. </summary>
        /// <param name="petParam"> pet param. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> AddPetAsync(Pet petParam = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetClient.AddPet");
            scope.Start();
            try
            {
                return await RestClient.AddPetAsync(petParam, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> add pet. </summary>
        /// <param name="petParam"> pet param. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> AddPet(Pet petParam = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PetClient.AddPet");
            scope.Start();
            try
            {
                return RestClient.AddPet(petParam, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
