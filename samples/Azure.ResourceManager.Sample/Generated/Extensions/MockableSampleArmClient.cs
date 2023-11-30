// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableSampleArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableSampleArmClient"/> class for mocking. </summary>
        protected MockableSampleArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableSampleArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableSampleArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableSampleArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetResource"/> object. </returns>
        public virtual AvailabilitySetResource GetAvailabilitySetResource(ResourceIdentifier id)
        {
            AvailabilitySetResource.ValidateResourceId(id);
            return new AvailabilitySetResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ProximityPlacementGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ProximityPlacementGroupResource.CreateResourceIdentifier" /> to create a <see cref="ProximityPlacementGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ProximityPlacementGroupResource"/> object. </returns>
        public virtual ProximityPlacementGroupResource GetProximityPlacementGroupResource(ResourceIdentifier id)
        {
            ProximityPlacementGroupResource.ValidateResourceId(id);
            return new ProximityPlacementGroupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostGroupResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostGroupResource"/> object. </returns>
        public virtual DedicatedHostGroupResource GetDedicatedHostGroupResource(ResourceIdentifier id)
        {
            DedicatedHostGroupResource.ValidateResourceId(id);
            return new DedicatedHostGroupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostResource"/> object. </returns>
        public virtual DedicatedHostResource GetDedicatedHostResource(ResourceIdentifier id)
        {
            DedicatedHostResource.ValidateResourceId(id);
            return new DedicatedHostResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SshPublicKeyResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SshPublicKeyResource.CreateResourceIdentifier" /> to create a <see cref="SshPublicKeyResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SshPublicKeyResource"/> object. </returns>
        public virtual SshPublicKeyResource GetSshPublicKeyResource(ResourceIdentifier id)
        {
            SshPublicKeyResource.ValidateResourceId(id);
            return new SshPublicKeyResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionImageResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionImageResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionImageResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionImageResource"/> object. </returns>
        public virtual VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(ResourceIdentifier id)
        {
            VirtualMachineExtensionImageResource.ValidateResourceId(id);
            return new VirtualMachineExtensionImageResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionResource"/> object. </returns>
        public virtual VirtualMachineExtensionResource GetVirtualMachineExtensionResource(ResourceIdentifier id)
        {
            VirtualMachineExtensionResource.ValidateResourceId(id);
            return new VirtualMachineExtensionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource"/> object. </returns>
        public virtual VirtualMachineScaleSetVirtualMachineExtensionResource GetVirtualMachineScaleSetVirtualMachineExtensionResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetVirtualMachineExtensionResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetVirtualMachineExtensionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineResource"/> object. </returns>
        public virtual VirtualMachineResource GetVirtualMachineResource(ResourceIdentifier id)
        {
            VirtualMachineResource.ValidateResourceId(id);
            return new VirtualMachineResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="ImageResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ImageResource.CreateResourceIdentifier" /> to create an <see cref="ImageResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ImageResource"/> object. </returns>
        public virtual ImageResource GetImageResource(ResourceIdentifier id)
        {
            ImageResource.ValidateResourceId(id);
            return new ImageResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetResource"/> object. </returns>
        public virtual VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetExtensionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetExtensionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetExtensionResource"/> object. </returns>
        public virtual VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetExtensionResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetExtensionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetRollingUpgradeResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> object. </returns>
        public virtual VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetRollingUpgradeResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetRollingUpgradeResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVmResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVmResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVmResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVmResource"/> object. </returns>
        public virtual VirtualMachineScaleSetVmResource GetVirtualMachineScaleSetVmResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetVmResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetVmResource(Client, id);
        }
    }
}
