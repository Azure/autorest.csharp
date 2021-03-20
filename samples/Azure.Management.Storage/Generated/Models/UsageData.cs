// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the Usage data model. </summary>
    public partial class UsageData : ResourceManager.Core.TrackedResource
    {
        /// <summary> Gets the unit of measurement. </summary>
        public UsageUnit? Unit { get; }
        /// <summary> Gets the current count of the allocated resources in the subscription. </summary>
        public int? CurrentValue { get; }
        /// <summary> Gets the maximum count of the resources that can be allocated in the subscription. </summary>
        public int? Limit { get; }
        /// <summary> Gets the name of the type of usage. </summary>
        public UsageName Name { get; }
    }
}
