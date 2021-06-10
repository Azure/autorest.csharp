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

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing the operations that can be performed over a specific ResourceLevel. </summary>
    public partial class ResourceLevelOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, ResourceLevel>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ResourceLevelsRestOperations RestClient { get; }

        /// <summary> Initializes a new instance of the <see cref="ResourceLevelOperations"/> class for mocking. </summary>
        protected ResourceLevelOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceLevelOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ResourceLevelOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            RestClient = new ResourceLevelsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        public static readonly ResourceType ResourceType = "Microsoft.Network/ResourceLevels";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<ResourceLevel>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceLevelOperations.Get");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceLevel(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<ResourceLevel> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceLevelOperations.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new ResourceLevel(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }
    }
}
