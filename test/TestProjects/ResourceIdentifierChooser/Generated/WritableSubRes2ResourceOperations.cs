// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing the operations that can be performed over a specific WritableSubRes2Resource. </summary>
    public partial class WritableSubRes2ResourceOperations : ResourceOperationsBase<TenantResourceIdentifier, WritableSubRes2Resource>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private WritableSubRes2ResourcesRestOperations _restClient { get; }

        /// <summary> Initializes a new instance of the <see cref="WritableSubRes2ResourceOperations"/> class for mocking. </summary>
        protected WritableSubRes2ResourceOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="WritableSubRes2ResourceOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal WritableSubRes2ResourceOperations(ResourceOperationsBase options, TenantResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            Id.TryGetSubscriptionId(out var subscriptionId);
            _restClient = new WritableSubRes2ResourcesRestOperations(_clientDiagnostics, Pipeline, subscriptionId, BaseUri);
        }

        public static readonly ResourceType ResourceType = "Microsoft.Compute/WritableSubRes2Resources";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<WritableSubRes2Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceOperations.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new WritableSubRes2Resource(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<WritableSubRes2Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceOperations.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new WritableSubRes2Resource(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }
    }
}
