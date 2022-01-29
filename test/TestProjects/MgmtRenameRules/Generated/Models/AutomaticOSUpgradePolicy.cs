// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary> The configuration parameters used for performing automatic OS upgrade. </summary>
    public partial class AutomaticOSUpgradePolicy
    {
        /// <summary> Initializes a new instance of AutomaticOSUpgradePolicy. </summary>
        public AutomaticOSUpgradePolicy()
        {
        }

        /// <summary> Initializes a new instance of AutomaticOSUpgradePolicy. </summary>
        /// <param name="enableAutomaticOSUpgrade"> Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available. Default value is false. &lt;br&gt;&lt;br&gt; If this is set to true for Windows based scale sets, [enableAutomaticUpdates](https://docs.microsoft.com/dotnet/api/microsoft.azure.management.compute.models.windowsconfiguration.enableautomaticupdates?view=azure-dotnet) is automatically set to false and cannot be set to true. </param>
        /// <param name="disableAutomaticRollback"> Whether OS image rollback feature should be disabled. Default value is false. </param>
        internal AutomaticOSUpgradePolicy(bool? enableAutomaticOSUpgrade, bool? disableAutomaticRollback)
        {
            EnableAutomaticOSUpgrade = enableAutomaticOSUpgrade;
            DisableAutomaticRollback = disableAutomaticRollback;
        }

        /// <summary> Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available. Default value is false. &lt;br&gt;&lt;br&gt; If this is set to true for Windows based scale sets, [enableAutomaticUpdates](https://docs.microsoft.com/dotnet/api/microsoft.azure.management.compute.models.windowsconfiguration.enableautomaticupdates?view=azure-dotnet) is automatically set to false and cannot be set to true. </summary>
        public bool? EnableAutomaticOSUpgrade { get; set; }
        /// <summary> Whether OS image rollback feature should be disabled. Default value is false. </summary>
        public bool? DisableAutomaticRollback { get; set; }
    }
}
