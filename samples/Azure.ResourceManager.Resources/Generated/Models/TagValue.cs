// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Tag information. </summary>
    internal partial class TagValue : SubResource
    {
        /// <summary> Initializes a new instance of TagValue. </summary>
        internal TagValue()
        {
        }

        /// <summary> The tag value. </summary>
        public string TagValueValue { get; }
        /// <summary> The tag value count. </summary>
        public TagCount Count { get; }
    }
}
