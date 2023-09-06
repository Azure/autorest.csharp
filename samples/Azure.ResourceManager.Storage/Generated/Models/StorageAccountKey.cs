// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An access key for the storage account. </summary>
    public partial class StorageAccountKey
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="StorageAccountKey"/>. </summary>
        internal StorageAccountKey()
        {
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountKey"/>. </summary>
        /// <param name="keyName"> Name of the key. </param>
        /// <param name="value"> Base 64-encoded value of the key. </param>
        /// <param name="permissions"> Permissions for the key -- read-only or full permissions. </param>
        /// <param name="createdOn"> Creation time of the key, in round trip date format. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountKey(string keyName, string value, KeyPermission? permissions, DateTimeOffset? createdOn, Dictionary<string, BinaryData> rawData)
        {
            KeyName = keyName;
            Value = value;
            Permissions = permissions;
            CreatedOn = createdOn;
            _rawData = rawData;
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
