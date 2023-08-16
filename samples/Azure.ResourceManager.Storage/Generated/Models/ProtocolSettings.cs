// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Protocol settings for file service. </summary>
    internal partial class ProtocolSettings
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ProtocolSettings
        ///
        /// </summary>
        public ProtocolSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ProtocolSettings
        ///
        /// </summary>
        /// <param name="smb"> Setting for SMB protocol. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ProtocolSettings(SmbSetting smb, Dictionary<string, BinaryData> rawData)
        {
            Smb = smb;
            _rawData = rawData;
        }

        /// <summary> Setting for SMB protocol. </summary>
        public SmbSetting Smb { get; set; }
    }
}
