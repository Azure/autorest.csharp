// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The protection policy of a virtual machine scale set VM.
    /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy
    /// </summary>
    public partial class VirtualMachineScaleSetVmProtectionPolicy
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVmProtectionPolicy"/>. </summary>
        public VirtualMachineScaleSetVmProtectionPolicy()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVmProtectionPolicy"/>. </summary>
        /// <param name="protectFromScaleIn">
        /// Indicates that the virtual machine scale set VM shouldn't be considered for deletion during a scale-in operation.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleIn
        /// </param>
        /// <param name="protectFromScaleSetActions">
        /// Indicates that model updates or actions (including scale-in) initiated on the virtual machine scale set should not be applied to the virtual machine scale set VM.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleSetActions
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVmProtectionPolicy(bool? protectFromScaleIn, bool? protectFromScaleSetActions, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ProtectFromScaleIn = protectFromScaleIn;
            ProtectFromScaleSetActions = protectFromScaleSetActions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Indicates that the virtual machine scale set VM shouldn't be considered for deletion during a scale-in operation.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleIn
        /// </summary>
        public bool? ProtectFromScaleIn { get; set; }
        /// <summary>
        /// Indicates that model updates or actions (including scale-in) initiated on the virtual machine scale set should not be applied to the virtual machine scale set VM.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleSetActions
        /// </summary>
        public bool? ProtectFromScaleSetActions { get; set; }
    }
}
