// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class ScoringFunctionAggregationExtensions
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

        public static ScoringFunctionAggregation ToScoringFunctionAggregation(this string value) => value switch
        {
            "sum" => ScoringFunctionAggregation.Sum,
            "average" => ScoringFunctionAggregation.Average,
            "minimum" => ScoringFunctionAggregation.Minimum,
            "maximum" => ScoringFunctionAggregation.Maximum,
            "firstMatching" => ScoringFunctionAggregation.FirstMatching,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionAggregation value.")
        };
    }
}
