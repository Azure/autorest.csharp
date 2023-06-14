// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The Last Maintenance Operation Result Code.
    /// Serialized Name: MaintenanceOperationResultCodeTypes
    /// </summary>
    public enum MaintenanceOperationResultCodeType
    {
        /// <summary>
        /// None
        /// Serialized Name: MaintenanceOperationResultCodeTypes.None
        /// </summary>
        None,
        /// <summary>
        /// RetryLater
        /// Serialized Name: MaintenanceOperationResultCodeTypes.RetryLater
        /// </summary>
        RetryLater,
        /// <summary>
        /// MaintenanceAborted
        /// Serialized Name: MaintenanceOperationResultCodeTypes.MaintenanceAborted
        /// </summary>
        MaintenanceAborted,
        /// <summary>
        /// MaintenanceCompleted
        /// Serialized Name: MaintenanceOperationResultCodeTypes.MaintenanceCompleted
        /// </summary>
        MaintenanceCompleted
    }
}
