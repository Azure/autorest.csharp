// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSafeFlatten.Models
{
    /// <summary> The UnknownLayerOneBaseType. </summary>
    internal partial class UnknownLayerOneBaseType : LayerOneBaseType
    {
        /// <summary> Initializes a new instance of UnknownLayerOneBaseType. </summary>
        /// <param name="name"></param>
        internal UnknownLayerOneBaseType(LayerOneTypeName name) : base(name)
        {
            Name = name;
        }
    }
}
