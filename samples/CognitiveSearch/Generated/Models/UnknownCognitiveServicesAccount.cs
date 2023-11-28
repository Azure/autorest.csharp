// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownCognitiveServicesAccount. </summary>
    internal partial class UnknownCognitiveServicesAccount : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of <see cref="UnknownCognitiveServicesAccount"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        internal UnknownCognitiveServicesAccount(string odataType, string description) : base(odataType, description)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
