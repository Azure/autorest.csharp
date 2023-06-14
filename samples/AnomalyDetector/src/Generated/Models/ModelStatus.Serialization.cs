// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace AnomalyDetector.Models
{
    internal static partial class ModelStatusExtensions
    {
        public static string ToSerialString(this ModelStatus value) => value switch
        {
            ModelStatus.Created => "CREATED",
            ModelStatus.Running => "RUNNING",
            ModelStatus.Ready => "READY",
            ModelStatus.Failed => "FAILED",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ModelStatus value.")
        };

        public static ModelStatus ToModelStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CREATED")) return ModelStatus.Created;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RUNNING")) return ModelStatus.Running;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "READY")) return ModelStatus.Ready;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "FAILED")) return ModelStatus.Failed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ModelStatus value.");
        }
    }
}
