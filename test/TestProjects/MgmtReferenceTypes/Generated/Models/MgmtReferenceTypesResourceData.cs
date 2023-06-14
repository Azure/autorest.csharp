// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    [ReferenceType]
    public abstract partial class MgmtReferenceTypesResourceData
    {
        /// <summary> Initializes a new instance of MgmtReferenceTypesResourceData. </summary>
        [InitializationConstructor]
        protected MgmtReferenceTypesResourceData()
        {
        }

        /// <summary> Initializes a new instance of MgmtReferenceTypesResourceData. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        [SerializationConstructor]
        protected MgmtReferenceTypesResourceData(ResourceIdentifier id, string name, ResourceType resourceType)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public ResourceIdentifier Id { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </summary>
        public ResourceType ResourceType { get; }
    }
}
