// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_formdata_urlencoded.Models;

namespace body_formdata_urlencoded
{
    /// <summary> The Formdataurlencoded service client. </summary>
    public partial class FormdataurlencodedClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal FormdataurlencodedRestClient RestClient { get; }

        /// <summary> Initializes a new instance of FormdataurlencodedClient for mocking. </summary>
        protected FormdataurlencodedClient()
        {
        }

        /// <summary> Initializes a new instance of FormdataurlencodedClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal FormdataurlencodedClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new FormdataurlencodedRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Updates a pet in the store with form data. </summary>
        /// <param name="petId"> ID of pet that needs to be updated. </param>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        /// <param name="name"> Updated name of the pet. </param>
        /// <param name="status"> Updated status of the pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Updates a pet in the store with form data. </remarks>
        public virtual async Task<Response> UpdatePetWithFormAsync(int petId, PetType petType, PetFood petFood, int petAge, string name = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataurlencodedClient.UpdatePetWithForm");
            scope.Start();
            try
            {
                return await RestClient.UpdatePetWithFormAsync(petId, petType, petFood, petAge, name, status, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a pet in the store with form data. </summary>
        /// <param name="petId"> ID of pet that needs to be updated. </param>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        /// <param name="name"> Updated name of the pet. </param>
        /// <param name="status"> Updated status of the pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Updates a pet in the store with form data. </remarks>
        public virtual Response UpdatePetWithForm(int petId, PetType petType, PetFood petFood, int petAge, string name = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataurlencodedClient.UpdatePetWithForm");
            scope.Start();
            try
            {
                return RestClient.UpdatePetWithForm(petId, petType, petFood, petAge, name, status, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test a partially constant formdata body. Pass in { grant_type: &apos;access_token&apos;, access_token: &apos;foo&apos;, service: &apos;bar&apos; } to pass the test. </summary>
        /// <param name="grantType"> Constant part of a formdata body. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="accessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PartialConstantBodyAsync(PostContentSchemaGrantType grantType, string service, string accessToken, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataurlencodedClient.PartialConstantBody");
            scope.Start();
            try
            {
                return await RestClient.PartialConstantBodyAsync(grantType, service, accessToken, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test a partially constant formdata body. Pass in { grant_type: &apos;access_token&apos;, access_token: &apos;foo&apos;, service: &apos;bar&apos; } to pass the test. </summary>
        /// <param name="grantType"> Constant part of a formdata body. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="accessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PartialConstantBody(PostContentSchemaGrantType grantType, string service, string accessToken, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataurlencodedClient.PartialConstantBody");
            scope.Start();
            try
            {
                return RestClient.PartialConstantBody(grantType, service, accessToken, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
