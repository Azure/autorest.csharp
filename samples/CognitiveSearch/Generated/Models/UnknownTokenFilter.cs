// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownTokenFilter. </summary>
    internal partial class UnknownTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of UnknownTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal UnknownTokenFilter(string odataType, string name) : base(odataType, name)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
