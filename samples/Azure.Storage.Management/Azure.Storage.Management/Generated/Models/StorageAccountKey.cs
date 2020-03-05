// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> An access key for the storage account. </summary>
    public partial class StorageAccountKey
    {
        /// <summary> Name of the key. </summary>
        public string KeyName { get; internal set; }
        /// <summary> Base 64-encoded value of the key. </summary>
        public string Value { get; internal set; }
        /// <summary> Permissions for the key -- read-only or full permissions. </summary>
        public KeyPermission? Permissions { get; internal set; }
    }
}
