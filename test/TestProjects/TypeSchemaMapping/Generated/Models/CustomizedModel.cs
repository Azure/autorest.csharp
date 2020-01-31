// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using AnotherCustomNamespace;
using TypeSchemaMapping.Models;

namespace CustomNamespace
{
    /// <summary> The Model. </summary>
    internal partial class CustomizedModel
    {
        /// <summary> A description about the set of tags. </summary>
        public string ModelProperty { get; set; }
        /// <summary> Fruit. </summary>
        public CustomFruitEnum Fruit { get; set; }
        /// <summary> Day of week. </summary>
        public DaysOfWeek DaysOfWeek { get; set; }
    }
}
