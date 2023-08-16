// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The instance view of the disk.
    /// Serialized Name: DiskInstanceView
    /// </summary>
    public partial class DiskInstanceView
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.DiskInstanceView
        ///
        /// </summary>
        internal DiskInstanceView()
        {
            EncryptionSettings = new ChangeTrackingList<DiskEncryptionSettings>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.DiskInstanceView
        ///
        /// </summary>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: DiskInstanceView.name
        /// </param>
        /// <param name="encryptionSettings">
        /// Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: DiskInstanceView.encryptionSettings
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: DiskInstanceView.statuses
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DiskInstanceView(string name, IReadOnlyList<DiskEncryptionSettings> encryptionSettings, IReadOnlyList<InstanceViewStatus> statuses, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            EncryptionSettings = encryptionSettings;
            Statuses = statuses;
            _rawData = rawData;
        }

        /// <summary>
        /// The disk name.
        /// Serialized Name: DiskInstanceView.name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: DiskInstanceView.encryptionSettings
        /// </summary>
        public IReadOnlyList<DiskEncryptionSettings> EncryptionSettings { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: DiskInstanceView.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
    }
}
