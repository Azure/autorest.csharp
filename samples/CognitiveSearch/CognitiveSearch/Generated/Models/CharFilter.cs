// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for character filters. </summary>
    public partial class CharFilter
    {
        /// <summary> Initializes a new instance of CharFilter. </summary>
        public CharFilter()
        {
            OdataType = null;
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataType { get; internal set; }
        /// <summary> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
