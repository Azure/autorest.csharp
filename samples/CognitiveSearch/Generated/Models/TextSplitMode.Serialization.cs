// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class TextSplitModeExtensions
    {
        public static string ToSerialString(this TextSplitMode value) => value switch
        {
            TextSplitMode.Pages => "pages",
            TextSplitMode.Sentences => "sentences",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextSplitMode value.")
        };

        public static TextSplitMode ToTextSplitMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "pages")) return TextSplitMode.Pages;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "sentences")) return TextSplitMode.Sentences;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextSplitMode value.");
        }
    }
}
