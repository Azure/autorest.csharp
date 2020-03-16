// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> The key vault properties for the encryption scope. This is a required field if encryption scope &apos;source&apos; attribute is set to &apos;Microsoft.KeyVault&apos;. </summary>
    public partial class EncryptionScopeKeyVaultProperties
    {
        /// <summary> Initializes a new instance of EncryptionScopeKeyVaultProperties. </summary>
        internal EncryptionScopeKeyVaultProperties()
        {
        }
        /// <summary> Initializes a new instance of EncryptionScopeKeyVaultProperties. </summary>
        /// <param name="keyUri"> The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope. </param>
        internal EncryptionScopeKeyVaultProperties(string keyUri)
        {
            KeyUri = keyUri;
        }
        /// <summary> The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope. </summary>
        public string KeyUri { get; set; }
    }
}
