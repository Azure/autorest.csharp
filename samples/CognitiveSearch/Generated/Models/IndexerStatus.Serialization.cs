// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class IndexerStatusExtensions
    {
        public static string ToSerialString(this IndexerStatus value) => value switch
        {
            IndexerStatus.Unknown => "unknown",
            IndexerStatus.Error => "error",
            IndexerStatus.Running => "running",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerStatus value.")
        };

        public static IndexerStatus ToIndexerStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "unknown")) return IndexerStatus.Unknown;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "error")) return IndexerStatus.Error;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "running")) return IndexerStatus.Running;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerStatus value.");
        }
    }
}
