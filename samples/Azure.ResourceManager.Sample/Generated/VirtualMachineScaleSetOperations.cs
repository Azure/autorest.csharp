// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the operations that can be performed over a specific VirtualMachineScaleSet. </summary>
    public partial class VirtualMachineScaleSetOperations : ResourceOperationsBase<TenantResourceIdentifier, VirtualMachineScaleSet>
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetOperations for mocking. </summary>
        protected VirtualMachineScaleSetOperations()
        {
        }

        public static readonly ResourceType ResourceType = "Azure.ResourceManager.Sample/VirtualMachineScaleSetOperations";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public override ArmResponse<VirtualMachineScaleSet> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<VirtualMachineScaleSet>> GetAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Gets a list of VirtualMachineScaleSetExtension in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetExtensions and their operations over a VirtualMachineScaleSet. </returns>
        public VirtualMachineScaleSetExtensionContainer GetVirtualMachineScaleSetExtension()
        {
            return new VirtualMachineScaleSetExtensionContainer(this);
        }

        /// <summary> Gets a list of VirtualMachineScaleSetRollingUpgrade in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetRollingUpgrades and their operations over a VirtualMachineScaleSet. </returns>
        public VirtualMachineScaleSetRollingUpgradeContainer GetVirtualMachineScaleSetRollingUpgrade()
        {
            return new VirtualMachineScaleSetRollingUpgradeContainer(this);
        }

        /// <summary> Gets a list of VirtualMachineExtension in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineExtensions and their operations over a VirtualMachineScaleSet. </returns>
        public VirtualMachineExtensionContainer GetVirtualMachineExtension()
        {
            return new VirtualMachineExtensionContainer(this);
        }

        /// <summary> Gets a list of VirtualMachineScaleSetVM in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetVMs and their operations over a VirtualMachineScaleSet. </returns>
        public VirtualMachineScaleSetVMContainer GetVirtualMachineScaleSetVM()
        {
            return new VirtualMachineScaleSetVMContainer(this);
        }
    }
}
