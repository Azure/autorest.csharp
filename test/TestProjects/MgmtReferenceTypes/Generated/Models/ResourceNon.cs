// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtReferenceTypes.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    internal partial class ResourceNon
    {
        /// <summary> Initializes a new instance of ResourceNon. </summary>
        internal ResourceNon()
        {
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public string Id { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </summary>
        public string ResourceType { get; }
    }
}
