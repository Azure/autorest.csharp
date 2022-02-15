// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to ManagementGroup. </summary>
    internal partial class ManagementGroupExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ManagementGroupExtensionClient"/> class for mocking. </summary>
        protected ManagementGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of DeploymentExtendeds in the DeploymentExtended. </summary>
        /// <returns> An object representing collection of DeploymentExtendeds and their operations over a DeploymentExtended. </returns>
        public virtual DeploymentExtendedCollection GetDeploymentExtendeds()
        {
            return new DeploymentExtendedCollection(Client, Id);
        }
    }
}
