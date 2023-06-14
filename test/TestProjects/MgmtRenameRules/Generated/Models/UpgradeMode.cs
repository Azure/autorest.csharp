// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the mode of an upgrade to virtual machines in the scale set.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **Manual** - You  control the application of updates to virtual machines in the scale set. You do this by using the manualUpgrade action.&lt;br /&gt;&lt;br /&gt; **Automatic** - All virtual machines in the scale set are  automatically updated at the same time.
    /// Serialized Name: UpgradeMode
    /// </summary>
    public enum UpgradeMode
    {
        /// <summary>
        /// Automatic
        /// Serialized Name: UpgradeMode.Automatic
        /// </summary>
        Automatic,
        /// <summary>
        /// Manual
        /// Serialized Name: UpgradeMode.Manual
        /// </summary>
        Manual,
        /// <summary>
        /// Rolling
        /// Serialized Name: UpgradeMode.Rolling
        /// </summary>
        Rolling
    }
}
