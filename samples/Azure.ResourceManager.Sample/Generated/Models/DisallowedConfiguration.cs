// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the disallowed configuration for a virtual machine image.
    /// Serialized Name: DisallowedConfiguration
    /// </summary>
    internal partial class DisallowedConfiguration
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DisallowedConfiguration"/>. </summary>
        public DisallowedConfiguration()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DisallowedConfiguration"/>. </summary>
        /// <param name="vmDiskType">
        /// VM disk types which are disallowed.
        /// Serialized Name: DisallowedConfiguration.vmDiskType
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DisallowedConfiguration(VmDiskType? vmDiskType, Dictionary<string, BinaryData> rawData)
        {
            VmDiskType = vmDiskType;
            _rawData = rawData;
        }

        /// <summary>
        /// VM disk types which are disallowed.
        /// Serialized Name: DisallowedConfiguration.vmDiskType
        /// </summary>
        public VmDiskType? VmDiskType { get; set; }
    }
}
