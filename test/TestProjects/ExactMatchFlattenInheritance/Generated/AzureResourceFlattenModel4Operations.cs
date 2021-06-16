// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class representing the operations that can be performed over a specific AzureResourceFlattenModel4. </summary>
    public partial class AzureResourceFlattenModel4Operations : ResourceOperationsBase<ResourceGroupResourceIdentifier, AzureResourceFlattenModel4>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal AzureResourceFlattenModel4SRestOperations RestClient { get; }

        /// <summary> Initializes a new instance of the <see cref="AzureResourceFlattenModel4Operations"/> class for mocking. </summary>
        protected AzureResourceFlattenModel4Operations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AzureResourceFlattenModel4Operations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal AzureResourceFlattenModel4Operations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            RestClient = new AzureResourceFlattenModel4SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        public static readonly ResourceType ResourceType = "Microsoft.Compute/azureResourceFlattenModel4";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<AzureResourceFlattenModel4>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel4Operations.Get");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AzureResourceFlattenModel4(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<AzureResourceFlattenModel4> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel4Operations.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new AzureResourceFlattenModel4(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }
    }
}
