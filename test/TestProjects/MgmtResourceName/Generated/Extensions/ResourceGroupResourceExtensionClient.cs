// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtResourceName
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

        /// <summary> Gets a collection of MachineResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of MachineResources and their operations over a MachineResource. </returns>
        public virtual MachineCollection GetMachines()
        {
            return GetCachedClient(Client => new MachineCollection(Client, Id));
        }

        /// <summary> Gets a collection of Disks in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of Disks and their operations over a Disk. </returns>
        public virtual DiskCollection GetDisks()
        {
            return GetCachedClient(Client => new DiskCollection(Client, Id));
        }

        /// <summary> Gets a collection of Memories in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of Memories and their operations over a Memory. </returns>
        public virtual MemoryCollection GetMemories()
        {
            return GetCachedClient(Client => new MemoryCollection(Client, Id));
        }

        /// <summary> Gets a collection of NetworkResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of NetworkResources and their operations over a NetworkResource. </returns>
        public virtual NetworkCollection GetNetworks()
        {
            return GetCachedClient(Client => new NetworkCollection(Client, Id));
        }

        /// <summary> Gets a collection of DisplayResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of DisplayResources and their operations over a DisplayResource. </returns>
        public virtual DisplayResourceCollection GetDisplayResources()
        {
            return GetCachedClient(Client => new DisplayResourceCollection(Client, Id));
        }
    }
}
