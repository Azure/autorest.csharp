// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class TextExtractionAlgorithmExtensions
    {
        public static string ToSerialString(this TextExtractionAlgorithm value) => value switch
        {
            TextExtractionAlgorithm.Printed => "printed",
            TextExtractionAlgorithm.Handwritten => "handwritten",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextExtractionAlgorithm value.")
        };

        public static TextExtractionAlgorithm ToTextExtractionAlgorithm(this string value) => value switch
        {
            "printed" => TextExtractionAlgorithm.Printed,
            "handwritten" => TextExtractionAlgorithm.Handwritten,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextExtractionAlgorithm value.")
        };
    }
}
