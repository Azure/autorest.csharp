// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Information about rollback on failed VM instances after a OS Upgrade operation.
    /// Serialized Name: RollbackStatusInfo
    /// </summary>
    public partial class RollbackStatusInfo
    {
        /// <summary> Initializes a new instance of RollbackStatusInfo. </summary>
        internal RollbackStatusInfo()
        {
        }

        /// <summary> Initializes a new instance of RollbackStatusInfo. </summary>
        /// <param name="successfullyRolledbackInstanceCount">
        /// The number of instances which have been successfully rolled back.
        /// Serialized Name: RollbackStatusInfo.successfullyRolledbackInstanceCount
        /// </param>
        /// <param name="failedRolledbackInstanceCount">
        /// The number of instances which failed to rollback.
        /// Serialized Name: RollbackStatusInfo.failedRolledbackInstanceCount
        /// </param>
        /// <param name="rollbackError">
        /// Error details if OS rollback failed.
        /// Serialized Name: RollbackStatusInfo.rollbackError
        /// </param>
        internal RollbackStatusInfo(int? successfullyRolledbackInstanceCount, int? failedRolledbackInstanceCount, ApiError rollbackError)
        {
            SuccessfullyRolledbackInstanceCount = successfullyRolledbackInstanceCount;
            FailedRolledbackInstanceCount = failedRolledbackInstanceCount;
            RollbackError = rollbackError;
        }

        /// <summary>
        /// The number of instances which have been successfully rolled back.
        /// Serialized Name: RollbackStatusInfo.successfullyRolledbackInstanceCount
        /// </summary>
        public int? SuccessfullyRolledbackInstanceCount { get; }
        /// <summary>
        /// The number of instances which failed to rollback.
        /// Serialized Name: RollbackStatusInfo.failedRolledbackInstanceCount
        /// </summary>
        public int? FailedRolledbackInstanceCount { get; }
        /// <summary>
        /// Error details if OS rollback failed.
        /// Serialized Name: RollbackStatusInfo.rollbackError
        /// </summary>
        public ApiError RollbackError { get; }
    }
}
