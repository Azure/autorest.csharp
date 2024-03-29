// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Virtual Machine Scale Set Extension.
    /// Serialized Name: VirtualMachineScaleSetExtensionUpdate
    /// </summary>
    public partial class VirtualMachineScaleSetExtensionPatch : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetExtensionPatch"/>. </summary>
        public VirtualMachineScaleSetExtensionPatch()
        {
            ProvisionAfterExtensions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetExtensionPatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="forceUpdateTag">
        /// If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.publisher
        /// </param>
        /// <param name="typePropertiesType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.protectedSettings
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisioningState
        /// </param>
        /// <param name="provisionAfterExtensions">
        /// Collection of extension names after which this extension needs to be provisioned.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisionAfterExtensions
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetExtensionPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string forceUpdateTag, string publisher, string typePropertiesType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, bool? enableAutomaticUpgrade, BinaryData settings, BinaryData protectedSettings, string provisioningState, IList<string> provisionAfterExtensions, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            TypePropertiesType = typePropertiesType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            ProvisionAfterExtensions = provisionAfterExtensions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.forceUpdateTag
        /// </summary>
        [WirePath("properties.forceUpdateTag")]
        public string ForceUpdateTag { get; set; }
        /// <summary>
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.publisher
        /// </summary>
        [WirePath("properties.publisher")]
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.type
        /// </summary>
        [WirePath("properties.type")]
        public string TypePropertiesType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.typeHandlerVersion
        /// </summary>
        [WirePath("properties.typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </summary>
        [WirePath("properties.autoUpgradeMinorVersion")]
        public bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.enableAutomaticUpgrade
        /// </summary>
        [WirePath("properties.enableAutomaticUpgrade")]
        public bool? EnableAutomaticUpgrade { get; set; }
        /// <summary>
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.settings
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
        [WirePath("properties.settings")]
        public BinaryData Settings { get; set; }
        /// <summary>
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.protectedSettings
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
        [WirePath("properties.protectedSettings")]
        public BinaryData ProtectedSettings { get; set; }
        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisioningState
        /// </summary>
        [WirePath("properties.provisioningState")]
        public string ProvisioningState { get; }
        /// <summary>
        /// Collection of extension names after which this extension needs to be provisioned.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisionAfterExtensions
        /// </summary>
        [WirePath("properties.provisionAfterExtensions")]
        public IList<string> ProvisionAfterExtensions { get; }
    }
}
