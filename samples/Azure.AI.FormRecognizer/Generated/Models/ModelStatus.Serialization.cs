// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class ModelStatusExtensions
    {
        public static string ToSerialString(this ModelStatus value) => value switch
        {
            ModelStatus.Creating => "creating",
            ModelStatus.Ready => "ready",
            ModelStatus.Invalid => "invalid",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ModelStatus value.")
        };

        public static ModelStatus ToModelStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "creating")) return ModelStatus.Creating;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ready")) return ModelStatus.Ready;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalid")) return ModelStatus.Invalid;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ModelStatus value.");
        }
    }
}
