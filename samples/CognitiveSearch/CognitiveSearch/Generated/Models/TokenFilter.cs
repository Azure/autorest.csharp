// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for token filters. </summary>
    public partial class TokenFilter
    {
        /// <summary> Initializes a new instance of TokenFilter. </summary>
        public TokenFilter()
        {
            OdataType = null;
        }
        public string OdataType { get; internal set; }
        /// <summary> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
