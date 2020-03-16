// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for character filters. </summary>
    public partial class CharFilter
    {
        /// <summary> Initializes a new instance of CharFilter. </summary>
        internal CharFilter()
        {
        }
        /// <summary> Initializes a new instance of CharFilter. </summary>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal CharFilter(string odataType, string name)
        {
            OdataType = odataType;
            Name = name;
        }
        public string OdataType { get; internal set; }
        /// <summary> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
