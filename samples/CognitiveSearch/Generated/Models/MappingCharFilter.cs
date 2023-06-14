// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A character filter that applies mappings defined with the mappings option. Matching is greedy (longest pattern matching at a given point wins). Replacement is allowed to be the empty string. This character filter is implemented using Apache Lucene. </summary>
    public partial class MappingCharFilter : CharFilter
    {
        /// <summary> Initializes a new instance of MappingCharFilter. </summary>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="mappings"> A list of mappings of the following format: "a=&gt;b" (all occurrences of the character "a" will be replaced with character "b"). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="mappings"/> is null. </exception>
        public MappingCharFilter(string name, IEnumerable<string> mappings) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(mappings, nameof(mappings));

            Mappings = mappings.ToList();
            OdataType = "#Microsoft.Azure.Search.MappingCharFilter";
        }

        /// <summary> Initializes a new instance of MappingCharFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="mappings"> A list of mappings of the following format: "a=&gt;b" (all occurrences of the character "a" will be replaced with character "b"). </param>
        internal MappingCharFilter(string odataType, string name, IList<string> mappings) : base(odataType, name)
        {
            Mappings = mappings;
            OdataType = odataType ?? "#Microsoft.Azure.Search.MappingCharFilter";
        }

        /// <summary> A list of mappings of the following format: "a=&gt;b" (all occurrences of the character "a" will be replaced with character "b"). </summary>
        public IList<string> Mappings { get; }
    }
}
