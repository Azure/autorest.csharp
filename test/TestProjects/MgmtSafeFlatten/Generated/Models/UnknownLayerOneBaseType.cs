// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The UnknownLayerOneBaseType. </summary>
    internal partial class UnknownLayerOneBaseType : LayerOneBaseType
    {
        /// <summary> Initializes a new instance of <see cref="UnknownLayerOneBaseType"/>. </summary>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownLayerOneBaseType(LayerOneTypeName name, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(name, serializedAdditionalRawData)
        {
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="UnknownLayerOneBaseType"/> for deserialization. </summary>
        internal UnknownLayerOneBaseType()
        {
        }
    }
}
