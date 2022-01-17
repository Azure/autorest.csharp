// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> A list of private link resources. </summary>
    [TypeReferenceType]
    public partial class PrivateLinkResourceList
    {
        /// <summary> Initializes a new instance of PrivateLinkResourceList. </summary>
        [InitializationConstructor]
        public PrivateLinkResourceList()
        {
            Value = new ChangeTrackingList<PrivateLinkResourceData>();
        }

        /// <summary> Initializes a new instance of PrivateLinkResourceList. </summary>
        /// <param name="value"> Array of private link resources. </param>
        [SerializationConstructor]
        internal PrivateLinkResourceList(IReadOnlyList<PrivateLinkResourceData> value)
        {
            Value = value;
        }

        /// <summary> Array of private link resources. </summary>
        public IReadOnlyList<PrivateLinkResourceData> Value { get; }
    }
}
