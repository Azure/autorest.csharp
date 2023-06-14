// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class TrainStatusExtensions
    {
        public static string ToSerialString(this TrainStatus value) => value switch
        {
            TrainStatus.Succeeded => "succeeded",
            TrainStatus.PartiallySucceeded => "partiallySucceeded",
            TrainStatus.Failed => "failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TrainStatus value.")
        };

        public static TrainStatus ToTrainStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "succeeded")) return TrainStatus.Succeeded;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "partiallySucceeded")) return TrainStatus.PartiallySucceeded;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "failed")) return TrainStatus.Failed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TrainStatus value.");
        }
    }
}
