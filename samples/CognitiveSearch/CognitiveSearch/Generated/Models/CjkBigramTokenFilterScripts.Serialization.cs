// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    internal static class CjkBigramTokenFilterScriptsExtensions
    {
        public static string ToSerialString(this CjkBigramTokenFilterScripts value) => value switch
        {
            CjkBigramTokenFilterScripts.Han => "han",
            CjkBigramTokenFilterScripts.Hiragana => "hiragana",
            CjkBigramTokenFilterScripts.Katakana => "katakana",
            CjkBigramTokenFilterScripts.Hangul => "hangul",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CjkBigramTokenFilterScripts value.")
        };

        public static CjkBigramTokenFilterScripts ToCjkBigramTokenFilterScripts(this string value) => value switch
        {
            "han" => CjkBigramTokenFilterScripts.Han,
            "hiragana" => CjkBigramTokenFilterScripts.Hiragana,
            "katakana" => CjkBigramTokenFilterScripts.Katakana,
            "hangul" => CjkBigramTokenFilterScripts.Hangul,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CjkBigramTokenFilterScripts value.")
        };
    }
}
