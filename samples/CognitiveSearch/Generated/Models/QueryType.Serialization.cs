// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class QueryTypeExtensions
    {
        public static string ToSerialString(this QueryType value) => value switch
        {
            QueryType.Simple => "simple",
            QueryType.Full => "full",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown QueryType value.")
        };

        public static QueryType ToQueryType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "simple")) return QueryType.Simple;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "full")) return QueryType.Full;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown QueryType value.");
        }
    }
}
