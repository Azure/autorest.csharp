// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for describing any cognitive service resource attached to the skillset. </summary>
    public partial class CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        public CognitiveServicesAccount()
        {
            OdataType = null;
        }

        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        /// <param name="odataType"> . </param>
        /// <param name="description"> . </param>
        internal CognitiveServicesAccount(string odataType, string description)
        {
            OdataType = odataType ?? null;
            Description = description;
        }

        internal string OdataType { get; set; }
        public string Description { get; set; }
    }
}
