// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtSubscriptionNameParameter;

namespace MgmtSubscriptionNameParameter.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableMgmtSubscriptionNameParameterArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSubscriptionNameParameterArmClient"/> class for mocking. </summary>
        protected MockableMgmtSubscriptionNameParameterArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSubscriptionNameParameterArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtSubscriptionNameParameterArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableMgmtSubscriptionNameParameterArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="SBSubscriptionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SBSubscriptionResource.CreateResourceIdentifier" /> to create a <see cref="SBSubscriptionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SBSubscriptionResource"/> object. </returns>
        public virtual SBSubscriptionResource GetSBSubscriptionResource(ResourceIdentifier id)
        {
            SBSubscriptionResource.ValidateResourceId(id);
            return new SBSubscriptionResource(Client, id);
        }
    }
}
