// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class ScoringFunctionAggregationExtensions
    {
        public static string ToSerialString(this ScoringFunctionAggregation value) => value switch
        {
            ScoringFunctionAggregation.Sum => "sum",
            ScoringFunctionAggregation.Average => "average",
            ScoringFunctionAggregation.Minimum => "minimum",
            ScoringFunctionAggregation.Maximum => "maximum",
            ScoringFunctionAggregation.FirstMatching => "firstMatching",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionAggregation value.")
        };

        public static ScoringFunctionAggregation ToScoringFunctionAggregation(this string value)
        {
            if (string.Equals(value, "sum", StringComparison.InvariantCultureIgnoreCase)) return ScoringFunctionAggregation.Sum;
            if (string.Equals(value, "average", StringComparison.InvariantCultureIgnoreCase)) return ScoringFunctionAggregation.Average;
            if (string.Equals(value, "minimum", StringComparison.InvariantCultureIgnoreCase)) return ScoringFunctionAggregation.Minimum;
            if (string.Equals(value, "maximum", StringComparison.InvariantCultureIgnoreCase)) return ScoringFunctionAggregation.Maximum;
            if (string.Equals(value, "firstMatching", StringComparison.InvariantCultureIgnoreCase)) return ScoringFunctionAggregation.FirstMatching;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionAggregation value.");
        }
    }
}
