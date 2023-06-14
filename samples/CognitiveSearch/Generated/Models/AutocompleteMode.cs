// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Specifies the mode for Autocomplete. The default is 'oneTerm'. Use 'twoTerms' to get shingles and 'oneTermWithContext' to use the current context in producing autocomplete terms. </summary>
    public enum AutocompleteMode
    {
        /// <summary> oneTerm. </summary>
        OneTerm,
        /// <summary> twoTerms. </summary>
        TwoTerms,
        /// <summary> oneTermWithContext. </summary>
        OneTermWithContext
    }
}
