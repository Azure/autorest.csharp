// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownCognitiveServicesAccount. </summary>
    internal partial class UnknownCognitiveServicesAccount : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of <see cref="UnknownCognitiveServicesAccount"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownCognitiveServicesAccount(string odataType, string description, Dictionary<string, BinaryData> rawData) : base(odataType, description, rawData)
        {
            OdataType = odataType ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownCognitiveServicesAccount"/> for deserialization. </summary>
        internal UnknownCognitiveServicesAccount()
        {
        }
    }
}
