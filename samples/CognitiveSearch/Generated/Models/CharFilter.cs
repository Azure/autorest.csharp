// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for character filters.
    /// Please note <see cref="CharFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="MappingCharFilter"/> and <see cref="PatternReplaceCharFilter"/>.
    /// </summary>
    public partial class CharFilter
    {
        /// <summary> Initializes a new instance of CharFilter. </summary>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public CharFilter(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of CharFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal CharFilter(string odataType, string name)
        {
            OdataType = odataType;
            Name = name;
        }

        /// <summary> Identifies the concrete type of the char filter. </summary>
        internal string OdataType { get; set; }
        /// <summary> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
