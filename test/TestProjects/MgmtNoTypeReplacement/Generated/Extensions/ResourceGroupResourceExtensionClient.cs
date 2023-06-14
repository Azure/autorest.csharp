// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtNoTypeReplacement
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

        /// <summary> Gets a collection of NoTypeReplacementModel1Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel1Resources and their operations over a NoTypeReplacementModel1Resource. </returns>
        public virtual NoTypeReplacementModel1Collection GetNoTypeReplacementModel1s()
        {
            return GetCachedClient(Client => new NoTypeReplacementModel1Collection(Client, Id));
        }

        /// <summary> Gets a collection of NoTypeReplacementModel2Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel2Resources and their operations over a NoTypeReplacementModel2Resource. </returns>
        public virtual NoTypeReplacementModel2Collection GetNoTypeReplacementModel2s()
        {
            return GetCachedClient(Client => new NoTypeReplacementModel2Collection(Client, Id));
        }

        /// <summary> Gets a collection of NoTypeReplacementModel3Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel3Resources and their operations over a NoTypeReplacementModel3Resource. </returns>
        public virtual NoTypeReplacementModel3Collection GetNoTypeReplacementModel3s()
        {
            return GetCachedClient(Client => new NoTypeReplacementModel3Collection(Client, Id));
        }
    }
}
