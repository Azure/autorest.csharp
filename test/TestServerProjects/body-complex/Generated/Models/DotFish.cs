// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    /// <summary>
    /// The DotFish.
    /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DotSalmon"/>.
    /// </summary>
    [DeserializationProxy(typeof(UnknownDotFish))]
    public abstract partial class DotFish
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DotFish"/>. </summary>
        protected DotFish()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DotFish"/>. </summary>
        /// <param name="fishType"></param>
        /// <param name="species"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DotFish(string fishType, string species, Dictionary<string, BinaryData> rawData)
        {
            FishType = fishType;
            Species = species;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the fish type. </summary>
        internal string FishType { get; set; }
        /// <summary> Gets the species. </summary>
        public string Species { get; }
    }
}
