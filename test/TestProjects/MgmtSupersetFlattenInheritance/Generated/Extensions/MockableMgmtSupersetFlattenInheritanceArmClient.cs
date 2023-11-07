// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtSupersetFlattenInheritance;

namespace MgmtSupersetFlattenInheritance.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableMgmtSupersetFlattenInheritanceArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSupersetFlattenInheritanceArmClient"/> class for mocking. </summary>
        protected MockableMgmtSupersetFlattenInheritanceArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSupersetFlattenInheritanceArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtSupersetFlattenInheritanceArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableMgmtSupersetFlattenInheritanceArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="ResourceModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResourceModel1Resource.CreateResourceIdentifier" /> to create a <see cref="ResourceModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceModel1Resource" /> object. </returns>
        public virtual ResourceModel1Resource GetResourceModel1Resource(ResourceIdentifier id)
        {
            ResourceModel1Resource.ValidateResourceId(id);
            return new ResourceModel1Resource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TrackedResourceModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TrackedResourceModel1Resource.CreateResourceIdentifier" /> to create a <see cref="TrackedResourceModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TrackedResourceModel1Resource" /> object. </returns>
        public virtual TrackedResourceModel1Resource GetTrackedResourceModel1Resource(ResourceIdentifier id)
        {
            TrackedResourceModel1Resource.ValidateResourceId(id);
            return new TrackedResourceModel1Resource(Client, id);
        }
    }
}
