// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the configuration parameters for automatic repairs on the virtual machine scale set.
    /// Serialized Name: AutomaticRepairsPolicy
    /// </summary>
    public partial class AutomaticRepairsPolicy
    {
        /// <summary> Initializes a new instance of AutomaticRepairsPolicy. </summary>
        public AutomaticRepairsPolicy()
        {
        }

        /// <summary> Initializes a new instance of AutomaticRepairsPolicy. </summary>
        /// <param name="enabled">
        /// Specifies whether automatic repairs should be enabled on the virtual machine scale set. The default value is false.
        /// Serialized Name: AutomaticRepairsPolicy.enabled
        /// </param>
        /// <param name="gracePeriod">
        /// The amount of time for which automatic repairs are suspended due to a state change on VM. The grace time starts after the state change has completed. This helps avoid premature or accidental repairs. The time duration should be specified in ISO 8601 format. The minimum allowed grace period is 30 minutes (PT30M), which is also the default value. The maximum allowed grace period is 90 minutes (PT90M).
        /// Serialized Name: AutomaticRepairsPolicy.gracePeriod
        /// </param>
        internal AutomaticRepairsPolicy(bool? enabled, string gracePeriod)
        {
            Enabled = enabled;
            GracePeriod = gracePeriod;
        }

        /// <summary>
        /// Specifies whether automatic repairs should be enabled on the virtual machine scale set. The default value is false.
        /// Serialized Name: AutomaticRepairsPolicy.enabled
        /// </summary>
        public bool? Enabled { get; set; }
        /// <summary>
        /// The amount of time for which automatic repairs are suspended due to a state change on VM. The grace time starts after the state change has completed. This helps avoid premature or accidental repairs. The time duration should be specified in ISO 8601 format. The minimum allowed grace period is 30 minutes (PT30M), which is also the default value. The maximum allowed grace period is 90 minutes (PT90M).
        /// Serialized Name: AutomaticRepairsPolicy.gracePeriod
        /// </summary>
        public string GracePeriod { get; set; }
    }
}
