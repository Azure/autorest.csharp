// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the uri of a disk.
    /// Serialized Name: VirtualHardDisk
    /// </summary>
    internal partial class VirtualHardDisk
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualHardDisk"/>. </summary>
        public VirtualHardDisk()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualHardDisk"/>. </summary>
        /// <param name="uri">
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualHardDisk(Uri uri, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Uri = uri;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </summary>
        public Uri Uri { get; set; }
    }
}
