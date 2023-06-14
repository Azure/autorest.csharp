// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes Compute Resource Usage.
    /// Serialized Name: SampleUsage
    /// </summary>
    public partial class SampleUsage
    {
        /// <summary> Initializes a new instance of SampleUsage. </summary>
        /// <param name="currentValue">
        /// The current usage of the resource.
        /// Serialized Name: SampleUsage.currentValue
        /// </param>
        /// <param name="limit">
        /// The maximum permitted usage of the resource.
        /// Serialized Name: SampleUsage.limit
        /// </param>
        /// <param name="name">
        /// The name of the type of usage.
        /// Serialized Name: SampleUsage.name
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal SampleUsage(int currentValue, long limit, SampleUsageName name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Unit = UsageUnit.Count;
            CurrentValue = currentValue;
            Limit = limit;
            Name = name;
        }

        /// <summary> Initializes a new instance of SampleUsage. </summary>
        /// <param name="unit">
        /// An enum describing the unit of usage measurement.
        /// Serialized Name: SampleUsage.unit
        /// </param>
        /// <param name="currentValue">
        /// The current usage of the resource.
        /// Serialized Name: SampleUsage.currentValue
        /// </param>
        /// <param name="limit">
        /// The maximum permitted usage of the resource.
        /// Serialized Name: SampleUsage.limit
        /// </param>
        /// <param name="name">
        /// The name of the type of usage.
        /// Serialized Name: SampleUsage.name
        /// </param>
        internal SampleUsage(UsageUnit unit, int currentValue, long limit, SampleUsageName name)
        {
            Unit = unit;
            CurrentValue = currentValue;
            Limit = limit;
            Name = name;
        }

        /// <summary>
        /// An enum describing the unit of usage measurement.
        /// Serialized Name: SampleUsage.unit
        /// </summary>
        public UsageUnit Unit { get; }
        /// <summary>
        /// The current usage of the resource.
        /// Serialized Name: SampleUsage.currentValue
        /// </summary>
        public int CurrentValue { get; }
        /// <summary>
        /// The maximum permitted usage of the resource.
        /// Serialized Name: SampleUsage.limit
        /// </summary>
        public long Limit { get; }
        /// <summary>
        /// The name of the type of usage.
        /// Serialized Name: SampleUsage.name
        /// </summary>
        public SampleUsageName Name { get; }
    }
}
