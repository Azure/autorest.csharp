// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Protected append writes history setting for the blob container with Legal holds. </summary>
    public partial class ProtectedAppendWritesHistory
    {
        /// <summary> Initializes a new instance of ProtectedAppendWritesHistory. </summary>
        internal ProtectedAppendWritesHistory()
        {
        }

        /// <summary> Initializes a new instance of ProtectedAppendWritesHistory. </summary>
        /// <param name="allowProtectedAppendWritesAll"> When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining legal hold protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </param>
        /// <param name="timestamp"> Returns the date and time the tag was added. </param>
        internal ProtectedAppendWritesHistory(bool? allowProtectedAppendWritesAll, DateTimeOffset? timestamp)
        {
            AllowProtectedAppendWritesAll = allowProtectedAppendWritesAll;
            Timestamp = timestamp;
        }

        /// <summary> When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining legal hold protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </summary>
        public bool? AllowProtectedAppendWritesAll { get; }
        /// <summary> Returns the date and time the tag was added. </summary>
        public DateTimeOffset? Timestamp { get; }
    }
}
