// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the disallowed configuration for a virtual machine image.
    /// Serialized Name: DisallowedConfiguration
    /// </summary>
    internal partial class DisallowedConfiguration
    {
        /// <summary> Initializes a new instance of DisallowedConfiguration. </summary>
        public DisallowedConfiguration()
        {
        }

        /// <summary> Initializes a new instance of DisallowedConfiguration. </summary>
        /// <param name="vmDiskType">
        /// VM disk types which are disallowed.
        /// Serialized Name: DisallowedConfiguration.vmDiskType
        /// </param>
        internal DisallowedConfiguration(VmDiskType? vmDiskType)
        {
            VmDiskType = vmDiskType;
        }

        /// <summary>
        /// VM disk types which are disallowed.
        /// Serialized Name: DisallowedConfiguration.vmDiskType
        /// </summary>
        public VmDiskType? VmDiskType { get; set; }
    }
}
