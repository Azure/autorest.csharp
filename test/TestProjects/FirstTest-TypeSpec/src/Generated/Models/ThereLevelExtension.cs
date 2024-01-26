// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace FirstTestTypeSpec.Models
{
    /// <summary> extension. </summary>
    public partial class ThereLevelExtension : ThereLevelElement
    {
        /// <summary> Initializes a new instance of <see cref="ThereLevelExtension"/>. </summary>
        /// <param name="level"></param>
        public ThereLevelExtension(int level)
        {
            Level = level;
        }

        /// <summary> Initializes a new instance of <see cref="ThereLevelExtension"/>. </summary>
        /// <param name="extension"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="level"></param>
        internal ThereLevelExtension(IReadOnlyList<ThereLevelExtension> extension, IDictionary<string, BinaryData> serializedAdditionalRawData, int level) : base(extension, serializedAdditionalRawData)
        {
            Level = level;
        }

        /// <summary> Initializes a new instance of <see cref="ThereLevelExtension"/> for deserialization. </summary>
        internal ThereLevelExtension()
        {
        }

        /// <summary> Gets the level. </summary>
        public int Level { get; }
    }
}
