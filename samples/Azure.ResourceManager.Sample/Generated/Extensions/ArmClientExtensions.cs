// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region AvailabilitySet
        /// <summary> Gets an object representing a AvailabilitySet along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySet" /> object. </returns>
        public static AvailabilitySet GetAvailabilitySet(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new AvailabilitySet(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region ProximityPlacementGroup
        /// <summary> Gets an object representing a ProximityPlacementGroup along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ProximityPlacementGroup" /> object. </returns>
        public static ProximityPlacementGroup GetProximityPlacementGroup(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new ProximityPlacementGroup(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DedicatedHostGroup
        /// <summary> Gets an object representing a DedicatedHostGroup along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostGroup" /> object. </returns>
        public static DedicatedHostGroup GetDedicatedHostGroup(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DedicatedHostGroup(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DedicatedHost
        /// <summary> Gets an object representing a DedicatedHost along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHost" /> object. </returns>
        public static DedicatedHost GetDedicatedHost(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DedicatedHost(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region SshPublicKey
        /// <summary> Gets an object representing a SshPublicKey along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SshPublicKey" /> object. </returns>
        public static SshPublicKey GetSshPublicKey(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new SshPublicKey(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineExtension
        /// <summary> Gets an object representing a VirtualMachineExtension along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtension" /> object. </returns>
        public static VirtualMachineExtension GetVirtualMachineExtension(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineExtension(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachine
        /// <summary> Gets an object representing a VirtualMachine along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachine" /> object. </returns>
        public static VirtualMachine GetVirtualMachine(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachine(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region Image
        /// <summary> Gets an object representing a Image along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Image" /> object. </returns>
        public static Image GetImage(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new Image(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineScaleSet
        /// <summary> Gets an object representing a VirtualMachineScaleSet along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSet" /> object. </returns>
        public static VirtualMachineScaleSet GetVirtualMachineScaleSet(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineScaleSet(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineScaleSetExtension
        /// <summary> Gets an object representing a VirtualMachineScaleSetExtension along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetExtension" /> object. </returns>
        public static VirtualMachineScaleSetExtension GetVirtualMachineScaleSetExtension(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineScaleSetExtension(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineScaleSetRollingUpgrade
        /// <summary> Gets an object representing a VirtualMachineScaleSetRollingUpgrade along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetRollingUpgrade" /> object. </returns>
        public static VirtualMachineScaleSetRollingUpgrade GetVirtualMachineScaleSetRollingUpgrade(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineScaleSetRollingUpgrade(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineScaleSetVirtualMachineExtension
        /// <summary> Gets an object representing a VirtualMachineScaleSetVirtualMachineExtension along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVirtualMachineExtension" /> object. </returns>
        public static VirtualMachineScaleSetVirtualMachineExtension GetVirtualMachineScaleSetVirtualMachineExtension(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineScaleSetVirtualMachineExtension(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region VirtualMachineScaleSetVM
        /// <summary> Gets an object representing a VirtualMachineScaleSetVM along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVM" /> object. </returns>
        public static VirtualMachineScaleSetVM GetVirtualMachineScaleSetVM(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new VirtualMachineScaleSetVM(clientOptions, credential, uri, pipeline, id));
        }
        #endregion
    }
}
