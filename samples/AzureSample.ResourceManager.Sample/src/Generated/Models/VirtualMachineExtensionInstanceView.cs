// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a virtual machine extension.
    /// Serialized Name: VirtualMachineExtensionInstanceView
    /// </summary>
    public partial class VirtualMachineExtensionInstanceView
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionInstanceView"/>. </summary>
        public VirtualMachineExtensionInstanceView()
        {
            Substatuses = new ChangeTrackingList<InstanceViewStatus>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionInstanceView"/>. </summary>
        /// <param name="name">
        /// The virtual machine extension name.
        /// Serialized Name: VirtualMachineExtensionInstanceView.name
        /// </param>
        /// <param name="virtualMachineExtensionInstanceViewType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionInstanceView.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionInstanceView.typeHandlerVersion
        /// </param>
        /// <param name="substatuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.substatuses
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.statuses
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineExtensionInstanceView(string name, string virtualMachineExtensionInstanceViewType, string typeHandlerVersion, IList<InstanceViewStatus> substatuses, IList<InstanceViewStatus> statuses, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            VirtualMachineExtensionInstanceViewType = virtualMachineExtensionInstanceViewType;
            TypeHandlerVersion = typeHandlerVersion;
            Substatuses = substatuses;
            Statuses = statuses;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The virtual machine extension name.
        /// Serialized Name: VirtualMachineExtensionInstanceView.name
        /// </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionInstanceView.type
        /// </summary>
        [WirePath("type")]
        public string VirtualMachineExtensionInstanceViewType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionInstanceView.typeHandlerVersion
        /// </summary>
        [WirePath("typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.substatuses
        /// </summary>
        [WirePath("substatuses")]
        public IList<InstanceViewStatus> Substatuses { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.statuses
        /// </summary>
        [WirePath("statuses")]
        public IList<InstanceViewStatus> Statuses { get; }
    }
}
