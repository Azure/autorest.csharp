// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the VirtualMachineExtension data model.
    /// Describes a Virtual Machine Extension.
    /// Serialized Name: VirtualMachineExtension
    /// </summary>
    public partial class VirtualMachineExtensionData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionData"/>. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineExtensionData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="forceUpdateTag">
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineExtension.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineExtension.properties.publisher
        /// </param>
        /// <param name="extensionType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtension.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtension.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineExtension.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineExtension.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineExtension.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineExtension.properties.protectedSettings
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineExtension.properties.provisioningState
        /// </param>
        /// <param name="instanceView">
        /// The virtual machine extension instance view.
        /// Serialized Name: VirtualMachineExtension.properties.instanceView
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineExtensionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string forceUpdateTag, string publisher, string extensionType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, bool? enableAutomaticUpgrade, BinaryData settings, BinaryData protectedSettings, string provisioningState, VirtualMachineExtensionInstanceView instanceView, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            ExtensionType = extensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionData"/> for deserialization. </summary>
        internal VirtualMachineExtensionData()
        {
        }

        /// <summary>
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineExtension.properties.forceUpdateTag
        /// </summary>
        public string ForceUpdateTag { get; set; }
        /// <summary>
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineExtension.properties.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtension.properties.type
        /// </summary>
        public string ExtensionType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtension.properties.typeHandlerVersion
        /// </summary>
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineExtension.properties.autoUpgradeMinorVersion
        /// </summary>
        public bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineExtension.properties.enableAutomaticUpgrade
        /// </summary>
        public bool? EnableAutomaticUpgrade { get; set; }
        /// <summary>
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineExtension.properties.settings
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public BinaryData Settings { get; set; }
        /// <summary>
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineExtension.properties.protectedSettings
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public BinaryData ProtectedSettings { get; set; }
        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineExtension.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// The virtual machine extension instance view.
        /// Serialized Name: VirtualMachineExtension.properties.instanceView
        /// </summary>
        public VirtualMachineExtensionInstanceView InstanceView { get; set; }
    }
}
