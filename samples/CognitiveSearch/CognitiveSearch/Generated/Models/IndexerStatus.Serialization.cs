// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class IndexerStatusExtensions
    {
        public static string ToSerialString(this IndexerStatus value) => value switch
        {
            IndexerStatus.Unknown => "unknown",
            IndexerStatus.Error => "error",
            IndexerStatus.Running => "running",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerStatus value.")
        };

        public static IndexerStatus ToIndexerStatus(this string value) => value switch
        {
            "unknown" => IndexerStatus.Unknown,
            "error" => IndexerStatus.Error,
            "running" => IndexerStatus.Running,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerStatus value.")
        };
    }
}
