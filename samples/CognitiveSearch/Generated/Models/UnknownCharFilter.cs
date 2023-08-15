// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Unknown version of CharFilter. </summary>
    internal partial class UnknownCharFilter : CharFilter
    {
        /// <summary> Initializes a new instance of UnknownCharFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal UnknownCharFilter(string odataType, string name) : base(odataType, name)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
