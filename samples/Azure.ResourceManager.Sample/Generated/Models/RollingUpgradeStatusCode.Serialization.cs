// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class RollingUpgradeStatusCodeExtensions
    {
        public static string ToSerialString(this RollingUpgradeStatusCode value) => value switch
        {
            RollingUpgradeStatusCode.RollingForward => "RollingForward",
            RollingUpgradeStatusCode.Cancelled => "Cancelled",
            RollingUpgradeStatusCode.Completed => "Completed",
            RollingUpgradeStatusCode.Faulted => "Faulted",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeStatusCode value.")
        };

        public static RollingUpgradeStatusCode ToRollingUpgradeStatusCode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RollingForward")) return RollingUpgradeStatusCode.RollingForward;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cancelled")) return RollingUpgradeStatusCode.Cancelled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Completed")) return RollingUpgradeStatusCode.Completed;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Faulted")) return RollingUpgradeStatusCode.Faulted;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeStatusCode value.");
        }
    }
}
