// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Maintenance Operation Status.
    /// Serialized Name: MaintenanceRedeployStatus
    /// </summary>
    public partial class MaintenanceRedeployStatus
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="MaintenanceRedeployStatus"/>. </summary>
        internal MaintenanceRedeployStatus()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MaintenanceRedeployStatus"/>. </summary>
        /// <param name="isCustomerInitiatedMaintenanceAllowed">
        /// True, if customer is allowed to perform Maintenance.
        /// Serialized Name: MaintenanceRedeployStatus.isCustomerInitiatedMaintenanceAllowed
        /// </param>
        /// <param name="preMaintenanceWindowStartOn">
        /// Start Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowStartTime
        /// </param>
        /// <param name="preMaintenanceWindowEndOn">
        /// End Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowEndTime
        /// </param>
        /// <param name="maintenanceWindowStartOn">
        /// Start Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowStartTime
        /// </param>
        /// <param name="maintenanceWindowEndOn">
        /// End Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowEndTime
        /// </param>
        /// <param name="lastOperationResultCode">
        /// The Last Maintenance Operation Result Code.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationResultCode
        /// </param>
        /// <param name="lastOperationMessage">
        /// Message returned for the last Maintenance Operation.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationMessage
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MaintenanceRedeployStatus(bool? isCustomerInitiatedMaintenanceAllowed, DateTimeOffset? preMaintenanceWindowStartOn, DateTimeOffset? preMaintenanceWindowEndOn, DateTimeOffset? maintenanceWindowStartOn, DateTimeOffset? maintenanceWindowEndOn, MaintenanceOperationResultCodeType? lastOperationResultCode, string lastOperationMessage, Dictionary<string, BinaryData> rawData)
        {
            IsCustomerInitiatedMaintenanceAllowed = isCustomerInitiatedMaintenanceAllowed;
            PreMaintenanceWindowStartOn = preMaintenanceWindowStartOn;
            PreMaintenanceWindowEndOn = preMaintenanceWindowEndOn;
            MaintenanceWindowStartOn = maintenanceWindowStartOn;
            MaintenanceWindowEndOn = maintenanceWindowEndOn;
            LastOperationResultCode = lastOperationResultCode;
            LastOperationMessage = lastOperationMessage;
            _rawData = rawData;
        }

        /// <summary>
        /// True, if customer is allowed to perform Maintenance.
        /// Serialized Name: MaintenanceRedeployStatus.isCustomerInitiatedMaintenanceAllowed
        /// </summary>
        public bool? IsCustomerInitiatedMaintenanceAllowed { get; }
        /// <summary>
        /// Start Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowStartTime
        /// </summary>
        public DateTimeOffset? PreMaintenanceWindowStartOn { get; }
        /// <summary>
        /// End Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowEndTime
        /// </summary>
        public DateTimeOffset? PreMaintenanceWindowEndOn { get; }
        /// <summary>
        /// Start Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowStartTime
        /// </summary>
        public DateTimeOffset? MaintenanceWindowStartOn { get; }
        /// <summary>
        /// End Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowEndTime
        /// </summary>
        public DateTimeOffset? MaintenanceWindowEndOn { get; }
        /// <summary>
        /// The Last Maintenance Operation Result Code.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationResultCode
        /// </summary>
        public MaintenanceOperationResultCodeType? LastOperationResultCode { get; }
        /// <summary>
        /// Message returned for the last Maintenance Operation.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationMessage
        /// </summary>
        public string LastOperationMessage { get; }
    }
}
