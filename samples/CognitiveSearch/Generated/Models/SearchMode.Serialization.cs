// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class SearchModeExtensions
    {
        public static string ToSerialString(this SearchMode value) => value switch
        {
            SearchMode.Any => "any",
            SearchMode.All => "all",
            SearchMode.AnalyzingInfixMatching => "analyzingInfixMatching",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchMode value.")
        };

        public static SearchMode ToSearchMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "any")) return SearchMode.Any;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "all")) return SearchMode.All;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "analyzingInfixMatching")) return SearchMode.AnalyzingInfixMatching;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchMode value.");
        }
    }
}
