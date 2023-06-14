// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The configuration parameters used while performing a rolling upgrade.
    /// Serialized Name: RollingUpgradePolicy
    /// </summary>
    public partial class RollingUpgradePolicy
    {
        /// <summary> Initializes a new instance of RollingUpgradePolicy. </summary>
        public RollingUpgradePolicy()
        {
        }

        /// <summary> Initializes a new instance of RollingUpgradePolicy. </summary>
        /// <param name="maxBatchInstancePercent">
        /// The maximum percent of total virtual machine instances that will be upgraded simultaneously by the rolling upgrade in one batch. As this is a maximum, unhealthy instances in previous or future batches can cause the percentage of instances in a batch to decrease to ensure higher reliability. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxBatchInstancePercent
        /// </param>
        /// <param name="maxUnhealthyInstancePercent">
        /// The maximum percentage of the total virtual machine instances in the scale set that can be simultaneously unhealthy, either as a result of being upgraded, or by being found in an unhealthy state by the virtual machine health checks before the rolling upgrade aborts. This constraint will be checked prior to starting any batch. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxUnhealthyInstancePercent
        /// </param>
        /// <param name="maxUnhealthyUpgradedInstancePercent">
        /// The maximum percentage of upgraded virtual machine instances that can be found to be in an unhealthy state. This check will happen after each batch is upgraded. If this percentage is ever exceeded, the rolling update aborts. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxUnhealthyUpgradedInstancePercent
        /// </param>
        /// <param name="pauseTimeBetweenBatches">
        /// The wait time between completing the update for all virtual machines in one batch and starting the next batch. The time duration should be specified in ISO 8601 format. The default value is 0 seconds (PT0S).
        /// Serialized Name: RollingUpgradePolicy.pauseTimeBetweenBatches
        /// </param>
        internal RollingUpgradePolicy(int? maxBatchInstancePercent, int? maxUnhealthyInstancePercent, int? maxUnhealthyUpgradedInstancePercent, string pauseTimeBetweenBatches)
        {
            MaxBatchInstancePercent = maxBatchInstancePercent;
            MaxUnhealthyInstancePercent = maxUnhealthyInstancePercent;
            MaxUnhealthyUpgradedInstancePercent = maxUnhealthyUpgradedInstancePercent;
            PauseTimeBetweenBatches = pauseTimeBetweenBatches;
        }

        /// <summary>
        /// The maximum percent of total virtual machine instances that will be upgraded simultaneously by the rolling upgrade in one batch. As this is a maximum, unhealthy instances in previous or future batches can cause the percentage of instances in a batch to decrease to ensure higher reliability. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxBatchInstancePercent
        /// </summary>
        public int? MaxBatchInstancePercent { get; set; }
        /// <summary>
        /// The maximum percentage of the total virtual machine instances in the scale set that can be simultaneously unhealthy, either as a result of being upgraded, or by being found in an unhealthy state by the virtual machine health checks before the rolling upgrade aborts. This constraint will be checked prior to starting any batch. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxUnhealthyInstancePercent
        /// </summary>
        public int? MaxUnhealthyInstancePercent { get; set; }
        /// <summary>
        /// The maximum percentage of upgraded virtual machine instances that can be found to be in an unhealthy state. This check will happen after each batch is upgraded. If this percentage is ever exceeded, the rolling update aborts. The default value for this parameter is 20%.
        /// Serialized Name: RollingUpgradePolicy.maxUnhealthyUpgradedInstancePercent
        /// </summary>
        public int? MaxUnhealthyUpgradedInstancePercent { get; set; }
        /// <summary>
        /// The wait time between completing the update for all virtual machines in one batch and starting the next batch. The time duration should be specified in ISO 8601 format. The default value is 0 seconds (PT0S).
        /// Serialized Name: RollingUpgradePolicy.pauseTimeBetweenBatches
        /// </summary>
        public string PauseTimeBetweenBatches { get; set; }
    }
}
