// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a Virtual Machine Scale Set Extension.
    /// Serialized Name: VirtualMachineScaleSetExtensionUpdate
    /// </summary>
    public partial class VirtualMachineScaleSetExtensionPatch : ResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionPatch. </summary>
        public VirtualMachineScaleSetExtensionPatch()
        {
            ProvisionAfterExtensions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionPatch. </summary>
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
        /// Specifies the type of the extension; an example is &quot;CustomScriptExtension&quot;.
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
        internal VirtualMachineScaleSetExtensionPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string forceUpdateTag, string publisher, string typePropertiesType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, bool? enableAutomaticUpgrade, BinaryData settings, BinaryData protectedSettings, string provisioningState, IList<string> provisionAfterExtensions) : base(id, name, resourceType, systemData)
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
        }

        /// <summary>
        /// If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.forceUpdateTag
        /// </summary>
        public string ForceUpdateTag { get; set; }
        /// <summary>
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is &quot;CustomScriptExtension&quot;.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.type
        /// </summary>
        public string TypePropertiesType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.typeHandlerVersion
        /// </summary>
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </summary>
        public bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.enableAutomaticUpgrade
        /// </summary>
        public bool? EnableAutomaticUpgrade { get; set; }
        /// <summary>
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.settings
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.protectedSettings
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// Collection of extension names after which this extension needs to be provisioned.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisionAfterExtensions
        /// </summary>
        public IList<string> ProvisionAfterExtensions { get; }
    }
}
