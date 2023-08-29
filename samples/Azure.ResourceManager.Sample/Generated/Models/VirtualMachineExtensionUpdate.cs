// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Virtual Machine Extension.
    /// Serialized Name: VirtualMachineExtensionUpdate
    /// </summary>
    public partial class VirtualMachineExtensionUpdate : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionUpdate"/>. </summary>
        public VirtualMachineExtensionUpdate()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineExtensionUpdate"/>. </summary>
        /// <param name="tags">
        /// Resource tags
        /// Serialized Name: UpdateResource.tags
        /// </param>
        /// <param name="forceUpdateTag">
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.publisher
        /// </param>
        /// <param name="extensionType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.protectedSettings
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineExtensionUpdate(IDictionary<string, string> tags, string forceUpdateTag, string publisher, string extensionType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, bool? enableAutomaticUpgrade, BinaryData settings, BinaryData protectedSettings, Dictionary<string, BinaryData> rawData) : base(tags, rawData)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            ExtensionType = extensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
        }

        /// <summary>
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.forceUpdateTag
        /// </summary>
        public string ForceUpdateTag { get; set; }
        /// <summary>
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.type
        /// </summary>
        public string ExtensionType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.typeHandlerVersion
        /// </summary>
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </summary>
        public bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.enableAutomaticUpgrade
        /// </summary>
        public bool? EnableAutomaticUpgrade { get; set; }
        /// <summary>
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.settings
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
        /// Serialized Name: VirtualMachineExtensionUpdate.properties.protectedSettings
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
    }
}
