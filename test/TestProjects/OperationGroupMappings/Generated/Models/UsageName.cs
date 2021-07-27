// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace OperationGroupMappings.Models
{
    /// <summary> The Usage Names. </summary>
    public partial class UsageName
    {
        /// <summary> Initializes a new instance of UsageName. </summary>
        internal UsageName()
        {
        }

        /// <summary> Initializes a new instance of UsageName. </summary>
        /// <param name="value"> The name of the resource. </param>
        /// <param name="localizedValue"> The localized name of the resource. </param>
        internal UsageName(string value, string localizedValue)
        {
            Value = value;
            LocalizedValue = localizedValue;
        }

        /// <summary> The name of the resource. </summary>
        public string Value { get; }
        /// <summary> The localized name of the resource. </summary>
        public string LocalizedValue { get; }
    }
}
