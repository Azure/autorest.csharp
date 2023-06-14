// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtParamOrdering
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AvailabilitySetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of AvailabilitySetResources and their operations over a AvailabilitySetResource. </returns>
        public virtual AvailabilitySetCollection GetAvailabilitySets()
        {
            return GetCachedClient(Client => new AvailabilitySetCollection(Client, Id));
        }

        /// <summary> Gets a collection of DedicatedHostGroupResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of DedicatedHostGroupResources and their operations over a DedicatedHostGroupResource. </returns>
        public virtual DedicatedHostGroupCollection GetDedicatedHostGroups()
        {
            return GetCachedClient(Client => new DedicatedHostGroupCollection(Client, Id));
        }

        /// <summary> Gets a collection of WorkspaceResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of WorkspaceResources and their operations over a WorkspaceResource. </returns>
        public virtual WorkspaceCollection GetWorkspaces()
        {
            return GetCachedClient(Client => new WorkspaceCollection(Client, Id));
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetResources and their operations over a VirtualMachineScaleSetResource. </returns>
        public virtual VirtualMachineScaleSetCollection GetVirtualMachineScaleSets()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetCollection(Client, Id));
        }
    }
}
