// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataType { get; internal set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Description { get; set; }
    }
}
