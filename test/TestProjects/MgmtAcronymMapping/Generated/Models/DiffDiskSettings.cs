// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// Describes the parameters of ephemeral disk settings that can be specified for operating system disk. &lt;br&gt;&lt;br&gt; NOTE: The ephemeral disk settings can only be specified for managed disk.
    /// Serialized Name: DiffDiskSettings
    /// </summary>
    public partial class DiffDiskSettings
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DiffDiskSettings"/>. </summary>
        public DiffDiskSettings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DiffDiskSettings"/>. </summary>
        /// <param name="option">
        /// Specifies the ephemeral disk settings for operating system disk.
        /// Serialized Name: DiffDiskSettings.option
        /// </param>
        /// <param name="placement">
        /// Specifies the ephemeral disk placement for operating system disk.&lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **CacheDisk** &lt;br&gt;&lt;br&gt; **ResourceDisk** &lt;br&gt;&lt;br&gt; Default: **CacheDisk** if one is configured for the VM size otherwise **ResourceDisk** is used.&lt;br&gt;&lt;br&gt; Refer to VM size documentation for Windows VM at https://docs.microsoft.com/en-us/azure/virtual-machines/windows/sizes and Linux VM at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/sizes to check which VM sizes exposes a cache disk.
        /// Serialized Name: DiffDiskSettings.placement
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DiffDiskSettings(DiffDiskOption? option, DiffDiskPlacement? placement, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Option = option;
            Placement = placement;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Specifies the ephemeral disk settings for operating system disk.
        /// Serialized Name: DiffDiskSettings.option
        /// </summary>
        public DiffDiskOption? Option { get; set; }
        /// <summary>
        /// Specifies the ephemeral disk placement for operating system disk.&lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **CacheDisk** &lt;br&gt;&lt;br&gt; **ResourceDisk** &lt;br&gt;&lt;br&gt; Default: **CacheDisk** if one is configured for the VM size otherwise **ResourceDisk** is used.&lt;br&gt;&lt;br&gt; Refer to VM size documentation for Windows VM at https://docs.microsoft.com/en-us/azure/virtual-machines/windows/sizes and Linux VM at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/sizes to check which VM sizes exposes a cache disk.
        /// Serialized Name: DiffDiskSettings.placement
        /// </summary>
        public DiffDiskPlacement? Placement { get; set; }
    }
}
