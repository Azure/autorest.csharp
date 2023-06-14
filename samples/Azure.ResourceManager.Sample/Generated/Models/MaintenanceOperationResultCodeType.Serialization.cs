// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class MaintenanceOperationResultCodeTypeExtensions
    {
        public static string ToSerialString(this MaintenanceOperationResultCodeType value) => value switch
        {
            MaintenanceOperationResultCodeType.None => "None",
            MaintenanceOperationResultCodeType.RetryLater => "RetryLater",
            MaintenanceOperationResultCodeType.MaintenanceAborted => "MaintenanceAborted",
            MaintenanceOperationResultCodeType.MaintenanceCompleted => "MaintenanceCompleted",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MaintenanceOperationResultCodeType value.")
        };

        public static MaintenanceOperationResultCodeType ToMaintenanceOperationResultCodeType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return MaintenanceOperationResultCodeType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RetryLater")) return MaintenanceOperationResultCodeType.RetryLater;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "MaintenanceAborted")) return MaintenanceOperationResultCodeType.MaintenanceAborted;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "MaintenanceCompleted")) return MaintenanceOperationResultCodeType.MaintenanceCompleted;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MaintenanceOperationResultCodeType value.");
        }
    }
}
