// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Maintenance Operation Status.
    /// Serialized Name: MaintenanceRedeployStatus
    /// </summary>
    public partial class MaintenanceRedeployStatus
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MaintenanceRedeployStatus(bool? isCustomerInitiatedMaintenanceAllowed, DateTimeOffset? preMaintenanceWindowStartOn, DateTimeOffset? preMaintenanceWindowEndOn, DateTimeOffset? maintenanceWindowStartOn, DateTimeOffset? maintenanceWindowEndOn, MaintenanceOperationResultCodeType? lastOperationResultCode, string lastOperationMessage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            IsCustomerInitiatedMaintenanceAllowed = isCustomerInitiatedMaintenanceAllowed;
            PreMaintenanceWindowStartOn = preMaintenanceWindowStartOn;
            PreMaintenanceWindowEndOn = preMaintenanceWindowEndOn;
            MaintenanceWindowStartOn = maintenanceWindowStartOn;
            MaintenanceWindowEndOn = maintenanceWindowEndOn;
            LastOperationResultCode = lastOperationResultCode;
            LastOperationMessage = lastOperationMessage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
