// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "sum")) return ScoringFunctionAggregation.Sum;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "average")) return ScoringFunctionAggregation.Average;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimum")) return ScoringFunctionAggregation.Minimum;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "maximum")) return ScoringFunctionAggregation.Maximum;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "firstMatching")) return ScoringFunctionAggregation.FirstMatching;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionAggregation value.");
        }
    }
}
