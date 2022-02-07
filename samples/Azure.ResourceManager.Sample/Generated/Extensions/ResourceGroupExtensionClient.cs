// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AvailabilitySets in the AvailabilitySet. </summary>
        /// <returns> An object representing collection of AvailabilitySets and their operations over a AvailabilitySet. </returns>
        public virtual AvailabilitySetCollection GetAvailabilitySets()
        {
            return new AvailabilitySetCollection(Client, Id);
        }

        /// <summary> Gets a collection of ProximityPlacementGroups in the ProximityPlacementGroup. </summary>
        /// <returns> An object representing collection of ProximityPlacementGroups and their operations over a ProximityPlacementGroup. </returns>
        public virtual ProximityPlacementGroupCollection GetProximityPlacementGroups()
        {
            return new ProximityPlacementGroupCollection(Client, Id);
        }

        /// <summary> Gets a collection of DedicatedHostGroups in the DedicatedHostGroup. </summary>
        /// <returns> An object representing collection of DedicatedHostGroups and their operations over a DedicatedHostGroup. </returns>
        public virtual DedicatedHostGroupCollection GetDedicatedHostGroups()
        {
            return new DedicatedHostGroupCollection(Client, Id);
        }

        /// <summary> Gets a collection of SshPublicKeys in the SshPublicKey. </summary>
        /// <returns> An object representing collection of SshPublicKeys and their operations over a SshPublicKey. </returns>
        public virtual SshPublicKeyCollection GetSshPublicKeys()
        {
            return new SshPublicKeyCollection(Client, Id);
        }

        /// <summary> Gets a collection of VirtualMachines in the VirtualMachine. </summary>
        /// <returns> An object representing collection of VirtualMachines and their operations over a VirtualMachine. </returns>
        public virtual VirtualMachineCollection GetVirtualMachines()
        {
            return new VirtualMachineCollection(Client, Id);
        }

        /// <summary> Gets a collection of Images in the Image. </summary>
        /// <returns> An object representing collection of Images and their operations over a Image. </returns>
        public virtual ImageCollection GetImages()
        {
            return new ImageCollection(Client, Id);
        }

        /// <summary> Gets a collection of VirtualMachineScaleSets in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSets and their operations over a VirtualMachineScaleSet. </returns>
        public virtual VirtualMachineScaleSetCollection GetVirtualMachineScaleSets()
        {
            return new VirtualMachineScaleSetCollection(Client, Id);
        }
    }
}
