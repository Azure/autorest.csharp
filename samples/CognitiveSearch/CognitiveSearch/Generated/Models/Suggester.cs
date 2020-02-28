// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Defines how the Suggest API should apply to a group of fields in the index. </summary>
    public partial class Suggester
    {
        /// <summary> The name of the suggester. </summary>
        public string Name { get; set; }
        /// <summary> A value indicating the capabilities of the suggester. </summary>
        public SearchMode SearchMode { get; set; }
        /// <summary> The list of field names to which the suggester applies. Each field must be searchable. </summary>
        public ICollection<string> SourceFields { get; set; } = new System.Collections.Generic.List<string>();
    }
}
