// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Lease Container request schema. </summary>
    public partial class LeaseContainerContent
    {
        /// <summary> Initializes a new instance of LeaseContainerContent. </summary>
        /// <param name="action"> Specifies the lease action. Can be one of the available actions. </param>
        public LeaseContainerContent(LeaseContainerRequestAction action)
        {
            Action = action;
        }

        /// <summary> Specifies the lease action. Can be one of the available actions. </summary>
        public LeaseContainerRequestAction Action { get; }
        /// <summary> Identifies the lease. Can be specified in any valid GUID string format. </summary>
        public string LeaseId { get; set; }
        /// <summary> Optional. For a break action, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. </summary>
        public int? BreakPeriod { get; set; }
        /// <summary> Required for acquire. Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. </summary>
        public int? LeaseDuration { get; set; }
        /// <summary> Optional for acquire, required for change. Proposed lease ID, in a GUID string format. </summary>
        public string ProposedLeaseId { get; set; }
    }
}
