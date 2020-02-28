// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class SearchModeExtensions
    {
        public static string ToSerialString(this SearchMode value) => value switch
        {
            SearchMode.Any => "any",
            SearchMode.All => "all",
            SearchMode.AnalyzingInfixMatching => "analyzingInfixMatching",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchMode value.")
        };

        public static SearchMode ToSearchMode(this string value) => value switch
        {
            "any" => SearchMode.Any,
            "all" => SearchMode.All,
            "analyzingInfixMatching" => SearchMode.AnalyzingInfixMatching,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchMode value.")
        };
    }
}
