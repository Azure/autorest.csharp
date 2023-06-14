// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes an upgrade policy - automatic, manual, or rolling.
    /// Serialized Name: UpgradePolicy
    /// </summary>
    public partial class UpgradePolicy
    {
        /// <summary> Initializes a new instance of UpgradePolicy. </summary>
        public UpgradePolicy()
        {
        }

        /// <summary> Initializes a new instance of UpgradePolicy. </summary>
        /// <param name="mode">
        /// Specifies the mode of an upgrade to virtual machines in the scale set.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **Manual** - You  control the application of updates to virtual machines in the scale set. You do this by using the manualUpgrade action.&lt;br /&gt;&lt;br /&gt; **Automatic** - All virtual machines in the scale set are  automatically updated at the same time.
        /// Serialized Name: UpgradePolicy.mode
        /// </param>
        /// <param name="rollingUpgradePolicy">
        /// The configuration parameters used while performing a rolling upgrade.
        /// Serialized Name: UpgradePolicy.rollingUpgradePolicy
        /// </param>
        /// <param name="automaticOSUpgradePolicy">
        /// Configuration parameters used for performing automatic OS Upgrade.
        /// Serialized Name: UpgradePolicy.automaticOSUpgradePolicy
        /// </param>
        internal UpgradePolicy(UpgradeMode? mode, RollingUpgradePolicy rollingUpgradePolicy, AutomaticOSUpgradePolicy automaticOSUpgradePolicy)
        {
            Mode = mode;
            RollingUpgradePolicy = rollingUpgradePolicy;
            AutomaticOSUpgradePolicy = automaticOSUpgradePolicy;
        }

        /// <summary>
        /// Specifies the mode of an upgrade to virtual machines in the scale set.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **Manual** - You  control the application of updates to virtual machines in the scale set. You do this by using the manualUpgrade action.&lt;br /&gt;&lt;br /&gt; **Automatic** - All virtual machines in the scale set are  automatically updated at the same time.
        /// Serialized Name: UpgradePolicy.mode
        /// </summary>
        public UpgradeMode? Mode { get; set; }
        /// <summary>
        /// The configuration parameters used while performing a rolling upgrade.
        /// Serialized Name: UpgradePolicy.rollingUpgradePolicy
        /// </summary>
        public RollingUpgradePolicy RollingUpgradePolicy { get; set; }
        /// <summary>
        /// Configuration parameters used for performing automatic OS Upgrade.
        /// Serialized Name: UpgradePolicy.automaticOSUpgradePolicy
        /// </summary>
        public AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get; set; }
    }
}
