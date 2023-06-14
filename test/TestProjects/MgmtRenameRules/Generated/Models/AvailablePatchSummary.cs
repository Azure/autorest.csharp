// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes the properties of an virtual machine instance view for available patch summary.
    /// Serialized Name: AvailablePatchSummary
    /// </summary>
    public partial class AvailablePatchSummary
    {
        /// <summary> Initializes a new instance of AvailablePatchSummary. </summary>
        internal AvailablePatchSummary()
        {
        }

        /// <summary> Initializes a new instance of AvailablePatchSummary. </summary>
        /// <param name="status">
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: AvailablePatchSummary.status
        /// </param>
        /// <param name="assessmentActivityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: AvailablePatchSummary.assessmentActivityId
        /// </param>
        /// <param name="rebootPending">
        /// The overall reboot status of the VM. It will be true when partially installed patches require a reboot to complete installation but the reboot has not yet occurred.
        /// Serialized Name: AvailablePatchSummary.rebootPending
        /// </param>
        /// <param name="criticalAndSecurityPatchCount">
        /// The number of critical or security patches that have been detected as available and not yet installed.
        /// Serialized Name: AvailablePatchSummary.criticalAndSecurityPatchCount
        /// </param>
        /// <param name="otherPatchCount">
        /// The number of all available patches excluding critical and security.
        /// Serialized Name: AvailablePatchSummary.otherPatchCount
        /// </param>
        /// <param name="uri">
        /// The managed application artifact blob uri.
        /// Serialized Name: AvailablePatchSummary.uri
        /// </param>
        /// <param name="startOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.startTime
        /// </param>
        /// <param name="lastModifiedOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.lastModifiedTime
        /// </param>
        /// <param name="error">
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: AvailablePatchSummary.error
        /// </param>
        internal AvailablePatchSummary(PatchOperationStatus? status, string assessmentActivityId, bool? rebootPending, int? criticalAndSecurityPatchCount, int? otherPatchCount, Uri uri, DateTimeOffset? startOn, DateTimeOffset? lastModifiedOn, ApiError error)
        {
            Status = status;
            AssessmentActivityId = assessmentActivityId;
            RebootPending = rebootPending;
            CriticalAndSecurityPatchCount = criticalAndSecurityPatchCount;
            OtherPatchCount = otherPatchCount;
            Uri = uri;
            StartOn = startOn;
            LastModifiedOn = lastModifiedOn;
            Error = error;
        }

        /// <summary>
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: AvailablePatchSummary.status
        /// </summary>
        public PatchOperationStatus? Status { get; }
        /// <summary>
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: AvailablePatchSummary.assessmentActivityId
        /// </summary>
        public string AssessmentActivityId { get; }
        /// <summary>
        /// The overall reboot status of the VM. It will be true when partially installed patches require a reboot to complete installation but the reboot has not yet occurred.
        /// Serialized Name: AvailablePatchSummary.rebootPending
        /// </summary>
        public bool? RebootPending { get; }
        /// <summary>
        /// The number of critical or security patches that have been detected as available and not yet installed.
        /// Serialized Name: AvailablePatchSummary.criticalAndSecurityPatchCount
        /// </summary>
        public int? CriticalAndSecurityPatchCount { get; }
        /// <summary>
        /// The number of all available patches excluding critical and security.
        /// Serialized Name: AvailablePatchSummary.otherPatchCount
        /// </summary>
        public int? OtherPatchCount { get; }
        /// <summary>
        /// The managed application artifact blob uri.
        /// Serialized Name: AvailablePatchSummary.uri
        /// </summary>
        public Uri Uri { get; }
        /// <summary>
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.startTime
        /// </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary>
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.lastModifiedTime
        /// </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary>
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: AvailablePatchSummary.error
        /// </summary>
        public ApiError Error { get; }
    }
}
