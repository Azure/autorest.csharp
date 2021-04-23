// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace SupersetInheritance
{
    /// <summary> A class representing the operations that can be performed over a specific SupersetModel4. </summary>
    public partial class SupersetModel4Operations : ResourceOperationsBase<TenantResourceIdentifier, SupersetModel4>
    {
        /// <summary> Initializes a new instance of SupersetModel4Operations for mocking. </summary>
        protected SupersetModel4Operations()
        {
        }

<<<<<<< HEAD
        /// <summary> Initializes a new instance of <see cref = "SupersetModel4Operations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected SupersetModel4Operations(ResourceOperationsBase options, TenantResourceIdentifier id) : base(options, id)
        {
        }

        public static readonly ResourceType ResourceType = "Microsoft.Compute/operationGroup4";
=======
        public static readonly ResourceType ResourceType = "Microsoft.Compute/supersetModel4s";
>>>>>>> 39d8276362dc7bda4732be7e79b62d35d4d17724
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public override ArmResponse<SupersetModel4> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<SupersetModel4>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }
    }
}
