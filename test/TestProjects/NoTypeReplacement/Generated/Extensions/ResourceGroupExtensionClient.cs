// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace NoTypeReplacement
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
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of NoTypeReplacementModel1s in the NoTypeReplacementModel1. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel1s and their operations over a NoTypeReplacementModel1. </returns>
        public virtual NoTypeReplacementModel1Collection GetNoTypeReplacementModel1s()
        {
            return new NoTypeReplacementModel1Collection(Client, Id);
        }

        /// <summary> Gets a collection of NoTypeReplacementModel2s in the NoTypeReplacementModel2. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel2s and their operations over a NoTypeReplacementModel2. </returns>
        public virtual NoTypeReplacementModel2Collection GetNoTypeReplacementModel2s()
        {
            return new NoTypeReplacementModel2Collection(Client, Id);
        }

        /// <summary> Gets a collection of NoTypeReplacementModel3s in the NoTypeReplacementModel3. </summary>
        /// <returns> An object representing collection of NoTypeReplacementModel3s and their operations over a NoTypeReplacementModel3. </returns>
        public virtual NoTypeReplacementModel3Collection GetNoTypeReplacementModel3s()
        {
            return new NoTypeReplacementModel3Collection(Client, Id);
        }
    }
}
