// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtExtensionResource
{
    /// <summary> A class to add extension methods to ManagementGroupResource. </summary>
    internal partial class ManagementGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ManagementGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ManagementGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ManagementGroupPolicyDefinitionResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of ManagementGroupPolicyDefinitionResources and their operations over a ManagementGroupPolicyDefinitionResource. </returns>
        public virtual ManagementGroupPolicyDefinitionCollection GetManagementGroupPolicyDefinitions()
        {
            return GetCachedClient(Client => new ManagementGroupPolicyDefinitionCollection(Client, Id));
        }
    }
}
