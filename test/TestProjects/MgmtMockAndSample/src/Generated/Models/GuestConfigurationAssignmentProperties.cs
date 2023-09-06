// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Guest configuration assignment properties. </summary>
    public partial class GuestConfigurationAssignmentProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationAssignmentProperties"/>. </summary>
        public GuestConfigurationAssignmentProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationAssignmentProperties"/>. </summary>
        /// <param name="targetResourceId"> VM resource Id. </param>
        /// <param name="complianceStatus"> A value indicating compliance status of the machine for the assigned guest configuration. </param>
        /// <param name="lastComplianceStatusChecked"> Date and time when last compliance status was checked. </param>
        /// <param name="latestReportId"> Id of the latest report for the guest configuration assignment. </param>
        /// <param name="parameterHash"> parameter hash for the guest configuration assignment. </param>
        /// <param name="context"> The source which initiated the guest configuration assignment. Ex: Azure Policy. </param>
        /// <param name="assignmentHash"> Combined hash of the configuration package and parameters. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="resourceType"> Type of the resource - VMSS / VM. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal GuestConfigurationAssignmentProperties(string targetResourceId, ComplianceStatus? complianceStatus, DateTimeOffset? lastComplianceStatusChecked, string latestReportId, string parameterHash, string context, string assignmentHash, ProvisioningState? provisioningState, ResourceType? resourceType, Dictionary<string, BinaryData> rawData)
        {
            TargetResourceId = targetResourceId;
            ComplianceStatus = complianceStatus;
            LastComplianceStatusChecked = lastComplianceStatusChecked;
            LatestReportId = latestReportId;
            ParameterHash = parameterHash;
            Context = context;
            AssignmentHash = assignmentHash;
            ProvisioningState = provisioningState;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> VM resource Id. </summary>
        public string TargetResourceId { get; }
        /// <summary> A value indicating compliance status of the machine for the assigned guest configuration. </summary>
        public ComplianceStatus? ComplianceStatus { get; }
        /// <summary> Date and time when last compliance status was checked. </summary>
        public DateTimeOffset? LastComplianceStatusChecked { get; }
        /// <summary> Id of the latest report for the guest configuration assignment. </summary>
        public string LatestReportId { get; }
        /// <summary> parameter hash for the guest configuration assignment. </summary>
        public string ParameterHash { get; }
        /// <summary> The source which initiated the guest configuration assignment. Ex: Azure Policy. </summary>
        public string Context { get; set; }
        /// <summary> Combined hash of the configuration package and parameters. </summary>
        public string AssignmentHash { get; }
        /// <summary> The provisioning state, which only appears in the response. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> Type of the resource - VMSS / VM. </summary>
        public ResourceType? ResourceType { get; }
    }
}
