// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class TextExtractionAlgorithmExtensions
    {
        public static string ToSerialString(this TextExtractionAlgorithm value) => value switch
        {
            TextExtractionAlgorithm.Printed => "printed",
            TextExtractionAlgorithm.Handwritten => "handwritten",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextExtractionAlgorithm value.")
        };

        public static TextExtractionAlgorithm ToTextExtractionAlgorithm(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "printed")) return TextExtractionAlgorithm.Printed;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "handwritten")) return TextExtractionAlgorithm.Handwritten;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextExtractionAlgorithm value.");
        }
    }
}
