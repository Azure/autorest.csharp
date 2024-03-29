// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The DotSalmon. </summary>
    public partial class DotSalmon : DotFish
    {
        /// <summary> Initializes a new instance of <see cref="DotSalmon"/>. </summary>
        internal DotSalmon()
        {
            FishType = "DotSalmon";
        }

        /// <summary> Initializes a new instance of <see cref="DotSalmon"/>. </summary>
        /// <param name="fishType"></param>
        /// <param name="species"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="location"></param>
        /// <param name="iswild"></param>
        internal DotSalmon(string fishType, string species, IDictionary<string, BinaryData> serializedAdditionalRawData, string location, bool? iswild) : base(fishType, species, serializedAdditionalRawData)
        {
            Location = location;
            Iswild = iswild;
            FishType = fishType ?? "DotSalmon";
        }

        /// <summary> Gets the location. </summary>
        public string Location { get; }
        /// <summary> Gets the iswild. </summary>
        public bool? Iswild { get; }
    }
}
