// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The FileServiceItems. </summary>
    internal partial class FileServiceItems
    {
        /// <summary> Initializes a new instance of FileServiceItems. </summary>
        internal FileServiceItems()
        {
            Value = new ChangeTrackingList<FileServiceData>();
        }

        /// <summary> Initializes a new instance of FileServiceItems. </summary>
        /// <param name="value"> List of file services returned. </param>
        internal FileServiceItems(IReadOnlyList<FileServiceData> value)
        {
            Value = value;
        }

        /// <summary> List of file services returned. </summary>
        public IReadOnlyList<FileServiceData> Value { get; }
    }
}
