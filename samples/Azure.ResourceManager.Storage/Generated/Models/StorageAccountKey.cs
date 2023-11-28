// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An access key for the storage account. </summary>
    public partial class StorageAccountKey
    {
        /// <summary> Initializes a new instance of <see cref="StorageAccountKey"/>. </summary>
        internal StorageAccountKey()
        {
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountKey"/>. </summary>
        /// <param name="keyName"> Name of the key. </param>
        /// <param name="value"> Base 64-encoded value of the key. </param>
        /// <param name="permissions"> Permissions for the key -- read-only or full permissions. </param>
        /// <param name="createdOn"> Creation time of the key, in round trip date format. </param>
        internal StorageAccountKey(string keyName, string value, KeyPermission? permissions, DateTimeOffset? createdOn)
        {
            KeyName = keyName;
            Value = value;
            Permissions = permissions;
            CreatedOn = createdOn;
        }

        /// <summary> Name of the key. </summary>
        public string KeyName { get; }
        /// <summary> Base 64-encoded value of the key. </summary>
        public string Value { get; }
        /// <summary> Permissions for the key -- read-only or full permissions. </summary>
        public KeyPermission? Permissions { get; }
        /// <summary> Creation time of the key, in round trip date format. </summary>
        public DateTimeOffset? CreatedOn { get; }
    }
}
