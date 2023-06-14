// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class OperationStatusExtensions
    {
        public static string ToSerialString(this OperationStatus value) => value switch
        {
            OperationStatus.NotStarted => "notStarted",
            OperationStatus.Running => "running",
            OperationStatus.Succeeded => "succeeded",
            OperationStatus.Failed => "failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperationStatus value.")
        };

        public static OperationStatus ToOperationStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "notStarted")) return OperationStatus.NotStarted;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "running")) return OperationStatus.Running;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "succeeded")) return OperationStatus.Succeeded;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "failed")) return OperationStatus.Failed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperationStatus value.");
        }
    }
}
