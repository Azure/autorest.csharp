// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtNonStringPathVariable;

namespace MgmtNonStringPathVariable.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableMgmtNonStringPathVariableArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtNonStringPathVariableArmClient"/> class for mocking. </summary>
        protected MockableMgmtNonStringPathVariableArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtNonStringPathVariableArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtNonStringPathVariableArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableMgmtNonStringPathVariableArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="FakeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeResource.CreateResourceIdentifier" /> to create a <see cref="FakeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeResource" /> object. </returns>
        public virtual FakeResource GetFakeResource(ResourceIdentifier id)
        {
            FakeResource.ValidateResourceId(id);
            return new FakeResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="BarResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BarResource.CreateResourceIdentifier" /> to create a <see cref="BarResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BarResource" /> object. </returns>
        public virtual BarResource GetBarResource(ResourceIdentifier id)
        {
            BarResource.ValidateResourceId(id);
            return new BarResource(Client, id);
        }
    }
}
