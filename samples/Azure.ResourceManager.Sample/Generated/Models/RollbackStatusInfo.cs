// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Information about rollback on failed VM instances after a OS Upgrade operation.
    /// Serialized Name: RollbackStatusInfo
    /// </summary>
    public partial class RollbackStatusInfo
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

        /// <summary> Initializes a new instance of <see cref="RollbackStatusInfo"/>. </summary>
        internal RollbackStatusInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RollbackStatusInfo"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RollbackStatusInfo(int? successfullyRolledbackInstanceCount, int? failedRolledbackInstanceCount, ApiError rollbackError, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SuccessfullyRolledbackInstanceCount = successfullyRolledbackInstanceCount;
            FailedRolledbackInstanceCount = failedRolledbackInstanceCount;
            RollbackError = rollbackError;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
