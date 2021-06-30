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

namespace Azure.Management.Storage
{
    /// <summary> A class representing the operations that can be performed over a specific FileService. </summary>
    public partial class FileServiceOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, FileService>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private FileServicesRestOperations _restClient { get; }

        /// <summary> Initializes a new instance of the <see cref="FileServiceOperations"/> class for mocking. </summary>
        protected FileServiceOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FileServiceOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal FileServiceOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FileServicesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/fileServices";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<FileService>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileServiceOperations.GetServiceProperties");
            scope.Start();
            try
            {
                var response = await _restClient.GetServicePropertiesAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FileService(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<FileService> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileServiceOperations.GetServiceProperties");
            scope.Start();
            try
            {
                var response = _restClient.GetServiceProperties(Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new FileService(this, response.Value), response.GetRawResponse());
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
