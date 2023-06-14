// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class IndexerExecutionStatusExtensions
    {
        public static string ToSerialString(this IndexerExecutionStatus value) => value switch
        {
            IndexerExecutionStatus.TransientFailure => "transientFailure",
            IndexerExecutionStatus.Success => "success",
            IndexerExecutionStatus.InProgress => "inProgress",
            IndexerExecutionStatus.Reset => "reset",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerExecutionStatus value.")
        };

        public static IndexerExecutionStatus ToIndexerExecutionStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "transientFailure")) return IndexerExecutionStatus.TransientFailure;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "success")) return IndexerExecutionStatus.Success;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "inProgress")) return IndexerExecutionStatus.InProgress;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "reset")) return IndexerExecutionStatus.Reset;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IndexerExecutionStatus value.");
        }
    }
}
