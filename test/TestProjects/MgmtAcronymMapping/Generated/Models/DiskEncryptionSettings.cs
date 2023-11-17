// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// Describes a Encryption Settings for a Disk
    /// Serialized Name: DiskEncryptionSettings
    /// </summary>
    public partial class DiskEncryptionSettings
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

        /// <summary> Initializes a new instance of <see cref="DiskEncryptionSettings"/>. </summary>
        public DiskEncryptionSettings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DiskEncryptionSettings"/>. </summary>
        /// <param name="diskEncryptionKey">
        /// Specifies the location of the disk encryption key, which is a Key Vault Secret.
        /// Serialized Name: DiskEncryptionSettings.diskEncryptionKey
        /// </param>
        /// <param name="keyEncryptionKey">
        /// Specifies the location of the key encryption key in Key Vault.
        /// Serialized Name: DiskEncryptionSettings.keyEncryptionKey
        /// </param>
        /// <param name="enabled">
        /// Specifies whether disk encryption should be enabled on the virtual machine.
        /// Serialized Name: DiskEncryptionSettings.enabled
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DiskEncryptionSettings(KeyVaultSecretReference diskEncryptionKey, KeyVaultKeyReference keyEncryptionKey, bool? enabled, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DiskEncryptionKey = diskEncryptionKey;
            KeyEncryptionKey = keyEncryptionKey;
            Enabled = enabled;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Specifies the location of the disk encryption key, which is a Key Vault Secret.
        /// Serialized Name: DiskEncryptionSettings.diskEncryptionKey
        /// </summary>
        public KeyVaultSecretReference DiskEncryptionKey { get; set; }
        /// <summary>
        /// Specifies the location of the key encryption key in Key Vault.
        /// Serialized Name: DiskEncryptionSettings.keyEncryptionKey
        /// </summary>
        public KeyVaultKeyReference KeyEncryptionKey { get; set; }
        /// <summary>
        /// Specifies whether disk encryption should be enabled on the virtual machine.
        /// Serialized Name: DiskEncryptionSettings.enabled
        /// </summary>
        public bool? Enabled { get; set; }
    }
}
