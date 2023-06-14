// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtScopeResource.Models
{
    internal static partial class ProvisioningOperationExtensions
    {
        public static string ToSerialString(this ProvisioningOperation value) => value switch
        {
            ProvisioningOperation.NotSpecified => "NotSpecified",
            ProvisioningOperation.Create => "Create",
            ProvisioningOperation.Delete => "Delete",
            ProvisioningOperation.Waiting => "Waiting",
            ProvisioningOperation.AzureAsyncOperationWaiting => "AzureAsyncOperationWaiting",
            ProvisioningOperation.ResourceCacheWaiting => "ResourceCacheWaiting",
            ProvisioningOperation.Action => "Action",
            ProvisioningOperation.Read => "Read",
            ProvisioningOperation.EvaluateDeploymentOutput => "EvaluateDeploymentOutput",
            ProvisioningOperation.DeploymentCleanup => "DeploymentCleanup",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProvisioningOperation value.")
        };

        public static ProvisioningOperation ToProvisioningOperation(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "NotSpecified")) return ProvisioningOperation.NotSpecified;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Create")) return ProvisioningOperation.Create;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Delete")) return ProvisioningOperation.Delete;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Waiting")) return ProvisioningOperation.Waiting;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AzureAsyncOperationWaiting")) return ProvisioningOperation.AzureAsyncOperationWaiting;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ResourceCacheWaiting")) return ProvisioningOperation.ResourceCacheWaiting;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Action")) return ProvisioningOperation.Action;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Read")) return ProvisioningOperation.Read;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "EvaluateDeploymentOutput")) return ProvisioningOperation.EvaluateDeploymentOutput;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "DeploymentCleanup")) return ProvisioningOperation.DeploymentCleanup;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProvisioningOperation value.");
        }
    }
}
