// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The result of Autocomplete query. </summary>
    public partial class AutocompleteResult
    {
        /// <summary> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </summary>
        public double? Coverage { get; internal set; }
        /// <summary> The list of returned Autocompleted items. </summary>
        public ICollection<AutocompleteItem>? Results { get; internal set; }
    }
}
