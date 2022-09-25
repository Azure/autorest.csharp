// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace MgmtExtensionResource
{
    /// <summary> This is the base client representation of the following resources <see cref="SubscriptionPolicyDefinitionResource" />, <see cref="BuiltInPolicyDefinitionResource" /> or <see cref="ManagementGroupPolicyDefinitionResource" />. </summary>
    public abstract partial class PolicyDefinitionResource : ArmResource
    {
        internal static PolicyDefinitionResource GetResource(ArmClient client, PolicyDefinitionData data)
        {
            if (IsSubscriptionPolicyDefinitionResource(data.Id))
            {
                return new SubscriptionPolicyDefinitionResource(client, data);
            }
            if (IsBuiltInPolicyDefinitionResource(data.Id))
            {
                return new BuiltInPolicyDefinitionResource(client, data);
            }
            if (IsManagementGroupPolicyDefinitionResource(data.Id))
            {
                return new ManagementGroupPolicyDefinitionResource(client, data);
            }
            throw new InvalidOperationException($"The resource identifier {data.Id} cannot be recognized as one of the following resource candidates: SubscriptionPolicyDefinitionResource, BuiltInPolicyDefinitionResource or ManagementGroupPolicyDefinitionResource");
        }

        private static bool IsSubscriptionPolicyDefinitionResource(ResourceIdentifier id)
        {
            // checking the resource type
            if (id.ResourceType != SubscriptionPolicyDefinitionResource.ResourceType)
            {
                return false;
            }
            // checking the resource scope
            if (id.Parent.ResourceType != SubscriptionResource.ResourceType)
            {
                return false;
            }
            return true;
        }

        private static bool IsBuiltInPolicyDefinitionResource(ResourceIdentifier id)
        {
            // checking the resource type
            if (id.ResourceType != BuiltInPolicyDefinitionResource.ResourceType)
            {
                return false;
            }
            // checking the resource scope
            if (id.Parent.ResourceType != TenantResource.ResourceType)
            {
                return false;
            }
            return true;
        }

        private static bool IsManagementGroupPolicyDefinitionResource(ResourceIdentifier id)
        {
            // checking the resource type
            if (id.ResourceType != ManagementGroupPolicyDefinitionResource.ResourceType)
            {
                return false;
            }
            // checking the resource scope
            if (id.Parent.ResourceType != ManagementGroupResource.ResourceType)
            {
                return false;
            }
            return true;
        }

        private readonly PolicyDefinitionData _data;

        /// <summary> Initializes a new instance of the <see cref="PolicyDefinitionResource"/> class for mocking. </summary>
        protected PolicyDefinitionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PolicyDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PolicyDefinitionResource(ArmClient client, PolicyDefinitionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PolicyDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PolicyDefinitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PolicyDefinitionData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// <summary> The core implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected abstract Task<Response<PolicyDefinitionResource>> GetCoreAsync(CancellationToken cancellationToken = default);

        /// <summary> The default implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<PolicyDefinitionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetCoreAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> The core implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected abstract Response<PolicyDefinitionResource> GetCore(CancellationToken cancellationToken = default);

        /// <summary> The default implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PolicyDefinitionResource> Get(CancellationToken cancellationToken = default)
        {
            return GetCore(cancellationToken);
        }
    }
}
