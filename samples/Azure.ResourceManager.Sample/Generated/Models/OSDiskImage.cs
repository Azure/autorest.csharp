// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Contains the os disk image information.
    /// Serialized Name: OSDiskImage
    /// </summary>
    internal partial class OSDiskImage
    {
        /// <summary> Initializes a new instance of OSDiskImage. </summary>
        /// <param name="operatingSystem">
        /// The operating system of the osDiskImage.
        /// Serialized Name: OSDiskImage.operatingSystem
        /// </param>
        public OSDiskImage(OperatingSystemType operatingSystem)
        {
            OperatingSystem = operatingSystem;
        }

        /// <summary>
        /// The operating system of the osDiskImage.
        /// Serialized Name: OSDiskImage.operatingSystem
        /// </summary>
        public OperatingSystemType OperatingSystem { get; set; }
    }
}
