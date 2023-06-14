// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Response after calling a manual recovery walk
    /// Serialized Name: RecoveryWalkResponse
    /// </summary>
    public partial class RecoveryWalkResponse
    {
        /// <summary> Initializes a new instance of RecoveryWalkResponse. </summary>
        internal RecoveryWalkResponse()
        {
        }

        /// <summary> Initializes a new instance of RecoveryWalkResponse. </summary>
        /// <param name="walkPerformed">
        /// Whether the recovery walk was performed
        /// Serialized Name: RecoveryWalkResponse.walkPerformed
        /// </param>
        /// <param name="nextPlatformUpdateDomain">
        /// The next update domain that needs to be walked. Null means walk spanning all update domains has been completed
        /// Serialized Name: RecoveryWalkResponse.nextPlatformUpdateDomain
        /// </param>
        internal RecoveryWalkResponse(bool? walkPerformed, int? nextPlatformUpdateDomain)
        {
            WalkPerformed = walkPerformed;
            NextPlatformUpdateDomain = nextPlatformUpdateDomain;
        }

        /// <summary>
        /// Whether the recovery walk was performed
        /// Serialized Name: RecoveryWalkResponse.walkPerformed
        /// </summary>
        public bool? WalkPerformed { get; }
        /// <summary>
        /// The next update domain that needs to be walked. Null means walk spanning all update domains has been completed
        /// Serialized Name: RecoveryWalkResponse.nextPlatformUpdateDomain
        /// </summary>
        public int? NextPlatformUpdateDomain { get; }
    }
}
