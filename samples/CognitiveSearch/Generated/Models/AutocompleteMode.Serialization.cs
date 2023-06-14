// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class AutocompleteModeExtensions
    {
        public static string ToSerialString(this AutocompleteMode value) => value switch
        {
            AutocompleteMode.OneTerm => "oneTerm",
            AutocompleteMode.TwoTerms => "twoTerms",
            AutocompleteMode.OneTermWithContext => "oneTermWithContext",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AutocompleteMode value.")
        };

        public static AutocompleteMode ToAutocompleteMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "oneTerm")) return AutocompleteMode.OneTerm;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "twoTerms")) return AutocompleteMode.TwoTerms;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "oneTermWithContext")) return AutocompleteMode.OneTermWithContext;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AutocompleteMode value.");
        }
    }
}
