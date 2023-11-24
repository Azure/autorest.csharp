// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtExtensionResource;

namespace MgmtExtensionResource.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableMgmtExtensionResourceArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtExtensionResourceArmClient"/> class for mocking. </summary>
        protected MockableMgmtExtensionResourceArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtExtensionResourceArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtExtensionResourceArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableMgmtExtensionResourceArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="SubSingletonResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubSingletonResource.CreateResourceIdentifier" /> to create a <see cref="SubSingletonResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubSingletonResource"/> object. </returns>
        public virtual SubSingletonResource GetSubSingletonResource(ResourceIdentifier id)
        {
            SubSingletonResource.ValidateResourceId(id);
            return new SubSingletonResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionPolicyDefinitionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubscriptionPolicyDefinitionResource.CreateResourceIdentifier" /> to create a <see cref="SubscriptionPolicyDefinitionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionPolicyDefinitionResource"/> object. </returns>
        public virtual SubscriptionPolicyDefinitionResource GetSubscriptionPolicyDefinitionResource(ResourceIdentifier id)
        {
            SubscriptionPolicyDefinitionResource.ValidateResourceId(id);
            return new SubscriptionPolicyDefinitionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="BuiltInPolicyDefinitionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BuiltInPolicyDefinitionResource.CreateResourceIdentifier" /> to create a <see cref="BuiltInPolicyDefinitionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BuiltInPolicyDefinitionResource"/> object. </returns>
        public virtual BuiltInPolicyDefinitionResource GetBuiltInPolicyDefinitionResource(ResourceIdentifier id)
        {
            BuiltInPolicyDefinitionResource.ValidateResourceId(id);
            return new BuiltInPolicyDefinitionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ManagementGroupPolicyDefinitionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier" /> to create a <see cref="ManagementGroupPolicyDefinitionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ManagementGroupPolicyDefinitionResource"/> object. </returns>
        public virtual ManagementGroupPolicyDefinitionResource GetManagementGroupPolicyDefinitionResource(ResourceIdentifier id)
        {
            ManagementGroupPolicyDefinitionResource.ValidateResourceId(id);
            return new ManagementGroupPolicyDefinitionResource(Client, id);
        }
    }
}
