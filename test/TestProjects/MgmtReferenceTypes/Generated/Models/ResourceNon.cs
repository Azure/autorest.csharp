// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtReferenceTypes.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    internal partial class ResourceNon
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtReferenceTypes.Models.ResourceNon
        ///
        /// </summary>
        internal ResourceNon()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtReferenceTypes.Models.ResourceNon
        ///
        /// </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceNon(string id, string name, string resourceType, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public string Id { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </summary>
        public string ResourceType { get; }
    }
}
