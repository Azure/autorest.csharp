// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ReferenceTypes.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    public partial class ResourceNon
    {
        /// <summary> Initializes a new instance of ResourceNon. </summary>
        internal ResourceNon()
        {
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public string Id { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public string Type { get; }
    }
}
