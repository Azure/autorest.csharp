// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class EdgeNGramTokenFilterSideExtensions
    {
        public static string ToSerialString(this EdgeNGramTokenFilterSide value) => value switch
        {
            EdgeNGramTokenFilterSide.Front => "front",
            EdgeNGramTokenFilterSide.Back => "back",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EdgeNGramTokenFilterSide value.")
        };

        public static EdgeNGramTokenFilterSide ToEdgeNGramTokenFilterSide(this string value) => value switch
        {
            "front" => EdgeNGramTokenFilterSide.Front,
            "back" => EdgeNGramTokenFilterSide.Back,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EdgeNGramTokenFilterSide value.")
        };
    }
}
