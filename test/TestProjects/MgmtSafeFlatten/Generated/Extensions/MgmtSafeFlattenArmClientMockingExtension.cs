// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MgmtSafeFlattenArmClientMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtSafeFlattenArmClientMockingExtension"/> class for mocking. </summary>
        protected MgmtSafeFlattenArmClientMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtSafeFlattenArmClientMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtSafeFlattenArmClientMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MgmtSafeFlattenArmClientMockingExtension(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="TypeOneResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TypeOneResource.CreateResourceIdentifier" /> to create a <see cref="TypeOneResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TypeOneResource" /> object. </returns>
        public virtual TypeOneResource GetTypeOneResource(ResourceIdentifier id)
        {
            TypeOneResource.ValidateResourceId(id);
            return new TypeOneResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TypeTwoResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TypeTwoResource.CreateResourceIdentifier" /> to create a <see cref="TypeTwoResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TypeTwoResource" /> object. </returns>
        public virtual TypeTwoResource GetTypeTwoResource(ResourceIdentifier id)
        {
            TypeTwoResource.ValidateResourceId(id);
            return new TypeTwoResource(Client, id);
        }
    }
}
