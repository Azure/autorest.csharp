// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the uri of a disk.
    /// Serialized Name: VirtualHardDisk
    /// </summary>
    internal partial class VirtualHardDisk
    {
        /// <summary> Initializes a new instance of VirtualHardDisk. </summary>
        public VirtualHardDisk()
        {
        }

        /// <summary> Initializes a new instance of VirtualHardDisk. </summary>
        /// <param name="uri">
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </param>
        internal VirtualHardDisk(Uri uri)
        {
            Uri = uri;
        }

        /// <summary>
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </summary>
        public Uri Uri { get; set; }
    }
}
