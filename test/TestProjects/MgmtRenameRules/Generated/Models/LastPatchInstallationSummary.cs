// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes the properties of the last installed patch summary.
    /// Serialized Name: LastPatchInstallationSummary
    /// </summary>
    public partial class LastPatchInstallationSummary
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.LastPatchInstallationSummary
        ///
        /// </summary>
        internal LastPatchInstallationSummary()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.LastPatchInstallationSummary
        ///
        /// </summary>
        /// <param name="status">
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: LastPatchInstallationSummary.status
        /// </param>
        /// <param name="installationActivityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: LastPatchInstallationSummary.installationActivityId
        /// </param>
        /// <param name="maintenanceWindowExceeded">
        /// Describes whether the operation ran out of time before it completed all its intended actions
        /// Serialized Name: LastPatchInstallationSummary.maintenanceWindowExceeded
        /// </param>
        /// <param name="rebootStatus">
        /// The reboot status of the machine after the patch operation. It will be in "NotNeeded" status if reboot is not needed after the patch operation. "Required" will be the status once the patch is applied and machine is required to reboot. "Started" will be the reboot status when the machine has started to reboot. "Failed" will be the status if the machine is failed to reboot. "Completed" will be the status once the machine is rebooted successfully
        /// Serialized Name: LastPatchInstallationSummary.rebootStatus
        /// </param>
        /// <param name="notSelectedPatchCount">
        /// The number of all available patches but not going to be installed because it didn't match a classification or inclusion list entry.
        /// Serialized Name: LastPatchInstallationSummary.notSelectedPatchCount
        /// </param>
        /// <param name="excludedPatchCount">
        /// The number of all available patches but excluded explicitly by a customer-specified exclusion list match.
        /// Serialized Name: LastPatchInstallationSummary.excludedPatchCount
        /// </param>
        /// <param name="pendingPatchCount">
        /// The number of all available patches expected to be installed over the course of the patch installation operation.
        /// Serialized Name: LastPatchInstallationSummary.pendingPatchCount
        /// </param>
        /// <param name="installedPatchCount">
        /// The count of patches that successfully installed.
        /// Serialized Name: LastPatchInstallationSummary.installedPatchCount
        /// </param>
        /// <param name="failedPatchCount">
        /// The count of patches that failed installation.
        /// Serialized Name: LastPatchInstallationSummary.failedPatchCount
        /// </param>
        /// <param name="startOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.startTime
        /// </param>
        /// <param name="lastModifiedOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.lastModifiedTime
        /// </param>
        /// <param name="startedBy">
        /// The person or system account that started the operation
        /// Serialized Name: LastPatchInstallationSummary.startedBy
        /// </param>
        /// <param name="error">
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: LastPatchInstallationSummary.error
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal LastPatchInstallationSummary(PatchOperationStatus? status, string installationActivityId, bool? maintenanceWindowExceeded, RebootStatus? rebootStatus, int? notSelectedPatchCount, int? excludedPatchCount, int? pendingPatchCount, int? installedPatchCount, int? failedPatchCount, DateTimeOffset? startOn, DateTimeOffset? lastModifiedOn, string startedBy, ApiError error, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            InstallationActivityId = installationActivityId;
            MaintenanceWindowExceeded = maintenanceWindowExceeded;
            RebootStatus = rebootStatus;
            NotSelectedPatchCount = notSelectedPatchCount;
            ExcludedPatchCount = excludedPatchCount;
            PendingPatchCount = pendingPatchCount;
            InstalledPatchCount = installedPatchCount;
            FailedPatchCount = failedPatchCount;
            StartOn = startOn;
            LastModifiedOn = lastModifiedOn;
            StartedBy = startedBy;
            Error = error;
            _rawData = rawData;
        }

        /// <summary>
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: LastPatchInstallationSummary.status
        /// </summary>
        public PatchOperationStatus? Status { get; }
        /// <summary>
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: LastPatchInstallationSummary.installationActivityId
        /// </summary>
        public string InstallationActivityId { get; }
        /// <summary>
        /// Describes whether the operation ran out of time before it completed all its intended actions
        /// Serialized Name: LastPatchInstallationSummary.maintenanceWindowExceeded
        /// </summary>
        public bool? MaintenanceWindowExceeded { get; }
        /// <summary>
        /// The reboot status of the machine after the patch operation. It will be in "NotNeeded" status if reboot is not needed after the patch operation. "Required" will be the status once the patch is applied and machine is required to reboot. "Started" will be the reboot status when the machine has started to reboot. "Failed" will be the status if the machine is failed to reboot. "Completed" will be the status once the machine is rebooted successfully
        /// Serialized Name: LastPatchInstallationSummary.rebootStatus
        /// </summary>
        public RebootStatus? RebootStatus { get; }
        /// <summary>
        /// The number of all available patches but not going to be installed because it didn't match a classification or inclusion list entry.
        /// Serialized Name: LastPatchInstallationSummary.notSelectedPatchCount
        /// </summary>
        public int? NotSelectedPatchCount { get; }
        /// <summary>
        /// The number of all available patches but excluded explicitly by a customer-specified exclusion list match.
        /// Serialized Name: LastPatchInstallationSummary.excludedPatchCount
        /// </summary>
        public int? ExcludedPatchCount { get; }
        /// <summary>
        /// The number of all available patches expected to be installed over the course of the patch installation operation.
        /// Serialized Name: LastPatchInstallationSummary.pendingPatchCount
        /// </summary>
        public int? PendingPatchCount { get; }
        /// <summary>
        /// The count of patches that successfully installed.
        /// Serialized Name: LastPatchInstallationSummary.installedPatchCount
        /// </summary>
        public int? InstalledPatchCount { get; }
        /// <summary>
        /// The count of patches that failed installation.
        /// Serialized Name: LastPatchInstallationSummary.failedPatchCount
        /// </summary>
        public int? FailedPatchCount { get; }
        /// <summary>
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.startTime
        /// </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary>
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.lastModifiedTime
        /// </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary>
        /// The person or system account that started the operation
        /// Serialized Name: LastPatchInstallationSummary.startedBy
        /// </summary>
        public string StartedBy { get; }
        /// <summary>
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: LastPatchInstallationSummary.error
        /// </summary>
        public ApiError Error { get; }
    }
}
