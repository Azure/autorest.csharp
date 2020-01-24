// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    internal static class ScoringFunctionInterpolationExtensions
    {
        public static string ToSerialString(this ScoringFunctionInterpolation value) => value switch
        {
            ScoringFunctionInterpolation.Linear => "linear",
            ScoringFunctionInterpolation.Constant => "constant",
            ScoringFunctionInterpolation.Quadratic => "quadratic",
            ScoringFunctionInterpolation.Logarithmic => "logarithmic",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionInterpolation value.")
        };

        public static ScoringFunctionInterpolation ToScoringFunctionInterpolation(this string value) => value switch
        {
            "linear" => ScoringFunctionInterpolation.Linear,
            "constant" => ScoringFunctionInterpolation.Constant,
            "quadratic" => ScoringFunctionInterpolation.Quadratic,
            "logarithmic" => ScoringFunctionInterpolation.Logarithmic,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ScoringFunctionInterpolation value.")
        };
    }
}
