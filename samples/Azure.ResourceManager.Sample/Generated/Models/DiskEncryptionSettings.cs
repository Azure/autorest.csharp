// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Encryption Settings for a Disk
    /// Serialized Name: DiskEncryptionSettings
    /// </summary>
    public partial class DiskEncryptionSettings
    {
        /// <summary> Initializes a new instance of DiskEncryptionSettings. </summary>
        public DiskEncryptionSettings()
        {
        }

        /// <summary> Initializes a new instance of DiskEncryptionSettings. </summary>
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
        internal DiskEncryptionSettings(KeyVaultSecretReference diskEncryptionKey, KeyVaultKeyReference keyEncryptionKey, bool? enabled)
        {
            DiskEncryptionKey = diskEncryptionKey;
            KeyEncryptionKey = keyEncryptionKey;
            Enabled = enabled;
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
