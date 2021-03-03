// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the Usage data model. </summary>
    public partial class UsageData
    {
        /// <summary> An enum describing the unit of usage measurement. </summary>
        public string Unit { get; }
        /// <summary> The current usage of the resource. </summary>
        public int CurrentValue { get; }
        /// <summary> The maximum permitted usage of the resource. </summary>
        public long Limit { get; }
        /// <summary> The name of the type of usage. </summary>
        public UsageName Name { get; }
    }
}
