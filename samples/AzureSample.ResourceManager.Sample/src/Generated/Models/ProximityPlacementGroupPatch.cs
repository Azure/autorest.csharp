// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies information about the proximity placement group.
    /// Serialized Name: ProximityPlacementGroupUpdate
    /// </summary>
    public partial class ProximityPlacementGroupPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="ProximityPlacementGroupPatch"/>. </summary>
        public ProximityPlacementGroupPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ProximityPlacementGroupPatch"/>. </summary>
        /// <param name="tags">
        /// Resource tags
        /// Serialized Name: UpdateResource.tags
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ProximityPlacementGroupPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(tags, serializedAdditionalRawData)
        {
        }
    }
}
