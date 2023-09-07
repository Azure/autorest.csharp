// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The Usage Names.
    /// Serialized Name: UsageName
    /// </summary>
    public partial class SampleUsageName
    {
        /// <summary> Initializes a new instance of SampleUsageName. </summary>
        internal SampleUsageName()
        {
        }

        /// <summary> Initializes a new instance of SampleUsageName. </summary>
        /// <param name="value">
        /// The name of the resource.
        /// Serialized Name: UsageName.value
        /// </param>
        /// <param name="localizedValue">
        /// The localized name of the resource.
        /// Serialized Name: UsageName.localizedValue
        /// </param>
        internal SampleUsageName(string value, string localizedValue)
        {
            Value = value;
            LocalizedValue = localizedValue;
        }

        /// <summary>
        /// The name of the resource.
        /// Serialized Name: UsageName.value
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// The localized name of the resource.
        /// Serialized Name: UsageName.localizedValue
        /// </summary>
        public string LocalizedValue { get; }
    }
}
