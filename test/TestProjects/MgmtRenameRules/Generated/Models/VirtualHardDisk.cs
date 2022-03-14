// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary> Describes the uri of a disk. </summary>
    internal partial class VirtualHardDisk
    {
        /// <summary> Initializes a new instance of VirtualHardDisk. </summary>
        public VirtualHardDisk()
        {
        }

        /// <summary> Initializes a new instance of VirtualHardDisk. </summary>
        /// <param name="uri"> Specifies the virtual hard disk&apos;s uri. </param>
        internal VirtualHardDisk(Uri uri)
        {
            Uri = uri;
        }

        /// <summary> Specifies the virtual hard disk&apos;s uri. </summary>
        public Uri Uri { get; set; }
    }
}
