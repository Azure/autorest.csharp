// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtRenameRules
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

        /// <summary> Gets a collection of VirtualMachineResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VirtualMachineResources and their operations over a VirtualMachineResource. </returns>
        public virtual VirtualMachineCollection GetVirtualMachines()
        {
            return GetCachedClient(Client => new VirtualMachineCollection(Client, Id));
        }

        /// <summary> Gets a collection of ImageResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ImageResources and their operations over a ImageResource. </returns>
        public virtual ImageCollection GetImages()
        {
            return GetCachedClient(Client => new ImageCollection(Client, Id));
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetResources and their operations over a VirtualMachineScaleSetResource. </returns>
        public virtual VirtualMachineScaleSetCollection GetVirtualMachineScaleSets()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetCollection(Client, Id));
        }
    }
}
