// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtScopeResource.Models
{
    internal static partial class DeploymentModeExtensions
    {
        public static string ToSerialString(this DeploymentMode value) => value switch
        {
            DeploymentMode.Incremental => "Incremental",
            DeploymentMode.Complete => "Complete",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DeploymentMode value.")
        };

        public static DeploymentMode ToDeploymentMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Incremental")) return DeploymentMode.Incremental;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Complete")) return DeploymentMode.Complete;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DeploymentMode value.");
        }
    }
}
