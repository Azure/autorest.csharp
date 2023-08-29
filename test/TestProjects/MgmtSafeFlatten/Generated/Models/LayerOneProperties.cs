// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneProperties. </summary>
    internal partial class LayerOneProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="LayerOneProperties"/>. </summary>
        internal LayerOneProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LayerOneProperties"/>. </summary>
        /// <param name="uniqueId"> The id of layer one. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal LayerOneProperties(string uniqueId, Dictionary<string, BinaryData> rawData)
        {
            UniqueId = uniqueId;
            _rawData = rawData;
        }

        /// <summary> The id of layer one. </summary>
        public string UniqueId { get; }
    }
}
