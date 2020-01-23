// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    internal static class TextSplitModeExtensions
    {
        public static string ToSerialString(this TextSplitMode value) => value switch
        {
            TextSplitMode.Pages => "pages",
            TextSplitMode.Sentences => "sentences",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextSplitMode value.")
        };

        public static TextSplitMode ToTextSplitMode(this string value) => value switch
        {
            "pages" => TextSplitMode.Pages,
            "sentences" => TextSplitMode.Sentences,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TextSplitMode value.")
        };
    }
}
