// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the Usage data model. </summary>
    public partial class UsageData : TrackedResource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of UsageData. </summary>
        /// <param name="currentValue"> The current usage of the resource. </param>
        /// <param name="limit"> The maximum permitted usage of the resource. </param>
        public UsageData(int currentValue, long limit)
        {
            Unit = "Count";
            CurrentValue = currentValue;
            Limit = limit;
        }

        /// <summary> Initializes a new instance of UsageData. </summary>
        /// <param name="unit"> An enum describing the unit of usage measurement. </param>
        /// <param name="currentValue"> The current usage of the resource. </param>
        /// <param name="limit"> The maximum permitted usage of the resource. </param>
        internal UsageData(string unit, int currentValue, long limit)
        {
            Unit = unit;
            CurrentValue = currentValue;
            Limit = limit;
        }

        /// <summary> An enum describing the unit of usage measurement. </summary>
        public string Unit { get; set; }
        /// <summary> The current usage of the resource. </summary>
        public int CurrentValue { get; set; }
        /// <summary> The maximum permitted usage of the resource. </summary>
        public long Limit { get; set; }
    }
}
