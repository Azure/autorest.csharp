// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownTokenFilter. </summary>
    internal partial class UnknownTokenFilter : TokenFilter
    {
        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.UnknownTokenFilter
        ///
        /// </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownTokenFilter(string odataType, string name, Dictionary<string, BinaryData> rawData) : base(odataType, name, rawData)
        {
            OdataType = odataType ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownTokenFilter"/> for deserialization. </summary>
        internal UnknownTokenFilter()
        {
        }
    }
}
