// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines how the Suggest API should apply to a group of fields in the index. </summary>
    public partial class Suggester
    {
        /// <summary> Initializes a new instance of Suggester. </summary>
        /// <param name="name"> The name of the suggester. </param>
        /// <param name="searchMode"> A value indicating the capabilities of the suggester. </param>
        /// <param name="sourceFields"> The list of field names to which the suggester applies. Each field must be searchable. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="sourceFields"/> is null. </exception>
        public Suggester(string name, SearchMode searchMode, IEnumerable<string> sourceFields)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(sourceFields, nameof(sourceFields));

            Name = name;
            SearchMode = searchMode;
            SourceFields = sourceFields.ToList();
        }

        /// <summary> Initializes a new instance of Suggester. </summary>
        /// <param name="name"> The name of the suggester. </param>
        /// <param name="searchMode"> A value indicating the capabilities of the suggester. </param>
        /// <param name="sourceFields"> The list of field names to which the suggester applies. Each field must be searchable. </param>
        internal Suggester(string name, SearchMode searchMode, IList<string> sourceFields)
        {
            Name = name;
            SearchMode = searchMode;
            SourceFields = sourceFields;
        }

        /// <summary> The name of the suggester. </summary>
        public string Name { get; set; }
        /// <summary> A value indicating the capabilities of the suggester. </summary>
        public SearchMode SearchMode { get; set; }
        /// <summary> The list of field names to which the suggester applies. Each field must be searchable. </summary>
        public IList<string> SourceFields { get; }
    }
}
